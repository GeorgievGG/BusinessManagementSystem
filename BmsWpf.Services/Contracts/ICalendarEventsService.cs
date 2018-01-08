namespace BmsWpf.Services.Contracts
{
    using BmsWpf.Services.DTOs;
    using System.Collections.Generic;

    public interface ICalendarEventsService
    {
        IEnumerable<CalendarEventsMainWindowDto> GetMainCalendarEventsInfo();
        IEnumerable<CalendarEventsListDto> GetInquiriesList();
        string Delete(int id);
        string CreateCalendarEvent(CalendarEventsPostDto newCalendarEvent);
        string EditCalendarEvent(CalendarEventsPostDto newCalendarEvent);
    }
}
