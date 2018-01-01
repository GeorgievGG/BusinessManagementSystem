namespace BmsWpf.Services.Services
{
    using BmsWpf.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using MoreLinq;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using BmsWpf.Services.DTOs;
    using BMS.DataBaseModels;

    public class OfferService : IOfferService
    {
        private IBmsData bmsData;

        public OfferService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public DataTable GetOffersAsDataTable()
        {
            var offers = this.bmsData
                            .Offers
                            .All();
            var dataTable = offers.Select(x => new
            {
                Id = x.Id,
                Creator = new UserListDto()
                {
                    Id = x.Creator.Id,
                    Username = x.Creator.Username
                },
                Client = new ContragentListDto()
                {
                    Id = x.Contragent.Id,
                    NameAndIdentity = x.Contragent.Name + "|" + (x.Contragent.PersonalIndentityNumber == null ? x.Contragent.PersonalVatNumber : x.Contragent.PersonalIndentityNumber)
                },
                InquiryID = new InquiryListDto()
                {
                    Id = x.Inquiry.Id,
                    Description = x.Inquiry.Description
                },
                x.Description,
                x.Date
            })
                                    .ToDataTable();
            return dataTable;
        }

        public string Delete(int id)
        {
            var offer = this.bmsData.Offers.Find(id);

            try
            {
                this.bmsData.Offers.Remove(offer);
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
                        throw new InvalidOperationException("You cannot delete offer that is a part of a project!");
                    }
                    throw dbEx;
                }
            }

            return $"You deleted offer {offer.Id} from {offer.Date.ToShortDateString()} successfully";
        }

        public string CreateOffer(OfferPostDto newOffer)
        {
            var offer = new Offer()
            {
                ContragentId = newOffer.ClientId,
                CreatorId = newOffer.CreatorId,
                InquiryId = newOffer.InquiryId,
                Description = newOffer.Description,
                Date = newOffer.Date
            };

            this.bmsData.Offers.Add(offer);
            this.bmsData.SaveChanges();

            return $"Offer \"{newOffer.Description}\" from date {newOffer.Date.ToShortDateString()} successfully created!";
        }

        public string EditOffer(OfferPostDto newOffer)
        {
            var offer = bmsData.Offers.Find(newOffer.Id);

            offer.InquiryId = newOffer.InquiryId;
            offer.CreatorId = newOffer.CreatorId;
            offer.ContragentId = newOffer.ClientId;
            offer.Description = newOffer.Description;
            offer.Date = newOffer.Date;

            this.bmsData.Offers.Update(offer);
            this.bmsData.SaveChanges();

            return $"Offer with Id: {newOffer.Id} successfully updated!";
        }
    }
}
