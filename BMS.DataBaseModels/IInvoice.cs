using System;

namespace BMS.DataBaseModels
{
    public interface IInvoice
    {
        int Id { get; set; }

        Contragent Client { get; set; }
        int ClientId { get; set; }

        Contragent Supplier { get; set; }
        int SupplierId { get; set; }

        Project Project { get; set; }
        int? ProjectId { get; set; }

        DateTime Date { get; set; }
        string Text { get; set; }
        string BankRequisits { get; set; }
        decimal Price { get; set; }
        decimal Total { get; set; }
        decimal Vat { get; set; }
    }
}