namespace BmsWpf.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using BmsWpf.Sessions;
    using BmsWpf.Views.ChildWindows;



    internal class PaymentViewModel : ViewModelBase, IPageViewModel
    {
        private int id;
        private string clientName;
        private DateTime paymentDate;
        private decimal paymentPrice;
        private decimal paymentVat;
        private decimal paymentTotal;

        private ContragentListDto selectedClient;
        private ObservableCollection<ContragentListDto> clients;
        private ContragentListDto selectedSupplier;
        private ObservableCollection<ContragentListDto> suppliers;
        private ProjectListDto selectedProject;
        private ObservableCollection<ProjectListDto> projects;

        public ICommand WindowLoadedCommand;
        public ICommand SelectionChangedContragentCommand;
        public ICommand SelectionChangedSupplierCommand;
        public ICommand SaveCommand;

        public DataRowView selectedPayment;

        public IUserService UserService { get; set; }
        public IPaymentService PaymentService { get; set; }
        public IProjectService ProjectService { get; set; }
        public IContragentService ContragentService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public PaymentViewModel()
        {
            this.PaymentDate = DateTime.Now;
        }

        public string ViewName
        {
            get
            {
                return "Payment form";
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
                this.OnPropertyChanged(nameof(this.SelectedClient));
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
                this.OnPropertyChanged(nameof(this.Clients));
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
                this.OnPropertyChanged(nameof(this.SelectedSupplier));
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
                this.OnPropertyChanged(nameof(this.Suppliers));
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
                this.OnPropertyChanged(nameof(this.Projects));
            }
        }

        public int InitialClientId { get; set; }
        public int InitialSupplierId { get; set; }
        public int InitialProjectId { get; set; }
        public int Id { get; set; }
        public DateTime PaymentDate
        {
            get
            {
                return this.paymentDate;
            }
            set
            {
                this.paymentDate = value;
                this.OnPropertyChanged(nameof(this.PaymentDate));
            }
        }

        public decimal PaymentPrice
        {
            get
            {
                return this.paymentPrice;
            }
            set
            {
                this.paymentPrice = value;
                this.OnPropertyChanged(nameof(PaymentPrice));
              
            }
        }

        public decimal PaymentVat
        {
            get
            {
                return this.paymentVat;
            }
            set
            {
                this.PaymentVat = value;
                this.OnPropertyChanged(nameof(this.PaymentVat));
            }
        }

        public decimal PaymentTotal
        {
            get
            {
                return this.paymentTotal;
            }
            set
            {
                this.PaymentTotal = value;
                this.OnPropertyChanged(nameof(this.PaymentTotal));
            }
        }

        public ICommand WindowLoaded
        {
            get
            {
                if (this.WindowLoadedCommand == null)
                {
                    this.WindowLoadedCommand = new RelayCommand(this.HandleWindowLoadedCommand);
                }
                return this.WindowLoaded;

            }
        }

        public DataRowView SelectedPayment
        {
            get
            {
                return this.selectedPayment;
            }
            set
            {
                this.selectedPayment = value;
                this.OnPropertyChanged(nameof(this.SelectedPayment));
            }
        }

        private void HandleWindowLoadedCommand(object parameter)
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
             
            }
            else if (this.InitialSupplierId == 1)
            {
                this.SelectedSupplier = this.Suppliers.SingleOrDefault(x => x.Id == this.InitialSupplierId);
                
            }
            if (this.SelectedPayment != null)
            {
                this.Id = (int)this.SelectedPayment.Row.ItemArray[0];
                var clientDto = (ContragentListDto)this.SelectedPayment.Row.ItemArray[2];
                this.SelectedClient = this.Clients.SingleOrDefault(x => x.Id == clientDto.Id);
                var supplierDto = (ContragentListDto)this.SelectedPayment.Row.ItemArray[3];
                this.SelectedSupplier = this.Suppliers.SingleOrDefault(x => x.Id == supplierDto.Id);
                var projectDto = (ProjectListDto)this.SelectedPayment.Row.ItemArray[4];
                if (projectDto != null)
                {
                    this.SelectedProject = this.Projects.SingleOrDefault(x => x.Id == projectDto.Id);
                }
                this.PaymentDate = (DateTime)this.SelectedPayment.Row.ItemArray[2];
                this.PaymentPrice = (decimal)this.SelectedPayment.Row.ItemArray[3];
                this.PaymentVat = (decimal)this.SelectedPayment.Row.ItemArray[4];
                this.paymentTotal = (decimal)this.SelectedPayment.Row.ItemArray[5];
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

        private void HandleSaveCommand(object parameter)
        {
            var result = string.Empty;
            try
            {
                var newPayment = new PaymentPostDto
                                     {
                                         Id = this.Id,
                                         ClientId = this.SelectedClient.Id,
                                         SupplierId = this.SelectedSupplier.Id,
                                         ProjectId = this.SelectedProject.Id,
                                         Price = this.PaymentPrice,
                                         Vat = this.PaymentVat,
                                         Total = this.PaymentTotal
                                     };
                if (this.SelectedPayment == null)
                {
                    result = this.PaymentService.CreatePayment(newPayment);
                    MessageBox.Show(result);
                    this.CloseAction();
                }
                else
                {
                    result = this.PaymentService.EditPayment(newPayment);
                    MessageBox.Show(result);
                    this.CloseAction();
                }
            }
            catch (Exception e)
            {
                result = e.Message;
                MessageBox.Show(result);
            }
        }


    }
}
