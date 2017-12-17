namespace WpfApp1.Data.EntityConfiguration
{
    using WpfApp1.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class InvoiceClientConfiguration : IEntityTypeConfiguration<InvoiceClient>
    {
        public void Configure(EntityTypeBuilder<InvoiceClient> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.InvoiceNumber);

            builder.Property(e => e.InvoiceNumber)
                .IsRequired();

            builder.Property(e => e.Date)
                .HasColumnType("DATE");

            builder.HasOne(e => e.Client)
                .WithMany(c => c.InvoiceClients)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
