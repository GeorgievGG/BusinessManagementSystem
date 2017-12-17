namespace WpfApp1.Data.EntityConfiguration
{
    using WpfApp1.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfiugration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .IsUnicode();

            builder.Property(e => e.LastName)
                .IsRequired()
                .IsUnicode();

            builder.Property(e => e.Username)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
