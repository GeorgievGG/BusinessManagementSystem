using System;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1.Models
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
        public Contragent Client { get; set; }
    }
}
