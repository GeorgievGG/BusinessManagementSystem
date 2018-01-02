namespace BmsWpf.ViewModels
{
    using BMS.DataBaseModels;
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.Admin;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    public class ManageUserViewModel : ViewModelBase, IPageViewModel
    {
        private ObservableCollection<string> users;
        private readonly ObservableCollection<ClearenceType> clearenceTypes;
        private ClearenceType selectedClearenceType;
        private string selectedUserString;

        public ICommand WindowLoadedCommand;
        public ICommand SelectionChangedCommand;
        public ICommand SaveCommand;
        public ICommand BackCommand;
        private string username;

        public ManageUserViewModel()
        {
            var typesList = Enum.GetValues(typeof(ClearenceType)).Cast<ClearenceType>().ToList();
            this.clearenceTypes = new ObservableCollection<ClearenceType>(typesList);
        }

        public IUserService UserService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Manage User";
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
                this.OnPropertyChanged(nameof(Username));
            }
        }

        public string SelectedUserString
        {
            get
            {
                return this.selectedUserString;
            }
            set
            {
                this.selectedUserString = value;
            }
        }

        public ClearenceType SelectedClearenceType
        {
            get
            {
                return this.selectedClearenceType;
            }
            set
            {
                this.selectedClearenceType = value;
                this.OnPropertyChanged(nameof(SelectedClearenceType));
            }
        }

        public ObservableCollection<string> Users
        {
            get
            {
                return users;
            }
            private set
            {
                this.users = value;
                this.OnPropertyChanged(nameof(Users));
            }
        }

        public ObservableCollection<ClearenceType> ClearenceTypes
        {
            get
            {
                return this.clearenceTypes;
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

        public ICommand SelectionChanged
        {
            get
            {
                if (this.SelectionChangedCommand == null)
                {
                    this.SelectionChangedCommand = new RelayCommand(this.HandleSelectionChangedCommand);
                }
                return this.SelectionChangedCommand;
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
            this.Users = new ObservableCollection<string>(UserService.GetUsers());
        }

        private void HandleSelectionChangedCommand(object parameter)
        {
            if (this.SelectedUserString != null)
            {
                var selectedUserStringParams = this.SelectedUserString.Split('|');
                var username = selectedUserStringParams[0];
                var type = selectedUserStringParams[1];
                this.SelectedClearenceType = (ClearenceType)Enum.Parse(typeof(ClearenceType), type);
                this.Username = username;
            }
        }

        private void HandleSaveCommand(object parameter)
        {
            var result = this.UserService.ModifyUser(this.Username, this.SelectedClearenceType);
            MessageBox.Show(result);
            this.Users = new ObservableCollection<string>(UserService.GetUsers());
        }

        private void HandleBackCommand(object parameter)
        {
            var adminPanel = this.ViewManager.ComposeObjects<AdminPanel>();
            adminPanel.Show();
            this.CloseAction();
        }
    }
}
