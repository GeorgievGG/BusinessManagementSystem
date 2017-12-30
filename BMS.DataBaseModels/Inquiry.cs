namespace BMS.DataBaseModels
{
    using System;

    public class Inquiry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ContragentId { get; set; }
        public Contragent Contragent { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }

    }
}
