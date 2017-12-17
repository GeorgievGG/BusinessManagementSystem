namespace WpfApp1.Data.EntityConfiguration
{
    using WpfApp1.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SupplierConfiguration : IEntityTypeConfiguration<Contragent>
    {
        public void Configure(EntityTypeBuilder<Contragent> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => new { e.Name, e.VatNumber });

            builder.Property(e => e.Name)
                .IsRequired()
                .IsUnicode();

            builder.Property(e => e.VatNumber)
                .IsRequired()
                .IsUnicode();

            builder.Property(e => e.PersonForContact)
                .IsRequired()
                .IsUnicode();
        }
    }
}
