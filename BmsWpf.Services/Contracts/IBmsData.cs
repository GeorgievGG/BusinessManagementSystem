using BMS.DataBaseModels;
using BmsWpf.Services.Repositories;

namespace BmsWpf.Services.Contracts
{

    public interface IBmsData
    {
        IRepository<Contragent> Contragents { get; }

        IRepository<Inquiry> Inquiries { get; }

        IRepository<Invoice> Invoices { get; }

        IRepository<Note> Notes { get; }
        
        IRepository<Offer> Offers { get; }
        
        IRepository<Payment> Payments { get; }
        
        IRepository<Project> Projects { get; }
        
        IRepository<User> Users { get; }
        
        void SaveChanges();
    }
}
