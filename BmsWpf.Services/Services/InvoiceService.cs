namespace BmsWpf.Services.Services
{
    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using MoreLinq;
    using System;
    using System.Data;
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
            var invoicesDataTable = this.GetInvoiceDtos().ToDataTable();

            return invoicesDataTable;
        }

        public DataTable GetProjectIncomeInvoicesAsDataTable(int projectId)
        {
            var invoices = this.GetInvoiceDtos();
            var invoicesDataTable = invoices.Where(x => x.Supplier.Id == 1 && x.Project.Id == projectId).ToDataTable();

            return invoicesDataTable;
        }

        public DataTable GetProjectExpenseInvoicesAsDataTable(int projectId)
        {
            var invoicesDataTable = this.GetInvoiceDtos().Where(x => x.Client.Id == 1 && x.Project.Id == projectId).ToDataTable();

            return invoicesDataTable;
        }

        private IQueryable<InvoiceForMainInvoicesDto> GetInvoiceDtos()
        {
            IQueryable<Invoice> invoices = GetAllInvoices();
            var invoicesDataTable = invoices.Select(x => new InvoiceForMainInvoicesDto
            {
                Id = x.Id,
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
                InvoiceNum = x.InvoiceNum,
                Town = x.Town,
                Text = x.Text,
                BankRequisits = x.BankRequisits,
                Price = x.Price,
                VAT = x.Vat,
                Total = x.Total
            });
            return invoicesDataTable;
        }

        private IQueryable<Invoice> GetAllInvoices()
        {
            var invoices = this.bmsData
                        .Invoices
                        .All();

            return invoices;
        }

        public string CreateInvoice(InvoicePostDto newInvoice)
        {
            var userSrv = new UserService(bmsData);
            Invoice invoice;

            invoice = new Invoice()
            {
                InvoiceNum = newInvoice.InvoiceNum,
                ClientId = newInvoice.ClientId,
                SupplierId = newInvoice.SupplierId,
                ProjectId = newInvoice.ProjectId,
                Date = newInvoice.Date,
                Town = newInvoice.Town,
                Text = newInvoice.Text,
                BankRequisits = newInvoice.BankRequisits,
                Price = newInvoice.Price,
                Vat = newInvoice.Vat,
                Total = newInvoice.Total
            };
            bmsData.Invoices.Add(invoice);

            bmsData.SaveChanges();

            return $"Invoice with number {newInvoice.InvoiceNum} from date {newInvoice.Date.ToShortDateString()} successfully created!";
        }

        public string EditInvoice(InvoicePostDto newInvoice)
        {
            var invoiceToUpdate = bmsData.Invoices.Find(newInvoice.Id);

            invoiceToUpdate.InvoiceNum = newInvoice.InvoiceNum;
            invoiceToUpdate.ClientId = newInvoice.ClientId;
            invoiceToUpdate.SupplierId = newInvoice.SupplierId;
            invoiceToUpdate.ProjectId = newInvoice.ProjectId;
            invoiceToUpdate.Date = newInvoice.Date;
            invoiceToUpdate.Town = newInvoice.Town;
            invoiceToUpdate.Text = newInvoice.Text;
            invoiceToUpdate.BankRequisits = newInvoice.BankRequisits;
            invoiceToUpdate.Price = newInvoice.Price;
            invoiceToUpdate.Vat = newInvoice.Vat;
            invoiceToUpdate.Total = newInvoice.Total;

            bmsData.Invoices.Update(invoiceToUpdate);

            bmsData.SaveChanges();

            return $"Invoice with Serial Number {newInvoice.InvoiceNum} successfully updated!";
        }

        public DataTable Search(DateTime datesearch, int idSearch, string searchText)
        {
            var invoices = this.GetAllInvoices();

            var invoicesDataTable = invoices.Where(s => s.Date == datesearch || s.Client.Name == searchText || s.Id == idSearch).ToDataTable();

            return invoicesDataTable;
        }

        public int GetNextInvoiceNum()
        {
            var invoices = this.bmsData.Invoices.All().Where(x => x.SupplierId == 1);

            var invoicesLastId = invoices.Max(x => x.InvoiceNum);

            return invoicesLastId + 1;
        }
    }
}
