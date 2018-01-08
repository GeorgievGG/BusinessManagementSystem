namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.Forms;
    using System;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    public class MainInvoicesViewModel : ViewModelBase, IPageViewModel
    {
        private DataTable invoices;
        private DataRowView selectedInvoice;

        public ICommand WindowLoadedCommand;
        public ICommand SearchCommand;
        public ICommand AddNewCICommand;
        public ICommand AddNewSICommand;
        public ICommand EditCommand;
        public ICommand BackCommand;

        public MainInvoicesViewModel()
        {
            this.SearchText = "Search....";
        }

        public string Text { get; set; }

        public IInvoiceService InvoiceService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Invoices main page";
            }
        }

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

        public string SearchText { get; set; }

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

        public ICommand Search
        {
            get
            {
                if (this.SearchCommand == null)
                {
                    this.SearchCommand = new RelayCommand(this.HandleSearchCommand);
                }
                return this.SearchCommand;
            }
        }

        public ICommand AddNewCI
        {
            get
            {
                if (this.AddNewCICommand == null)
                {
                    this.AddNewCICommand = new RelayCommand(this.HandleAddNewCICommand);
                }
                return this.AddNewCICommand;
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

        public ICommand Edit
        {
            get
            {
                if (this.EditCommand == null)
                {
                    this.EditCommand = new RelayCommand(this.HandleEditCommand);
                }
                return this.EditCommand;
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
            this.Invoices = InvoiceService.GetInvoicesAsDataTable();
        }

        private void HandleSearchCommand(object parameter)
        {
            var datesearch = DateTime.Now;
            DateTime.TryParseExact(this.SearchText, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datesearch);
            var idSearch = 0;
            int.TryParse(this.SearchText, out idSearch);
            var found = this.InvoiceService.Search(datesearch, idSearch, this.SearchText);
        }

        private void HandleAddNewCICommand(object parameter)
        {
            var invoiceForm = this.ViewManager.ComposeObjects<InvoiceForm>();
            var vm = (InvoiceFormViewModel)invoiceForm.DataContext;
            vm.initialClientId = 1;
            invoiceForm.Show();
            this.CloseAction();
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
            var mainWindow = this.ViewManager.ComposeObjects<MainWindow>();
            mainWindow.Show();
            this.CloseAction();
        }
    }
}
