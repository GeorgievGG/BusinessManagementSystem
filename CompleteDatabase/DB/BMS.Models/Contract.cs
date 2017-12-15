using System;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
