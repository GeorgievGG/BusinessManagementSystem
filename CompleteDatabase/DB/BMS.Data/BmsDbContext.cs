using BMS.Data.EntityConfiguration;
using BMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BMS.Data
{
    public class BmsDbContext : DbContext
    {
        public BmsDbContext() { }

        public BmsDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<InvoiceClient> InvoicesClient { get; set; }
        public DbSet<InvoiceSupplier> InvoicesSupplier { get; set; }
        public DbSet<ProjectSupplier> ProjectsSuppliers { get; set; }

        //Add OnConfiguring Method

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContractConfiguration());

            builder.ApplyConfiguration(new InquiryConfiguration());

            builder.ApplyConfiguration(new ClientConfiguration());

            builder.ApplyConfiguration(new SupplierConfiguration());

            builder.ApplyConfiguration(new OfferConfiguration());

            builder.ApplyConfiguration(new ProjectConfiguration());

            builder.ApplyConfiguration(new EmployeeConfiugration());

            builder.ApplyConfiguration(new BankConfiguration());

            builder.ApplyConfiguration(new BankAccountConfiguration());

            builder.ApplyConfiguration(new InvoiceClientConfiguration());

            builder.ApplyConfiguration(new InvoiceSupplierConfiguration());

            builder.ApplyConfiguration(new ProjectSupplierConfiguration());
        }
    }
}
