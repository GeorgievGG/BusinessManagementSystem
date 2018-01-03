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

    public class MainContragentsViewModel : ViewModelBase, IPageViewModel
    {
        private DataTable contragents;
        private DataRowView selectedContragent;

        public ICommand WindowLoadedCommand;
        public ICommand DoubleClickCommand;
        public ICommand AddNewCommand;
        public ICommand EditCommand;
        public ICommand DeleteCommand;
        public ICommand BackCommand;

        public IContragentService ContragentService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Contragents main page";
            }
        }

        public DataRowView SelectedContragent
        {
            get
            {
                return this.selectedContragent;
            }
            set
            {
                this.selectedContragent = value;
                this.OnPropertyChanged(nameof(SelectedContragent));
            }
        }

        public DataTable Contragents
        {
            get
            {
                return contragents;
            }
            private set
            {
                this.contragents = value;
                this.OnPropertyChanged(nameof(Contragents));
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
            this.Contragents = ContragentService.GetAllContragents();
        }

        private void HandleAddNewCommand(object parameter)
        {
            var addNewContragentWindow = this.ViewManager.ComposeObjects<ContragentForm>();
            addNewContragentWindow.Show();
            this.CloseAction();
        }

        private void HandleEditCommand(object parameter)
        {
            if (this.SelectedContragent == null)
            {
                MessageBox.Show("Please select a contragent to continue");
                return;
            }
            var addNewContragentWindow = this.ViewManager.ComposeObjects<ContragentForm>();
            var vm = (ContragentFormViewModel)addNewContragentWindow.DataContext;
            vm.SelectedContragent = this.SelectedContragent;
            addNewContragentWindow.Show();
            this.CloseAction();
        }

        private void HandleDeleteCommand(object parameter)
        {
            var contragentId = (int)SelectedContragent.Row.ItemArray[0];

            var result = string.Empty;

            try
            {
                result = this.ContragentService.Delete(contragentId);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            MessageBox.Show(result);
            var mainContragentsWindow = this.ViewManager.ComposeObjects<MainContragents>();
            mainContragentsWindow.Show();
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
