using Microsoft.EntityFrameworkCore;
using newkilibraries;

namespace newki_inventory_proforma
{
     public class ApplicationDbContext : DbContext
     {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AgentCustomer>().HasKey(sc => new { sc.CustomerId, sc.AgentId });
            builder.Entity<ProformaProformaItem>().HasKey(sc => new { sc.ProformaId, sc.ProformaItemId });
            builder.Entity<ProformaItem>().HasKey(sc => new { sc.ProformaItemId });
            builder.Entity<ProformaDocumentFile>().HasKey(sc => new { sc.ProformaId, sc.DocumentFileId });
            builder.Entity<ProformaDataView>().HasKey(sc => new { sc.ProformaId });
            builder.Entity<ProformaDataView>().Property(f => f.ProformaId);
        }
        public DbSet<Proforma> Proforma { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ProformaItem> ProformaItem{get;set;}
        public DbSet<ProformaProformaItem> ProformaProformaItem{get;set;}
        public DbSet<DocumentFile> DocumentFile{get;set;}
        public DbSet<ProformaDocumentFile> ProformaDocumentFile{get;set;}
        public DbSet<ProformaDataView> ProformaDataView{get;set;}
        public DbSet<RequestStatus> RequestStatus{get;set;}
        
    }
}