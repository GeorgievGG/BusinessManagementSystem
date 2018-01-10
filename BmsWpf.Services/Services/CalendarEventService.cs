namespace BmsWpf.Services.Services
{
    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using Microsoft.EntityFrameworkCore;
    using MoreLinq;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class CalendarEventService : ICalendarEventService
    {
        private IBmsData bmsData;

        public CalendarEventService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public DataTable GetCalendarEventsAsDataTable()
        {
            //IQueryable<CalendarEvent> calendarEvents = this.GetAllCalendarEvents();

            var calendarEvents = this.bmsData.CalendarEvents.All();

            var calendarEventsDataTable = calendarEvents.Select(
                x => new CalendarEventsMainWindowDto()
                {
                    Id = x.EventId,
                    Title = x.Title,
                    Description = x.Description,
                    StartDate = x.StartTime,
                    EndDate = x.EndTime,
                    Color = x.Color,
                    Creator = new UserListDto()
                    {
                        Id = x.Creator.Id,
                        Username = x.Creator.Username
                    },
                    Project = new ProjectListDto
                    {
                        Id = x.Project.Id,
                        Name = x.Project.Name
                    },
                }).ToDataTable();

            return calendarEventsDataTable;
        }

        //private IQueryable<CalendarEvent> GetAllCalendarEvents()
        //{
        //    var calendarEvents = this.bmsData.CalendarEvents.All();
        //    return calendarEvents;
        //}

        public IEnumerable<CalendarEventsListDto> GetEventsList()
        {
            var calendarEvents = this.bmsData.CalendarEvents.All();
            var calendarEventsDtos = calendarEvents.Select(
                x => new CalendarEventsListDto()
                {
                    Id = x.EventId, //Added event ID to the DTO
                    Description = x.Description,
                    Title = x.Title,
                    StartDate = x.StartTime,
                    EndDate = x.EndTime,
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
            return $"You deleted event {calendarEvent.EventId} from {calendarEvent.Title} successfully";
        }

        public string CreateCalendarEvent(CalendarEventsPostDto newCalendarEvent)
        {
            var userSrv = new UserService(bmsData);
            var calendarEvent = new CalendarEvent()
            {
                EventId = newCalendarEvent.Id,
                Title = newCalendarEvent.Title,
                Description = newCalendarEvent.Description,
                Color = newCalendarEvent.Color,
                StartTime = newCalendarEvent.StartDate,
                EndTime = newCalendarEvent.EndDate,
                CreatorId = newCalendarEvent.CreatorId,
                ProjectId = newCalendarEvent.ProjectId,
            };
            this.bmsData.CalendarEvents.Add(calendarEvent);
            this.bmsData.SaveChanges();

            return $"Event {newCalendarEvent.Title} was created!";
        }

        public string EditCalendarEvent(CalendarEventsPostDto newCalendarEvent)
        {
            var calendarEventToUpdate = this.bmsData.CalendarEvents.Find(newCalendarEvent.Id);
            var creator = this.bmsData.Users.Find(newCalendarEvent.CreatorId);

            calendarEventToUpdate.Title = newCalendarEvent.Title;
            calendarEventToUpdate.Description = newCalendarEvent.Description;
            calendarEventToUpdate.StartTime = newCalendarEvent.StartDate;
            calendarEventToUpdate.EndTime = newCalendarEvent.EndDate;
            calendarEventToUpdate.Creator = creator;
            calendarEventToUpdate.Color = newCalendarEvent.Color;

            this.bmsData.CalendarEvents.Update(calendarEventToUpdate);
            this.bmsData.SaveChanges();
            return $"Event {newCalendarEvent.Title} was successfully updated!";
        }
    }
}
