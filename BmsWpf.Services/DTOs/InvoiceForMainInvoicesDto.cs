using System;
using BmsWpf.Services.DTOs;

namespace BmsWpf.Services.DTOs
{
    internal class InvoiceForMainInvoicesDto
    {
        public ContragentListDto Client { get; set; }
        public ContragentListDto Supplier { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal VAT { get; set; }
        public decimal Total { get; set; }
    }
}