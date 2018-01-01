using System.Collections.Generic;
using BmsWpf.Services.DTOs;

namespace BmsWpf.Services.Contracts
{
    public interface IContragentService
    {
        IEnumerable<ContragentListDto> GetAllContragents();
        ContragentInfoForInquiryDto GetClientById(int clientId);
    }
}