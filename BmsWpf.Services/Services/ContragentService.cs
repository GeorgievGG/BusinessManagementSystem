namespace BmsWpf.Services.Services
{
    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using Microsoft.EntityFrameworkCore;
    using MoreLinq;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class ContragentService : IContragentService
    {
        private IBmsData bmsData;

        public ContragentService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public IEnumerable<ContragentListDto> GetContragentsForDropdown()
        {
            var contragentNames = bmsData.Contragents
                                    .All().Select(x => new ContragentListDto()
                                    {
                                        Id = x.Id,
                                        NameAndIdentity = x.Name + "|" + (x.PersonalIndentityNumber == null ? x.PersonalVatNumber : x.PersonalIndentityNumber)
                                    });
            return contragentNames;
        }

        public DataTable GetAllContragents()
        {
            var contragentsInfo = bmsData.Contragents
                                    .All()
                                    .Select(x => new
                                    {
                                        x.Id,
                                        x.Name,
                                        x.PersonalIndentityNumber,
                                        x.PersonalVatNumber,
                                        x.Town,
                                        x.Address,
                                        x.Telephone,
                                        x.Email,
                                        x.PersonForContact,
                                        x.BankDetails,
                                        x.Description
                                    })
                                    .ToDataTable();
            return contragentsInfo;
        }

        public ContragentInfoForInquiryDto GetClientById(int clientId)
        {
            var client = this.bmsData.Contragents.Find(clientId);

            var clientDto = new ContragentInfoForInquiryDto { Id = client.Id, Contact = client.PersonForContact, Email = client.Email, PhoneNum = client.Telephone };

            return clientDto;
        }

        public ContragentInfoForInvoiceDto GetClientByIdInvoices(int clientId)
        {
            var client = this.bmsData.Contragents.Find(clientId);

            var clientDto = new ContragentInfoForInvoiceDto
            {
                Id = client.Id,
                Name = client.Name,
                PersonalNum = client.PersonalIndentityNumber,
                VatNum = client.PersonalVatNumber,
                Town = client.Town,
                Address = client.Address,
                PersonForContact = client.PersonForContact
            };

            return clientDto;
        }

        public string Delete(int contragentId)
        {
            var contragent = this.bmsData.Contragents.Find(contragentId);

            try
            {
                this.bmsData.Contragents.Remove(contragent);
                this.bmsData.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                var innerException = dbEx.InnerException;
                if (innerException is SqlException)
                {
                    var sqlEx = (SqlException)innerException;
                    if (sqlEx.Errors.Count > 0 && sqlEx.Errors[0].Number == 547) // Foreign Key violation
                    {
                        throw new InvalidOperationException("You cannot delete contragent that is linked to another process!");
                    }
                }
                throw dbEx;
            }

            return $"You deleted contragent {contragent.Name} successfully";
        }

        public string CreateContragent(ContragentPostDto newContragent)
        {
            var userSrv = new UserService(bmsData);
            var contragent = new Contragent()
            {
                Name = newContragent.Name,
                PersonalIndentityNumber = newContragent.PersonalIndentityNumber,
                PersonalVatNumber = newContragent.PersonalVatNumber,
                Town = newContragent.Town,
                Address = newContragent.Address,
                Telephone = newContragent.Telephone,
                Email = newContragent.Email,
                PersonForContact = newContragent.PersonForContact,
                BankDetails = newContragent.BankDetails,
                Description = newContragent.Description
            };
            bmsData.Contragents.Add(contragent);
            bmsData.SaveChanges();

            return $"Contragent {newContragent.Name} successfully created!";
        }

        public string EditContragent(ContragentPostDto newContragent)
        {
            var contragentToUpdate = bmsData.Contragents.Find(newContragent.Id);

            contragentToUpdate.Name = newContragent.Name;
            contragentToUpdate.PersonalIndentityNumber = newContragent.PersonalIndentityNumber;
            contragentToUpdate.PersonalVatNumber = newContragent.PersonalVatNumber;
            contragentToUpdate.Town = newContragent.Town;
            contragentToUpdate.Address = newContragent.Address;
            contragentToUpdate.Telephone = newContragent.Telephone;
            contragentToUpdate.Email = newContragent.Email;
            contragentToUpdate.PersonForContact = newContragent.PersonForContact;
            contragentToUpdate.BankDetails = newContragent.BankDetails;
            contragentToUpdate.Description = newContragent.Description;

            bmsData.Contragents.Update(contragentToUpdate);
            bmsData.SaveChanges();

            return $"Contragent {newContragent.Name} successfully updated!";
        }
    }
}
