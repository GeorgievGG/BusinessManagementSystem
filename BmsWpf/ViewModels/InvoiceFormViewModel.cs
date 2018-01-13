namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using BmsWpf.Sessions;
    using BmsWpf.Views.ChildWindows;
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Xps.Packaging;
    using System.Xml;

    internal class InvoiceFormViewModel : ViewModelBase, IPageViewModel
    {
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
        private int invoiceNum;
        private DateTime invoiceDate;
        private string invoiceTown;
        private string invoiceText;
        private string invoiceBankRequisits;
        private decimal invoicePrice;
        private decimal invoiceVat;
        private decimal invoiceTotal;
        private ContragentListDto selectedClient;
        private ObservableCollection<ContragentListDto> clients;
        private ContragentListDto selectedSupplier;
        private ObservableCollection<ContragentListDto> suppliers;
        private ProjectListDto selectedProject;
        private ObservableCollection<ProjectListDto> projects;

        public ICommand WindowLoadedCommand;
        public ICommand SelectionChangedClientCommand;
        public ICommand SelectionChangedSupplierCommand;
        public ICommand SaveCommand;
        public ICommand PrintCommand;
        public ICommand BackCommand;

        public InvoiceFormViewModel()
        {
            this.InvoiceDate = DateTime.Now;
        }

        public DataRowView SelectedInvoice { get; set; }
        public IInvoiceService InvoiceService { get; set; }
        public IProjectService ProjectService { get; set; }
        public IContragentService ContragentService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }
        public Action LockInvoiceNumAction { get; set; }
        public Action UnlockInvoiceNumAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Invoice Form";
            }
        }

        public ContragentListDto SelectedClient
        {
            get
            {
                return this.selectedClient;
            }
            set
            {
                this.selectedClient = value;
                this.OnPropertyChanged(nameof(SelectedClient));
            }
        }
        public ObservableCollection<ContragentListDto> Clients
        {
            get
            {
                return this.clients;
            }
            set
            {
                this.clients = value;
                this.OnPropertyChanged(nameof(Clients));
            }
        }
        public ContragentListDto SelectedSupplier
        {
            get
            {
                return this.selectedSupplier;
            }
            set
            {
                this.selectedSupplier = value;
                this.OnPropertyChanged(nameof(SelectedSupplier));
            }
        }
        public ObservableCollection<ContragentListDto> Suppliers
        {
            get
            {
                return this.suppliers;
            }
            set
            {
                this.suppliers = value;
                this.OnPropertyChanged(nameof(Suppliers));
            }
        }
        public ProjectListDto SelectedProject
        {
            get
            {
                return this.selectedProject;
            }
            set
            {
                this.selectedProject = value;
                this.OnPropertyChanged(nameof(SelectedProject));
            }
        }
        public ObservableCollection<ProjectListDto> Projects
        {
            get
            {
                return this.projects;
            }
            set
            {
                this.projects = value;
                this.OnPropertyChanged(nameof(Projects));
            }
        }

        public int Id { get; set; }
        public int InitialClientId { get; set; }
        public int InitialSupplierId { get; set; }
        public int InitialProjectId { get; set; }
        public string ClientName
        {
            get
            {
                return this.clientName;
            }
            set
            {
                this.clientName = value;
                this.OnPropertyChanged(nameof(ClientName));
            }
        }
        public string ClientPersonalNumber
        {
            get
            {
                return this.clientPersonalNumber;
            }
            set
            {
                this.clientPersonalNumber = value;
                this.OnPropertyChanged(nameof(ClientPersonalNumber));
            }
        }
        public string ClientVatNumber
        {
            get
            {
                return this.clientVatNumber;
            }
            set
            {
                this.clientVatNumber = value;
                this.OnPropertyChanged(nameof(ClientVatNumber));
            }
        }
        public string ClientTown
        {
            get
            {
                return this.clientTown;
            }
            set
            {
                this.clientTown = value;
                this.OnPropertyChanged(nameof(ClientTown));
            }
        }
        public string ClientAddress
        {
            get
            {
                return this.clientAddress;
            }
            set
            {
                this.clientAddress = value;
                this.OnPropertyChanged(nameof(ClientAddress));
            }
        }
        public string ClientPersonForContact
        {
            get
            {
                return this.clientPersonForContact;
            }
            set
            {
                this.clientPersonForContact = value;
                this.OnPropertyChanged(nameof(ClientPersonForContact));
            }
        }
        public string SupplierName
        {
            get
            {
                return this.supplierName;
            }
            set
            {
                this.supplierName = value;
                this.OnPropertyChanged(nameof(SupplierName));
            }
        }
        public string SupplierPersonalNumber
        {
            get
            {
                return this.supplierPersonalNumber;
            }
            set
            {
                this.supplierPersonalNumber = value;
                this.OnPropertyChanged(nameof(SupplierPersonalNumber));
            }
        }
        public string SupplierVatNumber
        {
            get
            {
                return this.supplierVatNumber;
            }
            set
            {
                this.supplierVatNumber = value;
                this.OnPropertyChanged(nameof(SupplierVatNumber));
            }
        }
        public string SupplierTown
        {
            get
            {
                return this.supplierTown;
            }
            set
            {
                this.supplierTown = value;
                this.OnPropertyChanged(nameof(SupplierTown));
            }
        }
        public string SupplierAddress
        {
            get
            {
                return this.supplierAddress;
            }
            set
            {
                this.supplierAddress = value;
                this.OnPropertyChanged(nameof(SupplierAddress));
            }
        }
        public string SupplierPersonForContact
        {
            get
            {
                return this.supplierPersonForContact;
            }
            set
            {
                this.supplierPersonForContact = value;
                this.OnPropertyChanged(nameof(SupplierPersonForContact));
            }
        }
        public int InvoiceNum
        {
            get
            {
                return this.invoiceNum;
            }
            set
            {
                this.invoiceNum = value;
                this.OnPropertyChanged(nameof(InvoiceNum));
            }
        }
        public DateTime InvoiceDate
        {
            get
            {
                return this.invoiceDate;
            }
            set
            {
                this.invoiceDate = value;
                this.OnPropertyChanged(nameof(InvoiceDate));
            }
        }
        public string InvoiceTown
        {
            get
            {
                return this.invoiceTown;
            }
            set
            {
                this.invoiceTown = value;
                this.OnPropertyChanged(nameof(InvoiceTown));
            }
        }
        public string InvoiceText
        {
            get
            {
                return this.invoiceText;
            }
            set
            {
                this.invoiceText = value;
                this.OnPropertyChanged(nameof(InvoiceText));
            }
        }
        public string InvoiceBankRequisits
        {
            get
            {
                return this.invoiceBankRequisits;
            }
            set
            {
                this.invoiceBankRequisits = value;
                this.OnPropertyChanged(nameof(InvoiceBankRequisits));
            }
        }
        public decimal InvoicePrice
        {
            get
            {
                return this.invoicePrice;
            }
            set
            {
                this.invoicePrice = value;
                this.OnPropertyChanged(nameof(InvoicePrice));
                this.ComputeTotal(value);
            }
        }

        public decimal InvoiceVat
        {
            get
            {
                return this.invoiceVat;
            }
            set
            {
                this.invoiceVat = value;
                this.OnPropertyChanged(nameof(InvoiceVat));
            }
        }
        public decimal InvoiceTotal
        {
            get
            {
                return this.invoiceTotal;
            }
            set
            {
                this.invoiceTotal = value;
                this.OnPropertyChanged(nameof(InvoiceTotal));
            }
        }

        public ICommand WindowLoaded
        {
            get
            {
                if (this.WindowLoadedCommand == null)
                {
                    this.WindowLoadedCommand = new RelayCommand(this.HandleLoadedCommand);
                }
                return this.WindowLoadedCommand;
            }
        }

        public ICommand SelectionClientChanged
        {
            get
            {
                if (this.SelectionChangedClientCommand == null)
                {
                    this.SelectionChangedClientCommand = new RelayCommand(this.HandleSelectionChangedClientCommand);
                }
                return this.SelectionChangedClientCommand;
            }
        }

        public ICommand SelectionSupplierChanged
        {
            get
            {
                if (this.SelectionChangedSupplierCommand == null)
                {
                    this.SelectionChangedSupplierCommand = new RelayCommand(this.HandleSelectionChangedSupplierCommand);
                }
                return this.SelectionChangedSupplierCommand;
            }
        }

        public ICommand Save
        {
            get
            {
                if (this.SaveCommand == null)
                {
                    this.SaveCommand = new RelayCommand(this.HandleSaveCommand);
                }
                return this.SaveCommand;
            }
        }

        public ICommand Print
        {
            get
            {
                if (this.PrintCommand == null)
                {
                    this.PrintCommand = new RelayCommand(this.HandlePrintCommand);
                }
                return this.PrintCommand;
            }
        }

        public ICommand Back
        {
            get
            {
                if (this.BackCommand == null)
                {
                    this.BackCommand = new RelayCommand(this.HandleBackCommand);
                }
                return this.BackCommand;
            }
        }

        private void HandleLoadedCommand(object parameter)
        {
            this.Clients = new ObservableCollection<ContragentListDto>(this.ContragentService.GetContragentsForDropdown());
            this.Suppliers = new ObservableCollection<ContragentListDto>(this.ContragentService.GetContragentsForDropdown());
            this.Projects = new ObservableCollection<ProjectListDto>(this.ProjectService.GetProjectsForDropdown());
            if (this.InitialProjectId != 0)
            {
                this.SelectedProject = this.Projects.SingleOrDefault(x => x.Id == this.InitialProjectId);
            }
            if (this.InitialClientId == 1)
            {
                this.SelectedClient = this.Clients.SingleOrDefault(x => x.Id == this.InitialClientId);
                this.HandleSelectionChangedClientCommand(null);
            }
            else if (this.InitialSupplierId == 1)
            {
                this.SelectedSupplier = this.Suppliers.SingleOrDefault(x => x.Id == this.InitialSupplierId);
                this.HandleSelectionChangedSupplierCommand(null);
            }
            else if (this.SelectedInvoice != null)
            {
                this.Id = (int)SelectedInvoice.Row.ItemArray[0];
                this.InvoiceNum = (int)SelectedInvoice.Row.ItemArray[1];
                var clientDto = (ContragentListDto)SelectedInvoice.Row.ItemArray[2];
                this.SelectedClient = Clients.SingleOrDefault(x => x.Id == clientDto.Id);
                var supplierDto = (ContragentListDto)SelectedInvoice.Row.ItemArray[3];
                this.SelectedSupplier = Suppliers.SingleOrDefault(x => x.Id == supplierDto.Id);
                var projectDto = (ProjectListDto)SelectedInvoice.Row.ItemArray[4];
                if (projectDto != null)
                {
                    this.SelectedProject = Projects.SingleOrDefault(x => x.Id == projectDto.Id);
                }
                this.InvoiceDate = (DateTime)SelectedInvoice.Row.ItemArray[5];
                this.InvoiceTown = (string)(SelectedInvoice.Row.ItemArray[6] == DBNull.Value ? "" : SelectedInvoice.Row.ItemArray[6]);
                this.InvoiceText = (string)SelectedInvoice.Row.ItemArray[7];
                this.InvoiceBankRequisits = (string)(SelectedInvoice.Row.ItemArray[8] == DBNull.Value ? "" : SelectedInvoice.Row.ItemArray[8]);
                this.InvoicePrice = (decimal)SelectedInvoice.Row.ItemArray[9];
                this.InvoiceVat = (decimal)SelectedInvoice.Row.ItemArray[10];
                this.InvoiceTotal = (decimal)SelectedInvoice.Row.ItemArray[11];

                var clientId = clientDto.Id;

                var client = this.ContragentService.GetClientByIdInvoices(clientId);

                this.FillClientInformation(client);

                var supplierId = supplierDto.Id;

                var supplier = this.ContragentService.GetClientByIdInvoices(supplierId);

                this.FillSupplierInformation(supplier);
            }
            if (this.SelectedSupplier != null && this.SelectedSupplier.Id == 1)
            {
                if (this.SelectedInvoice == null) //isNotEditForm
                {
                    this.InvoiceNum = InvoiceService.GetNextInvoiceNum();
                }
                this.LockInvoiceNumAction();
            }
            else
            {
                this.UnlockInvoiceNumAction();
            }
        }

        private void HandlePrintCommand(object parameter)
        {
            var printDialog = new PrintDialog();
            printDialog.ShowDialog();


        }

        private void HandleBackCommand(object parameter)
        {
            this.RedirectToPreviousWindow();
        }

        private void HandleSelectionChangedClientCommand(object parameter)
        {
            if (this.SelectedClient != null)
            {
                var client = this.ContragentService.GetClientByIdInvoices(this.SelectedClient.Id);

                FillClientInformation(client);
            }
        }

        private void HandleSelectionChangedSupplierCommand(object parameter)
        {
            var supplier = this.ContragentService.GetClientByIdInvoices(this.SelectedSupplier.Id);
            FillSupplierInformation(supplier);
            if (this.SelectedSupplier.Id == 1)
            {
                if (this.SelectedInvoice == null) //isEditForm
                {
                    this.InvoiceNum = InvoiceService.GetNextInvoiceNum();
                }
                this.LockInvoiceNumAction();
            }
            else
            {
                this.UnlockInvoiceNumAction();
            }
        }

        private void HandleSaveCommand(object parameter)
        {
            var result = string.Empty;
            try
            {
                var newInvoice = new InvoicePostDto()
                {
                    Id = this.Id,
                    InvoiceNum = this.InvoiceNum,
                    Town = this.InvoiceTown,
                    Text = this.InvoiceText,
                    BankRequisits = this.InvoiceBankRequisits,
                    ClientId = this.SelectedClient.Id,
                    SupplierId = this.SelectedSupplier.Id,
                    ProjectId = this.SelectedProject.Id,
                    Date = this.InvoiceDate,
                    Price = this.InvoicePrice,
                    Vat = this.InvoiceVat,
                    Total = this.InvoiceTotal
                };

                if (this.SelectedInvoice == null)
                {
                    result = this.InvoiceService.CreateInvoice(newInvoice);
                    MessageBox.Show(result);
                    this.RedirectToPreviousWindow();
                }
                else
                {
                    result = this.InvoiceService.EditInvoice(newInvoice);
                    MessageBox.Show(result);
                    this.RedirectToPreviousWindow();
                }
            }
            catch (Exception e)
            {
                result = e.Message;
                MessageBox.Show(result);
            }
        }

        private void FillClientInformation(ContragentInfoForInvoiceDto client)
        {
            this.ClientName = client.Name;
            this.ClientPersonalNumber = client.PersonalNum;
            this.ClientVatNumber = client.VatNum;
            this.ClientTown = client.Town;
            this.ClientAddress = client.Address;
            this.ClientPersonForContact = client.PersonForContact;
        }

        private void FillSupplierInformation(ContragentInfoForInvoiceDto supplier)
        {
            this.SupplierName = supplier.Name;
            this.SupplierPersonalNumber = supplier.PersonalNum;
            this.SupplierVatNumber = supplier.VatNum;
            this.SupplierTown = supplier.Town;
            this.SupplierAddress = supplier.Address;
            this.SupplierPersonForContact = supplier.PersonForContact;
        }

        private void ComputeTotal(decimal value)
        {
            this.InvoiceVat = value * 0.2m;
            this.InvoiceTotal = value + this.InvoiceVat;
        }

        private void RedirectToPreviousWindow()
        {
            if (Session.Instance.LastOpenWindow == "MainInvoices")
            {
                var previousWindow = this.ViewManager.ComposeObjects<MainInvoices>();
                previousWindow.Show();
            }
            this.CloseAction();
        }
    }
}