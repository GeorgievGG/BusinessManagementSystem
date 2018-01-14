namespace BmsWpf.Services.DTOs
{
    using System;

    public class InvoiceForMainInvoicesDto
    {
        public int Id { get; set; }
        public string InvoiceNum { get; set; }
        public ContragentListDto Client { get; set; }
        public ContragentListDto Supplier { get; set; }
        public ProjectListDto Project { get; set; }
        public DateTime Date { get; set; }
        public string Town { get; set; }

        public string Text { get; set; }
        public string BankRequisits { get; set; }
        public decimal Price { get; set; }
        public decimal VAT { get; set; }
        public decimal Total { get; set; }
    }
}