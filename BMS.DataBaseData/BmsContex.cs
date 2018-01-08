namespace BMS.DataBaseData
{
    using BMS.DataBaseData.EntityConfiguration;
    using BMS.DataBaseModels;

    using Microsoft.EntityFrameworkCore;

    public class BmsContex : DbContext
    {
        public BmsContex()
        {

        }

        public BmsContex(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Inquiry> Inquiries { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Contragent> Contragents { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(ServerConfiguration.ConfigurationString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalendarEventsConfiguration());
            modelBuilder.ApplyConfiguration(new ContragentConfiguration());
            modelBuilder.ApplyConfiguration(new InquiryConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());

        }
    }
}
