namespace BMS.DataBaseData.EntityConfiguration
{
    using BMS.DataBaseModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InquiryConfiguration:IEntityTypeConfiguration<Inquiry>
    {
        public void Configure(EntityTypeBuilder<Inquiry> builder)
        {
            builder.Property(d => d.Description).IsUnicode();

        }
    }
}
