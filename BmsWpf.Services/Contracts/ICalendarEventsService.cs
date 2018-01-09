namespace BmsWpf.Services.Contracts
{
    using BmsWpf.Services.DTOs;
    using System.Collections.Generic;
    using System.Data;

    public interface ICalendarEventsService
    {
        DataTable GetCalendarEventsAsDataTable();
        IEnumerable<CalendarEventsListDto> GetInquiriesList();
        string Delete(int id);
        string CreateCalendarEvent(CalendarEventsPostDto newCalendarEvent);
        string EditCalendarEvent(CalendarEventsPostDto newCalendarEvent);
    }
}
