namespace WpfApp1.Data.EntityConfiguration
{
    using WpfApp1.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .IsRequired()
                .IsUnicode();

            builder.HasOne(e => e.Inquiry)
                .WithMany(i => i.Offers)
                .HasForeignKey(e => e.InquiryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Employee)
                .WithMany(c => c.CreatedOffers)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
