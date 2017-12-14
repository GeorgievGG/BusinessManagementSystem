using System;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int InquiryId { get; set; }
        public Inquiry Inquiry { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        public int CreatorId { get; set; }
        public Employee Creator { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }


    }
}
