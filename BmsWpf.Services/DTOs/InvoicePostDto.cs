namespace BmsWpf.Services.DTOs
{
    using System;

    public class InvoicePostDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int SupplierId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }
    }
}