using System.Data;

namespace BmsWpf.ViewModels
{
    internal class InvoiceClientFormViewModel
    {
        public DataRowView SelectedInvoice { get; internal set; }
        public string ClientName { get => clientName; set => clientName = value; }
        public string ClientPersonalNumber { get => clientPersonalNumber; set => clientPersonalNumber = value; }
        public string ClientVatNumber { get => clientVatNumber; set => clientVatNumber = value; }
        public string ClientTown { get => clientTown; set => clientTown = value; }
        public string ClientAddress { get => clientAddress; set => clientAddress = value; }
        public string ClientPersonForContact { get => clientPersonForContact; set => clientPersonForContact = value; }
        public string SupplierName { get => supplierName; set => supplierName = value; }
        public string SupplierPersonalNumber { get => supplierPersonalNumber; set => supplierPersonalNumber = value; }
        public string SupplierVatNumber { get => supplierVatNumber; set => supplierVatNumber = value; }
        public string SupplierTown { get => supplierTown; set => supplierTown = value; }
        public string SupplierAddress { get => supplierAddress; set => supplierAddress = value; }
        public string SupplierPersonForContact { get => supplierPersonForContact; set => supplierPersonForContact = value; }
        public string InvoiceNum { get => invoiceNum; set => invoiceNum = value; }
        public string InvoiceDate { get => invoiceDate; set => invoiceDate = value; }
        public string InvoiceTown { get => invoiceTown; set => invoiceTown = value; }
        public string InvoiceText { get => invoiceText; set => invoiceText = value; }
        public string InvoiceBankRequisits { get => invoiceBankRequisits; set => invoiceBankRequisits = value; }

        private string clientName;
        private string clientPersonalNumber;
        private string clientVatNumber;
        private string clientTown;
        private string clientAddress;
        private string clientPersonForContact;
        private string supplierName;
        private string supplierPersonalNumber;
        private string supplierVatNumber;
        private string supplierTown;
        private string supplierAddress;
        private string supplierPersonForContact;
        private string invoiceNum;
        private string invoiceDate;
        private string invoiceTown;
        private string invoiceText;
        private string invoiceBankRequisits;
    }
}