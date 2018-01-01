namespace BmsWpf.Services.Contracts
{
    using BmsWpf.Services.DTOs;
    using System.Data;

    public interface IOfferService
    {
        string Delete(int id);
        DataTable GetOffersAsDataTable();
        string CreateOffer(OfferPostDto newOffer);
        string EditOffer(OfferPostDto newOffer);
    }
}