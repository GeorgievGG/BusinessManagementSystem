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

    public class InvoiceService : IInvoiceService
    {
        private IBmsData bmsData;

        public InvoiceService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public DataTable GetInvoicesAsDataTable()
        {
            IQueryable<IInvoice> invoices = GetAllInvoices();
            var invoicesDataTable = invoices.Select(x => new InvoiceForMainInvoicesDto
            {
                Client = new ContragentListDto
                {
                    Id = x.Client.Id,
                    NameAndIdentity = x.Client.Name
                },
                Supplier = new ContragentListDto
                {
                    Id = x.Supplier.Id,
                    NameAndIdentity = x.Supplier.Name
                },
                Project = new ProjectListDto
                {
                    Id = x.Project.Id,
                    Name = x.Project.Name
                },
                Date = x.Date,
                Price = x.Price,
                VAT = x.Vat,
                Total = x.Total
            }).ToDataTable();
            return invoicesDataTable;
        }

        private IQueryable<IInvoice> GetAllInvoices()
        {
            var invoices = new List<IInvoice>();
            invoices.AddRange(this.bmsData
                        .ClientInvoices
                        .All());
            invoices.AddRange(this.bmsData
                        .SupplierInvoices
                        .All());

            return invoices.AsQueryable();
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
            IInvoice invoice;
            if (newInvoice.ClientId == 1)//our id
            {
                invoice = new ClientInvoice()
                {
                    //CreatorId = newInquiry.CreatorId,
                    //ContragentId = newInquiry.ClientId,
                    //Description = newInquiry.Description,
                    //Date = newInquiry.Date
                };
                bmsData.ClientInvoices.Add((ClientInvoice)invoice);
            }
            else
            {
                invoice = new SupplierInvoice()
                {
                    //CreatorId = newInquiry.CreatorId,
                    //ContragentId = newInquiry.ClientId,
                    //Description = newInquiry.Description,
                    //Date = newInquiry.Date
                };
                bmsData.SupplierInvoices.Add((SupplierInvoice)invoice);
            }
            bmsData.SaveChanges();

            return $"Invoice for {invoice.Client.Name} from date {newInvoice.Date.ToShortDateString()} successfully created!";
        }

        public string EditInvoice(InvoicePostDto newInvoice)
        {
            if (newInvoice.ClientId == 1)//our id
            {
                var invoiceToUpdate = bmsData.ClientInvoices.Find(newInvoice.Id);

                //inquiryToUpdate.CreatorId = newInquiry.CreatorId;
                //inquiryToUpdate.ContragentId = newInquiry.ClientId;
                //inquiryToUpdate.Description = newInquiry.Description;
                //inquiryToUpdate.Date = newInquiry.Date;

                bmsData.ClientInvoices.Update(invoiceToUpdate);
            }
            else
            {
                var invoiceToUpdate = bmsData.SupplierInvoices.Find(newInvoice.Id);

                //inquiryToUpdate.CreatorId = newInquiry.CreatorId;
                //inquiryToUpdate.ContragentId = newInquiry.ClientId;
                //inquiryToUpdate.Description = newInquiry.Description;
                //inquiryToUpdate.Date = newInquiry.Date;

                bmsData.SupplierInvoices.Update(invoiceToUpdate);
            }
            bmsData.SaveChanges();

            return $"Inquiry with ID {newInvoice.Id} successfully updated!";
        }

        public DataTable Search(DateTime datesearch, int idSearch, string searchText)
        {
            var invoices = this.GetAllInvoices();

            var invoicesDataTable = invoices.Where(s => s.Date == datesearch || s.Client.Name == searchText || s.Id == idSearch).ToDataTable();

            return invoicesDataTable;
        }
    }
}
