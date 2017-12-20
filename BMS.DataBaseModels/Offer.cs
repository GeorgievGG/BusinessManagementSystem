namespace BMS.DataBaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int? InquiryId { get; set; }
        public Inquiry Inquiry { get; set; }

        public int ClientId { get; set; }
        public Contragent Client { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }
    }
}
