namespace BMS.DataBaseModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ClientInvoice : IInvoice
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime Date { get; set; }

        public string Text { get; set; }
        public string BankRequisits { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }

        public int ClientId { get; set; }
        public Contragent Supplier { get; set; }
        public int SupplierId { get; set; }
        public Contragent Client { get; set; }
        public int? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
