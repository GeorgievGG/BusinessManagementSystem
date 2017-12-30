namespace BMS.DataBaseModels
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Projects = new List<Project>();
            this.Inquiries = new List<Inquiry>();
            this.Offers = new List<Offer>();
            this.Events = new List<CalendarEvent>();

        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ClearenceType Type { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Inquiry> Inquiries { get; set; }
        public ICollection<CalendarEvent> Events { get; set; }
    }
}
