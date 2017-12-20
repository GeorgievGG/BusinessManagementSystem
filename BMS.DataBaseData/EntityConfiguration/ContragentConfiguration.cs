namespace BMS.DataBaseData.EntityConfiguration
{
    using BMS.DataBaseModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContragentConfiguration:IEntityTypeConfiguration<Contragent>
    {
        public void Configure(EntityTypeBuilder<Contragent> builder)
        {
            builder.HasOne(p => p.Project).WithMany(s => s.Suppliers).HasForeignKey(p => p.ProjectId);

            builder.HasMany(c => c.ClientInvoices).WithOne(c => c.Client).HasForeignKey(c => c.ClientId);

            builder.HasMany(c => c.SupplierInvoices).WithOne(s => s.Supplier).HasForeignKey(s => s.SupplierId);

            builder.HasMany(p => p.ClientPayments).WithOne(s => s.Client).HasForeignKey(c => c.ClientId);

            builder.HasMany(c => c.SupplierPayments).WithOne(s => s.Supplier).HasForeignKey(s => s.SupplierId);
        }
    }
}
