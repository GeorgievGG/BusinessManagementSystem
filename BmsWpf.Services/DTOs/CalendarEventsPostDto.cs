namespace BmsWpf.Services.DTOs
{
    using BMS.DataBaseModels.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Windows;

    public class CalendarEventsPostDto
    {
        
        private string title;

        private string description;

        private int creatorId;

        private int projectId;

        private Color color;

        public int Id { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (value.Length < 3 || value.Length > 50 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Title have to be in range [3 - 50] symbols");
                }
                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Description have to be more then 3 symbols");
                }

                this.description = value;
            }
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if (value == 0)
                {
                    throw new ApplicationException("You have to choose a color");
                }
                this.color = value;
            }
        }

        public int CreatorId
        {
            get
            {
                return this.creatorId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ApplicationException("You haven't chosen a Creator!");
                }
                this.creatorId = value;
            }
        }
    

        public int ProjectId
        {
            get
            {
                return this.projectId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ApplicationException("You haven't chosen a project!");
                }
                this.projectId = value;
            }
        }
    }
}
