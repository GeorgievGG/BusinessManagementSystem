namespace BmsWpf.Services.Contracts
{
    using System.Collections.Generic;
    using BmsWpf.Services.DTOs;
    using System.Data;

    public interface IContragentService
    {
        DataTable GetAllContragents();
        IEnumerable<ContragentListDto> GetContragentsForDropdown();
        ContragentInfoForInquiryDto GetClientById(int clientId);
        ContragentInfoForInvoiceDto GetClientByIdInvoices(int clientId);
        string Delete(int contragentId);
        string CreateContragent(ContragentPostDto newContragent);
        string EditContragent(ContragentPostDto newContragent);
    }
}