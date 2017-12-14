namespace BMS.Data.EntityConfiguration
{
    using BMS.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InquiryConfiguration : IEntityTypeConfiguration<Inquiry>
    {
        public void Configure(EntityTypeBuilder<Inquiry> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Ignore(e => e.ProjectId);

            builder.Property(e => e.Date)
                .HasColumnType("DATE");

            builder.HasOne(e => e.Client)
                .WithMany(c => c.Inquiries)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
