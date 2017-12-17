namespace WpfApp1.Data.EntityConfiguration
{
    using WpfApp1.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InvoiceSupplierConfiguration : IEntityTypeConfiguration<InvoiceSupplier>
    {
        public void Configure(EntityTypeBuilder<InvoiceSupplier> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.InvoiceNumber);

            builder.Property(e => e.InvoiceNumber)
                .IsRequired();

            builder.Property(e => e.Date)
                .HasColumnType("DATE");

            builder.HasOne(e => e.Supplier)
                .WithMany(s => s.InvoiceSuppliers)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
