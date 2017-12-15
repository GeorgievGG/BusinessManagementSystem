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
        public Inquiry Inquiry { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
