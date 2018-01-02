namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.Forms;
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Input;

    public class MainOffersViewModel : ViewModelBase, IPageViewModel
    {
        private DataTable offers;
        private DataRowView selectedOffer;

        public ICommand WindowLoadedCommand;
        public ICommand DoubleClickCommand;
        public ICommand AddNewCommand;
        public ICommand EditCommand;
        public ICommand DeleteCommand;
        public ICommand BackCommand;

        public IOfferService OfferService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Offers main page";
            }
        }

        public DataRowView SelectedOffer
        {
            get
            {
                return this.selectedOffer;
            }
            set
            {
                this.selectedOffer = value;
                this.OnPropertyChanged(nameof(SelectedOffer));
            }
        }

        public DataTable Offers
        {
            get
            {
                return offers;
            }
            private set
            {
                this.offers = value;
                this.OnPropertyChanged(nameof(Offers));
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

        public ICommand AddNew
        {
            get
            {
                if (this.AddNewCommand == null)
                {
                    this.AddNewCommand = new RelayCommand(this.HandleAddNewCommand);
                }
                return this.AddNewCommand;
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
            this.Offers = OfferService.GetOffersAsDataTable();
        }

        private void HandleAddNewCommand(object parameter)
        {
            var addNewInquiryWindow = this.ViewManager.ComposeObjects<OfferForm>();
            addNewInquiryWindow.Show();
            this.CloseAction();
        }

        private void HandleEditCommand(object parameter)
        {
            var addNewInquiryWindow = this.ViewManager.ComposeObjects<OfferForm>();
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
