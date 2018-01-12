namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.ChildWindows;
    using BmsWpf.Views.Forms;
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Input;

    public class PFIncomeViewModel : ViewModelBase
    {
        public string TabTitle { get; protected set; }

        public PFIncomeViewModel()
        {
            TabTitle = "Income";
        }

        private DataTable invoices;
        private DataRowView selectedInvoice;

        private DataTable payments;
        private DataRowView selectedPayment;

        public ICommand WindowLoadedCommand;
        public ICommand SearchCommand;
        public ICommand AddNewSICommand;
        public ICommand EditSICommand;
        public ICommand AddNewPaymentCommand;
        public ICommand EditPaymentCommand;
        public ICommand BackCommand;

        public DataRowView SelectedProject { get; set; }
        public IInvoiceService InvoiceService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public DataRowView SelectedInvoice
        {
            get
            {
                return this.selectedInvoice;
            }
            set
            {
                this.selectedInvoice = value;
                this.OnPropertyChanged(nameof(SelectedInvoice));
            }
        }

        public DataTable Invoices
        {
            get
            {
                return invoices;
            }
            private set
            {
                this.invoices = value;
                this.OnPropertyChanged(nameof(Invoices));
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
                this.OnPropertyChanged(nameof(SelectedPayment));
            }
        }

        public DataTable Payments
        {
            get
            {
                return payments;
            }
            private set
            {
                this.payments = value;
                this.OnPropertyChanged(nameof(Payments));
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

        public ICommand AddNewSI
        {
            get
            {
                if (this.AddNewSICommand == null)
                {
                    this.AddNewSICommand = new RelayCommand(this.HandleAddNewSICommand);
                }
                return this.AddNewSICommand;
            }
        }

        public ICommand EditSI
        {
            get
            {
                if (this.EditSICommand == null)
                {
                    this.EditSICommand = new RelayCommand(this.HandleEditCommand);
                }
                return this.EditSICommand;
            }
        }

        public ICommand AddNewPayment
        {
            get
            {
                if (this.AddNewPaymentCommand == null)
                {
                    this.AddNewPaymentCommand = new RelayCommand(this.HandleAddNewPaymentCommand);
                }
                return this.AddNewPaymentCommand;
            }
        }

        public ICommand EditPayment
        {
            get
            {
                if (this.EditPaymentCommand == null)
                {
                    this.EditPaymentCommand = new RelayCommand(this.HandleEditPaymentCommand);
                }
                return this.EditPaymentCommand;
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
            this.Invoices = InvoiceService.GetProjectIncomeInvoicesAsDataTable((int)this.SelectedProject.Row.ItemArray[0]);
            //this.Invoices = PaymentService.GetIncomePaymentsAsDataTable();
        }

        private void HandleEditCommand(object parameter)
        {
            if (this.SelectedInvoice == null)
            {
                MessageBox.Show("Please select an offer to continue");
                return;
            }
            var invoiceForm = this.ViewManager.ComposeObjects<InvoiceForm>();
            var vm = (InvoiceFormViewModel)invoiceForm.DataContext;
            vm.SelectedInvoice = this.SelectedInvoice;
            invoiceForm.Show();
            this.CloseAction();
        }

        private void HandleAddNewSICommand(object parameter)
        {
            var invoiceForm = this.ViewManager.ComposeObjects<InvoiceForm>();
            var vm = (InvoiceFormViewModel)invoiceForm.DataContext;
            vm.initialSupplierId = 1;
            invoiceForm.Show();
            this.CloseAction();
        }

        private void HandleBackCommand(object parameter)
        {
            var activeProjectsWindow = this.ViewManager.ComposeObjects<ActiveProjects>();
            activeProjectsWindow.Show();
            this.CloseAction();
        }

        private void HandleAddNewPaymentCommand(object parameter)
        {
            MessageBox.Show("Not implemented");
        }

        private void HandleEditPaymentCommand(object parameter)
        {
            MessageBox.Show("Not implemented");
        }
    }
}