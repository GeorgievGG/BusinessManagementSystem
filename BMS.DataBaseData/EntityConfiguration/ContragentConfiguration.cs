namespace BMS.DataBaseData.EntityConfiguration
{
    using BMS.DataBaseModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContragentConfiguration:IEntityTypeConfiguration<Contragent>
    {
        public void Configure(EntityTypeBuilder<Contragent> builder)
        {
            builder.Property(a => a.Address).IsUnicode();
            builder.Property(d => d.Description).IsUnicode();
            builder.Property(n => n.Name).IsUnicode();
            builder.Property(p => p.PersonForContact).IsUnicode();



            builder.HasOne(p => p.Project).WithMany(s => s.Suppliers).HasForeignKey(p => p.ProjectId);

            builder.HasMany(c => c.ClientInvoices).WithOne(c => c.ClientContragent).HasForeignKey(c => c.ContragentId);

            builder.HasMany(c => c.SupplierInvoices).WithOne(s => s.SuplierContragent).HasForeignKey(s => s.ContragentId);

            builder.HasMany(p => p.ClientPayments).WithOne(s => s.ClientContragent).HasForeignKey(c => c.ContragentId);

            builder.HasMany(c => c.SupplierPayments).WithOne(s => s.SuplierContragent).HasForeignKey(s => s.ContragentId);
        }
    }
}
