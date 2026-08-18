using Microsoft.EntityFrameworkCore;

namespace BillingApp.Models
{
    public class InvoiceDbContext : DbContext
    {
        public DbSet<Invoice> Invoice {  get; set; }

        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options) 
        {
        
        
        
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .Property(i => i.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Invoice>()
                .ToTable("Invoice", tb => tb.HasTrigger("trg_Invoice_Insert"));
        }

    }
}
