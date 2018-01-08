namespace BmsWpf.Services.DTOs
{
    using System;

    public class InvoicePostDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public int SupplierId { get; set; }
        public int ProjectId { get; set; }

        public int InvoiceNum { get; set; }
        public DateTime Date { get; set; }
        public string Town { get; set; }
        public string Text { get; set; }
        public string BankRequisits { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }
    }
}