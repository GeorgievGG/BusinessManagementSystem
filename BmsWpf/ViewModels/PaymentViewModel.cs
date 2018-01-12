namespace BmsWpf.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Input;

    using BmsWpf.Behaviour;

    internal class PaymentViewModel : ViewModelBase, IPageViewModel
    {
        private int id;
        private string clientName;
        private DateTime paymentDate;
        private decimal paymentPrice;
        private decimal paymentVat;
        private decimal paymentTotal;

        private ContragentListDto selectedContragent;
        private ObservableCollection<ContragentListDto> contragents;
        private ProjectListDto selectedProject;
        private ObservableCollection<ProjectListDto> projects;

        public ICommand SelectionChangedContragentCommand;
        public ICommand WindowLoadedCommand;
        public ICommand SaveCommand;

        public DataRowView selectedPayment;

        public IPaymentService PaymentService { get; set; }
        public IProjectService ProjectService { get; set; }
        public IContragentService ContragentService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Payment form";
            }
        }

        public ContragentListDto SelectedContragent
        {
            get
            {
                return this.selectedContragent;
            }
            set
            {
                this.selectedContragent = value;
                this.OnPropertyChanged(nameof(this.SelectedContragent));
            }
        }

        public ObservableCollection<ContragentListDto> Contragents
        {
            get
            {
                return this.contragents;
            }
            set
            {
                this.contragents = value;
                this.OnPropertyChanged(nameof(this.Contragents));
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

        private void HandleWindowLoadedCommand(object parameter)
        {
               this.contragents = new ObservableCollection<ContragentListDto>(this.ContragentService.GetContragentsForDropdown());

            if (this.SelectedPayment != null)
            {
                this.Id = (int)SelectedPayment.Row.ItemArray[0];
                var contragentDto = (ContragentListDto).SelectedPayment.Row.ItemArray[1];
                this.SelectedContragent = Contragents.SingleOrDefault(x => x.Id == contragentDto.Id);
                this.PaymentDate = (DateTime)SelectedPayment.Row.ItemArray[2];
                this.PaymentPrice = (decimal)SelectedPayment.Row.ItemArray[3];
                this.PaymentVat = (decimal)SelectedPayment.Row.ItemArray[4];
                this.paymentTotal = (decimal)SelectedPayment.Row.ItemArray[5];
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
                                         ClientId = this.SelectedContragent.Id,
                                         ProjectId = this.SelectedProject.Id,
                                         Price = this.price,
                                         Vat = this.vat,
                                         Total = this.total
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
