namespace BMS.DataBaseModels
{
    using System;

    using BMS.DataBaseModels.Enums;

    public class CalendarEvent
    {
        public int EventId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Color Color { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
    }
}
