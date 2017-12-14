namespace BMS.Data.EntityConfiguration
{
    using BMS.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => new { e.Name, e.VatNumber });

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.VatNumber)
                .IsRequired();


        }
    }
}
