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

            builder.HasOne(c => c.Project).WithMany(s => s.Suppliers).HasForeignKey(p => p.ProjectId);

            builder.HasMany(c => c.ClientInvoices).WithOne(cc => cc.Client).HasForeignKey(cc => cc.ClientId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.SupplierInvoices).WithOne(sc => sc.Supplier).HasForeignKey(sc => sc.SupplierId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.ClientPayments).WithOne(cc => cc.Client).HasForeignKey(cc => cc.ClientId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.SupplierPayments).WithOne(sc => sc.Supplier).HasForeignKey(sc => sc.SupplierId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
