using System;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1.Models
{
    public class InvoiceSupplier
    {
        public int Id { get; set; }

        [RegularExpression(@"^\d{10}$")]
        public string InvoiceNumber { get; set; }

        public DateTime Date { get; set; }

        public int SupplierId { get; set; }

        [Required]
        public Contragent Supplier { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal VAT { get; set; }
    }
}
