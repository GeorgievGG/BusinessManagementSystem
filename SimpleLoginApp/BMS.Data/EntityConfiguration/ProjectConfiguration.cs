namespace WpfApp1.Data.EntityConfiguration
{
    using WpfApp1.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.Name);

            builder.Property(e => e.Name)
                .IsRequired()
                .IsUnicode();

            builder.Property(e => e.StartDate)
                .HasColumnType("DATE");

            builder.Property(e => e.DeadLine)
                .HasColumnType("DATE");

            builder.Property(e => e.EndDate)
                .HasColumnType("DATE")
                .IsRequired(false);

            builder.HasOne(e => e.Employee)
                .WithMany(e => e.Projects)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Client)
                .WithMany(c => c.ProjectsClient)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
