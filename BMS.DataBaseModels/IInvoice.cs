using System;

namespace BMS.DataBaseModels
{
    public interface IInvoice
    {
        Contragent Client { get; set; }
        int ClientId { get; set; }
        DateTime Date { get; set; }
        int Id { get; set; }
        decimal Price { get; set; }
        Project Project { get; set; }
        int ProjectId { get; set; }
        Contragent Supplier { get; set; }
        int SupplierId { get; set; }
        decimal Total { get; set; }
        decimal Vat { get; set; }
    }
}