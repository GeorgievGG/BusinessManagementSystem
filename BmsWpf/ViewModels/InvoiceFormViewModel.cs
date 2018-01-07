namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using BmsWpf.Views.ChildWindows;
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    internal class InvoiceFormViewModel : ViewModelBase, IPageViewModel
    {
        private int id;
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
        public IUserService UserService { get; set; }
        public IProjectService ProjectService { get; set; }
        public IContragentService ContragentService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

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

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                this.OnPropertyChanged(nameof(Id));
            }
        }
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
        public string InvoiceNum
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
            if (this.SelectedInvoice != null)
            {
                this.Id = (int)SelectedInvoice.Row.ItemArray[0];
                var clientDto = (ContragentListDto)SelectedInvoice.Row.ItemArray[1];
                this.SelectedClient = Clients.SingleOrDefault(x => x.Id == clientDto.Id);
                var supplierDto = (ContragentListDto)SelectedInvoice.Row.ItemArray[2];
                this.SelectedSupplier = Suppliers.SingleOrDefault(x => x.Id == supplierDto.Id);
                var projectDto = (ProjectListDto)SelectedInvoice.Row.ItemArray[3];
                if (projectDto != null)
                {
                    this.SelectedProject = Projects.SingleOrDefault(x => x.Id == projectDto.Id);
                }
                this.InvoiceDate = (DateTime)SelectedInvoice.Row.ItemArray[4];
                this.InvoicePrice = (decimal)SelectedInvoice.Row.ItemArray[5];
                this.InvoiceVat = (decimal)SelectedInvoice.Row.ItemArray[6];
                this.InvoiceTotal = (decimal)SelectedInvoice.Row.ItemArray[7];

                var clientId = clientDto.Id;

                var client = this.ContragentService.GetClientByIdInvoices(clientId);

                this.ClientName = client.Name;
                this.ClientPersonalNumber = client.PersonalNum;
                this.ClientVatNumber = client.VatNum;
                this.ClientTown = client.Town;
                this.ClientAddress = client.Address;
                this.ClientPersonForContact = client.PersonForContact;

                var supplierId = supplierDto.Id;

                var supplier = this.ContragentService.GetClientByIdInvoices(supplierId);

                this.SupplierName = supplier.Name;
                this.SupplierPersonalNumber = supplier.PersonalNum;
                this.SupplierVatNumber = supplier.VatNum;
                this.SupplierTown = supplier.Town;
                this.SupplierAddress = supplier.Address;
                this.SupplierPersonForContact = supplier.PersonForContact;
            }
        }

        private void HandleSaveCommand(object parameter)
        {
            var result = string.Empty;
            var newInvoice = new InvoicePostDto()
            {
                Id = this.Id,
                ClientId = this.SelectedClient.Id,
                SupplierId = this.SelectedSupplier.Id,
                ProjectId = this.SelectedProject.Id,
                Date = this.InvoiceDate,
                Price = this.InvoicePrice,
                Vat = this.InvoiceVat,
                Total = this.InvoiceTotal
            };
            try
            {
                if (this.SelectedInvoice == null)
                {
                    result = this.InvoiceService.CreateInvoice(newInvoice);
                }
                else
                {
                    result = this.InvoiceService.EditInvoice(newInvoice);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            MessageBox.Show(result);
            this.RedirectToMainInquiries();
        }

        private void HandlePrintCommand(object parameter)
        {
            throw new NotImplementedException();
        }

        private void HandleBackCommand(object parameter)
        {
            this.RedirectToMainInquiries();
        }

        private void HandleSelectionChangedClientCommand(object parameter)
        {
            if (this.SelectedClient != null)
            {
                var client = this.ContragentService.GetClientByIdInvoices(this.SelectedClient.Id);

                this.ClientName = client.Name;
                this.ClientPersonalNumber = client.PersonalNum;
                this.ClientVatNumber = client.VatNum;
                this.ClientTown = client.Town;
                this.ClientAddress = client.Address;
                this.ClientPersonForContact = client.PersonForContact;
            }
        }

        private void HandleSelectionChangedSupplierCommand(object parameter)
        {
            var supplier = this.ContragentService.GetClientByIdInvoices(this.SelectedSupplier.Id);

            this.SupplierName = supplier.Name;
            this.SupplierPersonalNumber = supplier.PersonalNum;
            this.SupplierVatNumber = supplier.VatNum;
            this.SupplierTown = supplier.Town;
            this.SupplierAddress = supplier.Address;
            this.SupplierPersonForContact = supplier.PersonForContact;
        }

        private void RedirectToMainInquiries()
        {
            var mainInquiriesWindow = this.ViewManager.ComposeObjects<MainInvoices>();
            mainInquiriesWindow.Show();
            this.CloseAction();
        }
    }
}