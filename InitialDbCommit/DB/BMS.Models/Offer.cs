using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Offer
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }


        public int InquiryId { get; set; }

        [Required]
        public Inquiry Inquiry { get; set; }
        
        public int ClientId { get; set; }

        [Required]
        public Client Client { get; set; }

        public int CreatorId { get; set; }

        [Required]
        public Employee Creator { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }


        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
