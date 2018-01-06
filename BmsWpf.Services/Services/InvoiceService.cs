namespace BmsWpf.Services.Services
{
    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using Microsoft.EntityFrameworkCore;
    using MoreLinq;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class InvoiceService : IInvoiceService
    {
        private IBmsData bmsData;

        public InvoiceService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public DataTable GetInvoicesAsDataTable()
        {
            IQueryable<Invoice> invoices = GetAllInvoices();
            var invoicesDataTable = invoices.Select(x => new InvoiceForMainInvoicesDto
            {
                Client = new ContragentListDto
                {
                    Id = x.ClientContragent.Id,
                    NameAndIdentity = x.ClientContragent.Name
                },
                Supplier = new ContragentListDto
                {
                    Id = x.SuplierContragent.Id,
                    NameAndIdentity = x.SuplierContragent.Name
                },
                Date = x.Date,
                Price = x.Price,
                VAT = x.Vat,
                Total = x.Total
            }).ToDataTable();
            return invoicesDataTable;
        }

        private IQueryable<Invoice> GetAllInvoices()
        {
            return this.bmsData
                        .Invoices
                        .All();
        }

        //public IEnumerable<InvoiceListDto> GetInvoicesList()
        //{
        //    var inquiries = this.bmsData
        //                .Inquiries
        //                .All();
        //    var inquiriesDtos = inquiries.Select(x => new InquiryListDto
        //    {
        //        Id = x.Id,
        //        Description = x.Description
        //    });
        //    return inquiriesDtos;
        //}

        public string Delete(int id)
        {
            var inquiry = this.bmsData.Inquiries.Find(id);

            try
            {
                this.bmsData.Inquiries.Remove(inquiry);
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
                        throw new InvalidOperationException("You cannot delete inquiry that is used in an offer!");
                    }
                }
                throw dbEx;
            }

            return $"You deleted inquiry {inquiry.Id} from {inquiry.Date.ToShortDateString()} successfully";
        }

        public string CreateInvoice(InvoicePostDto newInvoice)
        {
            var userSrv = new UserService(bmsData);
            var invoice = new Invoice()
            {
                //CreatorId = newInquiry.CreatorId,
                //ContragentId = newInquiry.ClientId,
                //Description = newInquiry.Description,
                //Date = newInquiry.Date
            };
            bmsData.Invoices.Add(invoice);
            bmsData.SaveChanges();

            return $"Invoice for {invoice.ClientContragent.Name} from date {invoice.Date.ToShortDateString()} successfully created!";
        }

        public string EditInvoice(InvoicePostDto newInvoice)
        {
            var invoiceToUpdate = bmsData.Invoices.Find(newInvoice.Id);

            //inquiryToUpdate.CreatorId = newInquiry.CreatorId;
            //inquiryToUpdate.ContragentId = newInquiry.ClientId;
            //inquiryToUpdate.Description = newInquiry.Description;
            //inquiryToUpdate.Date = newInquiry.Date;

            bmsData.Invoices.Update(invoiceToUpdate);
            bmsData.SaveChanges();

            return $"Inquiry with ID {newInvoice.Id} successfully updated!";
        }

        public DataTable Search(DateTime datesearch, int idSearch, string searchText)
        {
            var invoices = this.GetAllInvoices();

            var invoicesDataTable = invoices.Where(s => s.Date == datesearch || s.ClientContragent.Name == searchText || s.Id == idSearch).ToDataTable();

            return invoicesDataTable;
        }
    }
}
