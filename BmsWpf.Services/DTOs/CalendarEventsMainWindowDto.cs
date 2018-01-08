namespace BmsWpf.Services.DTOs
{
    using System;
    using BMS.DataBaseModels.Enums;

    public class CalendarEventsMainWindowDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Color Color { get; set; }
        public UserListDto Creator { get; set; }
    }
}
