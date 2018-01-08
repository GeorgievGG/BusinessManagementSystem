namespace BmsWpf.Services.UnitOfWork
{
    using BMS.DataBaseData;
    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class BmsData : IBmsData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        public BmsData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Contragent> Contragents
        {
            get { return this.GetRepository<Contragent>(); }
        }

        public IRepository<Inquiry> Inquiries
        {
            get { return this.GetRepository<Inquiry>(); }
        }

        public IRepository<Invoice> Invoices
        {
            get { return this.GetRepository<Invoice>(); }
        }

        public IRepository<Note> Notes
        {
            get { return this.GetRepository<Note>(); }
        }

        public IRepository<Offer> Offers
        {
            get { return this.GetRepository<Offer>(); }
        }

        public IRepository<Payment> Payments
        {
            get { return this.GetRepository<Payment>(); }
        }

        public IRepository<Project> Projects
        {
            get { return this.GetRepository<Project>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericEfRepository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}