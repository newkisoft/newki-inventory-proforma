using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using newki_inventory_proforma.Services;
using newkilibraries;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace newki_inventory_proforma
{
   class Program
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        private static string _connectionString;

        static void Main(string[] args)
        {
            //Reading configuration
            var proformas = new List<Proforma>();
            var awsStorageConfig = new AwsStorageConfig();
            var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);
            var Configuration = builder.Build();
            Configuration.GetSection("AwsStorageConfig").Bind(awsStorageConfig);


            var services = new ServiceCollection();


            var requestQueueName = "ProformaRequest";
            var responseQueueName = "ProformaResponse";

            _connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(_connectionString));
            services.AddTransient<IAwsService, AwsService>();
            services.AddSingleton<IAwsStorageConfig>(awsStorageConfig);

            var serviceProvider = services.BuildServiceProvider();
            InventoryMessage inventoryMessage;

            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "user";
            factory.Password = "password";
            factory.HostName = "localhost";

            var connection = factory.CreateConnection();


            var channel = connection.CreateModel();
            channel.QueueDeclare(requestQueueName, false, false, false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var updateCustomerFullNameModel = JsonSerializer.Deserialize<InventoryMessage>(content);

                ProcessRequest(updateCustomerFullNameModel);

            }; ;
            channel.BasicConsume(queue: requestQueueName,
                   autoAck: true,
                   consumer: consumer);


            _quitEvent.WaitOne();



        }

        static void ProcessSearch(IProformaService ProformaService, ApplicationDbContext appDbContext)
        {
            Console.WriteLine("Loading all the Proformas...");
            var proformas = ProformaService.GetProformas();

            foreach (var Proforma in proformas)
            {
                if (appDbContext.ProformaDataView.Any(p => p.ProformaId == Proforma.ProformaId))
                {
                    var existingProforma = appDbContext.ProformaDataView.Find(Proforma.ProformaId);
                    existingProforma.Data = JsonSerializer.Serialize(Proforma);
                }
                else
                {
                    var ProformaDataView = new ProformaDataView
                    {
                        ProformaId = Proforma.ProformaId,
                        Data = JsonSerializer.Serialize(Proforma)
                    };
                    appDbContext.ProformaDataView.Add(ProformaDataView);
                }
                appDbContext.SaveChanges();
            }
        }

        private static void ProcessRequest(InventoryMessage inventoryMessage)
        {

            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseNpgsql(_connectionString);

                using (var appDbContext = new ApplicationDbContext(optionsBuilder.Options))
                {
                    var ProformaService = new ProformaService(appDbContext);


                    var messageType = Enum.Parse<InventoryMessageType>(inventoryMessage.Command);

                    switch (messageType)
                    {
                        case InventoryMessageType.Search:
                            {
                                ProcessSearch(ProformaService, appDbContext);
                                break;
                            }
                        case InventoryMessageType.Get:
                            {
                                Console.WriteLine("Loading an Proforma...");
                                var id = JsonSerializer.Deserialize<int>(inventoryMessage.Message);
                                var Proforma = ProformaService.GetProforma(id);
                                var content = JsonSerializer.Serialize(Proforma);

                                var responseMessageNotification = new InventoryMessage();
                                responseMessageNotification.Command = InventoryMessageType.Get.ToString();
                                responseMessageNotification.RequestNumber = inventoryMessage.RequestNumber;
                                responseMessageNotification.MessageDate = DateTimeOffset.UtcNow;

                                var inventoryResponseMessage = new InventoryMessage();
                                inventoryResponseMessage.Message = content;
                                inventoryResponseMessage.Command = inventoryMessage.Command;
                                inventoryResponseMessage.RequestNumber = inventoryMessage.RequestNumber;

                                Console.WriteLine("Sending the message back");

                                break;

                            }
                        case InventoryMessageType.Insert:
                            {
                                Console.WriteLine("Adding new Proforma");
                                var proforma = JsonSerializer.Deserialize<Proforma>(inventoryMessage.Message);
                                proforma = ProformaService.Insert(proforma);
                                var newProforma = new ProformaDataView
                                {
                                    ProformaId = proforma.ProformaId,
                                    Data = JsonSerializer.Serialize(proforma)
                                };
                                appDbContext.ProformaDataView.Add(newProforma);
                                appDbContext.SaveChanges();
                                var status = appDbContext.RequestStatus.FirstOrDefault(p => p.Id == inventoryMessage.RequestNumber);
                                if (status != null)
                                {
                                    status.Status = newProforma.ProformaId.ToString();
                                    appDbContext.SaveChanges();
                                }
                                break;
                            }
                        case InventoryMessageType.Update:
                            {
                                Console.WriteLine("Updating an Proforma");
                                var Proforma = JsonSerializer.Deserialize<Proforma>(inventoryMessage.Message);
                                ProformaService.Update(Proforma);
                                var existingProforma = appDbContext.ProformaDataView.Find(Proforma.ProformaId);
                                existingProforma.Data = JsonSerializer.Serialize(Proforma);
                                appDbContext.SaveChanges();
                                var status = appDbContext.RequestStatus.FirstOrDefault(p => p.Id == inventoryMessage.RequestNumber);
                                if (status != null)
                                {
                                    status.Status = existingProforma.ProformaId.ToString();
                                    appDbContext.SaveChanges();
                                }

                                break;
                            }
                        case InventoryMessageType.Delete:
                            {
                                Console.WriteLine("Deleting an Proforma");
                                var id = JsonSerializer.Deserialize<int>(inventoryMessage.Message);
                                ProformaService.Delete(id);
                                var removeProforma = appDbContext.ProformaDataView.FirstOrDefault(predicate => predicate.ProformaId == id);
                                appDbContext.ProformaDataView.Remove(removeProforma);
                                appDbContext.SaveChanges();
                                break;
                            }
                        default: break;

                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
        }
      
    }
}
