﻿namespace BmsWpf.Services.DTOs
{
    using BMS.DataBaseModels.Enums;
    using System;

    public class CalendarEventsPostDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Color Color { get; set; }
        public int CreatorId { get; set; }
        public int ProjectId { get; set; }
    }
}