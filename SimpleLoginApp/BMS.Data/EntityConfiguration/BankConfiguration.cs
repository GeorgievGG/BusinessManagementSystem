using WpfApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WpfApp1.Data.EntityConfiguration
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => new { e.Name, e.BIC });

            builder.Property(e => e.Name)
                    .IsRequired();

            builder.Property(e => e.BIC)
                    .IsRequired();


            builder.Property(e => e.Address)
                    .IsRequired();
        }
    }
}
