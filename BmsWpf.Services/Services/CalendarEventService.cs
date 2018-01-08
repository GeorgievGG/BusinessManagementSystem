namespace BmsWpf.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;

    using Microsoft.EntityFrameworkCore;

    public class CalendarEventService : ICalendarEventsService
    {
        private IBmsData bmsData;

        public CalendarEventService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }
        public IEnumerable<CalendarEventsMainWindowDto> GetMainCalendarEventsInfo()
        {
            var calendarEvents = this.bmsData.CalendarEvents.All();

            var calendarEventsDtos = calendarEvents.Select(
                x => new CalendarEventsMainWindowDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Color = x.Color,
                    Creator = new UserListDto()
                                  {
                                      Id = x.Creator.Id,
                                      Username = x.Creator.Username
                                  },
                });
            return calendarEventsDtos;
        }

        public IEnumerable<CalendarEventsListDto> GetInquiriesList()
        {
            var calendarEvents = this.bmsData.CalendarEvents.All();
            var calendarEventsDtos = calendarEvents.Select(
                x => new CalendarEventsListDto()
                {
                    Description = x.Dexcription,
                    Title = x.Title,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                });
            return calendarEventsDtos;
        }

        public string Delete(int id)
        {
            var calendarEvent = this.bmsData.CalendarEvents.Find(id);
            try
            {
                this.bmsData.CalendarEvents.Remove(calendarEvent);
                this.bmsData.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {

                var innerException = dbEx.InnerException;
                if (innerException is SqlException)
                {
                    var sqlEx = (SqlException)innerException;
                    if (sqlEx.Errors.Count > 0)
                    {
                        throw new InvalidOperationException("You cannot delete this event!");
                    }
                }
                throw dbEx;
            }
            return $"You deleted event {calendarEvent.Id} from {calendarEvent.Title} successfully";
        }

        public string CreateCalendarEvent(CalendarEventsPostDto newCalendarEvent)
        {
            var userSrv = new UserService(bmsData);
            var calendarEvent = new CalendarEvent()
                                    {
                                        Title = newCalendarEvent.Title,
                                        Description = newCalendarEvent.Description,
                                        Color = newCalendarEvent.Color,
                                        StartTime = newCalendarEvent.StartDate,
                                        EndTime = newCalendarEvent.EndDate,
                                        CreatorId = newCalendarEvent.CreatorId,
                                    };
            this.bmsData.CalendarEvents.Add(calendarEvent);
            this.bmsData.SaveChanges();

            return $"Event {newCalendarEvent.Title} was created!";
        }

        public string EditCalendarEvent(CalendarEventsPostDto newCalendarEvent)
        {
            var calendarEventToUpdate = this.bmsData.CalendarEvents.Find(newCalendarEvent.Id);

            calendarEventToUpdate.Title = newCalendarEvent.Title;
            calendarEventToUpdate.Description = newCalendarEvent.Description;
            calendarEventToUpdate.StartDate = newCalendarEvent.StartDate;
            calendarEventToUpdate.EndDate = newCalendarEvent.EndDate;
            calendarEventToUpdate.Creator = newCalendarEvent.CreatorId;
            calendarEventToUpdate.Color = newCalendarEvent.Color;

            return $"Event {newCalendarEvent.Title} was successfully updated!";
        }
    }
}
