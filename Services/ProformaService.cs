
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using newkilibraries;

namespace newki_inventory_proforma
{
    public interface IProformaService
    {
        List<Proforma> GetProformas();
        Proforma GetProforma(int id);
        Proforma Insert( Proforma proforma);
        Proforma Update(Proforma proforma);
        int Delete(int proformaId);
    }
    public class ProformaService :IProformaService
    {
         private readonly ApplicationDbContext _context;
        private const string bucketName = "newki";

        public ProformaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Proforma> GetProformas()
        {
            List<Proforma> Items = _context.Proforma
            .OrderByDescending(p=>p.ProformaDate)
            .Include(p => p.ProformaProformaItems).ThenInclude(w => w.ProformaItem)
            .Include(p => p.Files).ThenInclude(w => w.File)
            .Include(p => p.Customer).ToList();
            return Items;
        }

        public Proforma GetProforma(int id)
        {
            var Item = _context.Proforma.Include(p => p.Customer)
            .Include(p => p.ProformaProformaItems).ThenInclude(p => p.ProformaItem)
            .Include(p => p.Files).ThenInclude(w => w.File)
            .FirstOrDefault(p => p.ProformaId == id);
            return Item;
        }

        public Proforma Insert( Proforma proforma)
        {
            proforma.Customer = _context.Customer.FirstOrDefault(p => p.CustomerId == proforma.Customer.CustomerId);
            var ids = new Dictionary<int, ProformaProformaItem>();
            foreach (var proformaItem in proforma.ProformaProformaItems)
            {                
                proformaItem.Proforma = null;

                if (proformaItem.ProformaItemId == -1)
                {
                    var newProformaItem = new ProformaItem();
                    newProformaItem.Description = proformaItem.ProformaItem.Description;
                    _context.ProformaItem.Add(newProformaItem);
                    var itemId = _context.SaveChanges();                                        
                    proformaItem.ProformaItemId = newProformaItem.ProformaItemId;
                }
                _context.SaveChanges();
                proformaItem.ProformaItem = null;
            }            

            _context.Proforma.Add(proforma);
            _context.SaveChanges();
            return _context.Proforma.Include(p=>p.ProformaProformaItems)
                            .ThenInclude(p=>p.ProformaItem)
                            .FirstOrDefault(p=>p.ProformaId == proforma.ProformaId);
        }


        public Proforma Update(Proforma proforma)
        {
            var newCustomer = _context.Customer
            .FirstOrDefault(p => p.CustomerId == proforma.Customer.CustomerId);
            var oldProforma = _context.Proforma
                                    .Include(p => p.ProformaProformaItems)
                                    .Include(p => p.Files).ThenInclude(w => w.File)
                                    .FirstOrDefault(p => p.ProformaId == proforma.ProformaId);

            _context.ProformaProformaItem.RemoveRange(oldProforma.ProformaProformaItems);

            foreach (var oldInvoiceDocument in oldProforma.Files)
            {
                _context.DocumentFile.Remove(oldInvoiceDocument.File);
            }
            _context.ProformaDocumentFile.RemoveRange(oldProforma.Files);


            _context.SaveChanges();

            foreach (var proformaItem in proforma.ProformaProformaItems)
            {
                proformaItem.Proforma = null;
                

                if (proformaItem.ProformaItemId == -1)
                {
                    var newProformaItem = new ProformaItem();
                    newProformaItem.Description = proformaItem.ProformaItem.Description;
                    _context.ProformaItem.Add(newProformaItem);
                    _context.SaveChanges();
                    proformaItem.ProformaItemId = newProformaItem.ProformaItemId;

                }
                proformaItem.ProformaItem = null;

            }

            foreach (var file in proforma.Files)
            {
                var oldFile = _context.DocumentFile.FirstOrDefault(p => p.DocumentFileId == file.DocumentFileId);
                if (oldFile == null)
                {
                    oldProforma.Files.Add(file);
                }
                else
                {
                    var newProformaFile = new ProformaDocumentFile();
                    newProformaFile.DocumentFileId = oldFile.DocumentFileId;
                    newProformaFile.ProformaId = proforma.ProformaId;
                    oldProforma.Files.Add(newProformaFile);
                }
            }


            oldProforma.Customer = newCustomer;
            oldProforma.ExchangeRate = proforma.ExchangeRate;
            oldProforma.ProformaDate = proforma.ProformaDate.ToLocalTime();
            oldProforma.ProformaDueDate = proforma.ProformaDueDate.ToLocalTime();
            oldProforma.Paid = proforma.Paid;
            oldProforma.TotalUsd = proforma.TotalUsd;
            oldProforma.Kdv = proforma.Kdv;
            oldProforma.Tax = proforma.Tax;
            oldProforma.ProformaProformaItems = proforma.ProformaProformaItems;
            oldProforma.Discount = proforma.Discount;
            oldProforma.Currency = proforma.Currency;
            oldProforma.Comment = proforma.Comment;
            oldProforma.Seller = proforma.Seller;
            oldProforma.Buyer = proforma.Buyer;
            oldProforma.Consignee = proforma.Consignee;
            oldProforma.CountryOfBeneficiary = proforma.CountryOfBeneficiary;
            oldProforma.CountryOfDestination = proforma.CountryOfDestination;
            oldProforma.CountryOfOrigin = proforma.CountryOfOrigin;
            oldProforma.HsCode = proforma.HsCode;
            oldProforma.PackageDescription = proforma.PackageDescription;
            oldProforma.FreightForwarder = proforma.FreightForwarder;
            oldProforma.PartialShipment = proforma.PartialShipment;
            oldProforma.RelevantLocation = proforma.RelevantLocation;
            oldProforma.Size = proforma.Size;
            oldProforma.Port = proforma.Port;
            oldProforma.TermsOfDelivery = proforma.TermsOfDelivery;
            oldProforma.TermsOfPayment = proforma.TermsOfPayment;
            oldProforma.TotalGross = proforma.TotalGross;
            oldProforma.TransportBy = proforma.TransportBy;
            oldProforma.ValidUntil = proforma.ValidUntil;
            oldProforma.ProformaNumber = proforma.ProformaNumber;
            oldProforma.BankAccounts = proforma.BankAccounts;

            _context.Proforma.Update(oldProforma);

            _context.SaveChanges();
            return _context.Proforma.Include(p=>p.ProformaProformaItems)
                        .ThenInclude(p=>p.ProformaItem)
                        .FirstOrDefault(p=>p.ProformaId == oldProforma.ProformaId);
        }

        public int Delete(int proformaId)
        {
            var proformaOld = _context.Proforma
                .Include(p => p.ProformaProformaItems)
                .Where(x => x.ProformaId == proformaId)
                .FirstOrDefault();

            _context.Proforma.Remove(proformaOld);
            _context.SaveChanges();
            return proformaId;

        }

    }
}
