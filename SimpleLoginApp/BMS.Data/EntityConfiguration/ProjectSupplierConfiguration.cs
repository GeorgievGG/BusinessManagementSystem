namespace WpfApp1.Data.EntityConfiguration
{
    using WpfApp1.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjectSupplierConfiguration : IEntityTypeConfiguration<ProjectSupplier>
    {
        public void Configure(EntityTypeBuilder<ProjectSupplier> builder)
        {
            builder.HasKey(e => new { e.ProjectId, e.SupplierId });

            builder.HasOne(e => e.Project)
                .WithMany(p => p.ProjectsSuppliers)
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Supplier)
                .WithMany(s => s.ProjectsSuppliers)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
