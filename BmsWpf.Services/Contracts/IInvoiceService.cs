using System;
using System.Data;
using BmsWpf.Services.DTOs;

namespace BmsWpf.Services.Contracts
{
    public interface IInvoiceService
    {
        string CreateInvoice(InvoicePostDto newInvoice);
        string Delete(int id);
        string EditInvoice(InvoicePostDto newInvoice);
        DataTable GetInvoicesAsDataTable();
        DataTable Search(DateTime datesearch, int idSearch, string searchText);
    }
}