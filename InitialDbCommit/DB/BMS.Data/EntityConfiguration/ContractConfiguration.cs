namespace BMS.Data.EntityConfiguration
{
    using BMS.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Date)
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(e => e.Description)
                .IsRequired(false)
                .IsUnicode();

            builder.Property(e => e.ProjectId)
                .IsRequired(false);

            builder.HasOne(e => e.Inquiry)
                .WithMany(i => i.Contracts)
                .HasForeignKey(e => e.InquiryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Offer)
                .WithMany(o => o.Contracts)
                .HasForeignKey(e => e.OfferId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Client)
                .WithMany(c => c.Contracts)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Creator)
                .WithMany(c => c.CreatedContracts)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
