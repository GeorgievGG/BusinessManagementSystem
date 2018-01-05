namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.Forms;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class MainInvoicesViewModel : ViewModelBase, IPageViewModel
    {
        private DataTable invoices;
        private DataRowView selectedInvoice;

        public ICommand WindowLoadedCommand;
        public ICommand DoubleClickCommand;
        public ICommand AddNewCICommand;
        public ICommand EditCICommand;
        public ICommand AddNewSICommand;
        public ICommand EditSICommand;
        public ICommand DeleteCommand;
        public ICommand BackCommand;

        public IOfferService OfferService { get; set; }
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

        public ICommand DoubleClick
        {
            get
            {
                if (this.DoubleClickCommand == null)
                {
                    this.DoubleClickCommand = new RelayCommand(this.HandleEditCommand);
                }
                return this.DoubleClickCommand;
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

        public ICommand EditCI
        {
            get
            {
                if (this.EditCICommand == null)
                {
                    this.EditCICommand = new RelayCommand(this.HandleEditCICommand);
                }
                return this.EditCICommand;
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
                    this.EditSICommand = new RelayCommand(this.HandleEditSICommand);
                }
                return this.EditSICommand;
            }
        }

        public ICommand Delete
        {
            get
            {
                if (this.DeleteCommand == null)
                {
                    this.DeleteCommand = new RelayCommand(this.HandleDeleteCommand);
                }
                return this.DeleteCommand;
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

        private void HandleAddNewCICommand(object parameter)
        {
            var addNewInquiryWindow = this.ViewManager.ComposeObjects<InvoiceClientForm>();
            addNewInquiryWindow.Show();
            this.CloseAction();
        }

        private void HandleEditCICommand(object parameter)
        {
            if (this.SelectedOffer == null)
            {
                MessageBox.Show("Please select an offer to continue");
                return;
            }
            var addNewInquiryWindow = this.ViewManager.ComposeObjects<InvoiceClientForm>();
            var vm = (OfferFormViewModel)addNewInquiryWindow.DataContext;
            vm.SelectedOffer = this.selectedOffer;
            addNewInquiryWindow.Show();
            this.CloseAction();
        }

        private void HandleAddNewSICommand(object parameter)
        {
            var addNewInquiryWindow = this.ViewManager.ComposeObjects<InvoinceSupplierForm>();
            addNewInquiryWindow.Show();
            this.CloseAction();
        }

        private void HandleEditSICommand(object parameter)
        {
            if (this.SelectedOffer == null)
            {
                MessageBox.Show("Please select an offer to continue");
                return;
            }
            var addNewInquiryWindow = this.ViewManager.ComposeObjects<InvoinceSupplierForm>();
            var vm = (OfferFormViewModel)addNewInquiryWindow.DataContext;
            vm.SelectedOffer = this.selectedOffer;
            addNewInquiryWindow.Show();
            this.CloseAction();
        }

        private void HandleDeleteCommand(object parameter)
        {
            var offerId = (int)selectedOffer.Row.ItemArray[0];

            var result = string.Empty;

            try
            {
                result = this.OfferService.Delete(offerId);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            MessageBox.Show(result);
        }

        private void HandleBackCommand(object parameter)
        {
            var mainWindow = this.ViewManager.ComposeObjects<MainWindow>();
            mainWindow.Show();
            this.CloseAction();
        }
    }
}
