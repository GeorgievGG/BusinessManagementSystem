namespace BMS.Data.EntityConfiguration
{
    using BMS.Models;
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
                .WithMany(c => c.Invoices)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Project)
                .WithMany(p => p.InvoicesClient)
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
