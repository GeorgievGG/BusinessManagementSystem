namespace BmsWpf.Services.Contracts
{
    using BmsWpf.Services.DTOs;
    using System.Collections.Generic;
    using System.Data;

    public interface ICalendarEventService
    {
        DataTable GetCalendarEventsAsDataTable();
        IEnumerable<CalendarEventsListDto> GetEventsList();
        string Delete(int id);
        string CreateCalendarEvent(CalendarEventsPostDto newCalendarEvent);
        string EditCalendarEvent(CalendarEventsPostDto newCalendarEvent);
    }
}
