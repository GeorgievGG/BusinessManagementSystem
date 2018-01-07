namespace BmsWpf.Services.Contracts
{
    using BMS.DataBaseModels;
    using BmsWpf.Services.DTOs;
    using System.Collections.Generic;
    using System.Data;

    public interface IInquiryService
    {
        DataTable GetMainInquiriesInfo();
        IEnumerable<InquiryListDto> GetInquiriesList();
        string Delete(int id);
        string CreateInquiry(InquiryPostDto newInquiry);
        string EditInquiry(InquiryPostDto newInquiry);
    }
}