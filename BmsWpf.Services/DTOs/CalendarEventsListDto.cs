namespace BmsWpf.Services.DTOs
{
    using System;

    public class CalendarEventsListDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //public override string ToString()
        //{
        //    return this.Title;
        //}
    }
}
