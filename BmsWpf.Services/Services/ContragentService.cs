namespace BmsWpf.Services.Services
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using System.Collections.Generic;
    using System.Linq;

    public class ContragentService : IContragentService
    {
        private IBmsData bmsData;

        public ContragentService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public IEnumerable<ContragentListDto> GetAllContragents()
        {
            var contragentNames = bmsData.Contragents
                                    .All().Select(x => new ContragentListDto()
                                    {
                                        Id = x.Id,
                                        NameAndIdentity = x.Name + "|" + (x.PersonalIndentityNumber == null ? x.PersonalVatNumber : x.PersonalIndentityNumber)
                                    });
            return contragentNames;
        }

        public ContragentInfoForInquiryDto GetClientById(int clientId)
        {
            var client = this.bmsData.Contragents.Find(clientId);

            var clientDto = new ContragentInfoForInquiryDto { Id = client.Id, Contact = client.PersonForContact, Email = client.Email, PhoneNum = client.Telephone };

            return clientDto;
        }
    }
}
