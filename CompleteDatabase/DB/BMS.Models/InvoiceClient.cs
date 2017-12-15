using System;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class InvoiceClient
    {
        public int Id { get; set; }

        [RegularExpression(@"^\d{10}$")]
        public string InvoiceNumber { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal VAT { get; set; }

        public int ClientId { get; set; }

        [Required]
        public Client Client { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
