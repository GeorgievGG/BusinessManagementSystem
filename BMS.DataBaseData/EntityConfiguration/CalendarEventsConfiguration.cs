namespace BMS.DataBaseData.EntityConfiguration
{
    using BMS.DataBaseModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

   public class CalendarEventsConfiguration :IEntityTypeConfiguration<CalendarEvent>
    {
        public void Configure(EntityTypeBuilder<CalendarEvent> builder)
        {

            builder.HasKey(e => e.EventId);
            builder.Property(t => t.Title).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(d => d.Description).IsRequired().IsUnicode().HasMaxLength(350);
            builder.Property(s => s.StartTime).IsRequired();
            builder.Property(s => s.EndTime).IsRequired();

        }
    }
}
