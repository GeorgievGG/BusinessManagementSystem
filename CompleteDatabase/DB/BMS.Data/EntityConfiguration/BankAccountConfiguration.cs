namespace BMS.Data.EntityConfiguration
{
    using BMS.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => new { e.AccountNumber });

            builder.HasOne(e => e.Bank)
                    .WithMany(b => b.BankAccounts)
                    .HasForeignKey(e => e.BankId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Client)
                    .WithMany(c => c.BankAccounts)
                    .HasForeignKey(e => e.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Supplier)
                    .WithMany(s => s.BankAccounts)
                    .HasForeignKey(e => e.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
