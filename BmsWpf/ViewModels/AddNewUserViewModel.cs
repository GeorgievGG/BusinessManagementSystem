namespace BmsWpf.ViewModels
{
    using BMS.DataBaseModels;
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.Admin;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public class AddUserViewModel : ViewModelBase, IPageViewModel
    {
        public ICommand SaveCommand;
        public ICommand BackCommand;
        private readonly ObservableCollection<ClearenceType> clearenceTypes;

        public AddUserViewModel()
        {
            var typesList = Enum.GetValues(typeof(ClearenceType)).Cast<ClearenceType>().ToList();
            this.clearenceTypes = new ObservableCollection<ClearenceType>(typesList);
            this.SelectedClearenceType = ClearenceType.User;
        }

        public Action CloseAction { get; set; }
        
        public IViewManager ViewManager { get; set; }
        public IUserService UserService { get; set; }

        public string ViewName
        {
            get
            {
                return "Login Form";
            }
        }

        public string Username { get; set; }

        public ObservableCollection<ClearenceType> ClearenceTypes
        {
            get
            {
                return this.clearenceTypes;
            }
        }

        public ClearenceType SelectedClearenceType
        {
            get;
            set;
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

        private void HandleSaveCommand(object parameter)
        {
            var passInfo = (List<object>)parameter;
            var password = ((PasswordBox)passInfo[0]).Password;
            var repeatedPass = ((PasswordBox)passInfo[1]).Password;

            if (password != repeatedPass)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            try
            {
                var result = UserService.CreateUser(this.Username, password, this.SelectedClearenceType);

                MessageBox.Show(result);

                AdminPanel dash = ViewManager.ComposeObjects<AdminPanel>();
                dash.Show();
                this.CloseAction();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void HandleBackCommand(object parameter)
        {
            var adminPanel = ViewManager.ComposeObjects<AdminPanel>();
            adminPanel.Show();
            this.CloseAction();
        }
    }
}
