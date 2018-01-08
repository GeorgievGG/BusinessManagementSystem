namespace BmsWpf.Services.Contracts
{
    using System.Collections.Generic;

    using BmsWpf.Services.DTOs;

    public interface ICalendarEventsService
    {
        IEnumerable<CalendarEventsMainWindowDto> GetMainCalendarEventsInfo();
        IEnumerable<CalendarEventsListDto> GetInquiriesList();
        string Delete(int id);
        string CreateCalendarEvent(CalendarEventsPostDto newCalendarEvent);
        string EditCalendarEvent(CalendarEventsPostDto newCalendarEvent);
    }
}
