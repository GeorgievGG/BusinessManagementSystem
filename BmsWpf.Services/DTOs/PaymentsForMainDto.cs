namespace BmsWpf.Services.DTOs
{
    using System;

    public class PaymentsForMainDto
    {
        public int Id { get; set; }
        public ContragentListDto Client { get; set; }
        public ContragentListDto Supplier { get; set; }
        public ProjectListDto Project { get; set; }
        public string Date { get; set; }
        public decimal Price { get; set; }
        public decimal VAT { get; set; }
        public decimal Total { get; set; }
    }
}
