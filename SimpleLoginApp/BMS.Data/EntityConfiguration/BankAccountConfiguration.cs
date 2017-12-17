namespace WpfApp1.Data.EntityConfiguration
{
    using WpfApp1.Models;
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

            builder.HasOne(e => e.Contragent)
                    .WithMany(s => s.BankAccounts)
                    .HasForeignKey(e => e.ContragentId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
