namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Sessions;
    using BmsWpf.Views.Admin;
    using BmsWpf.Views.Forms;
    using System;
    using System.Windows.Input;

    public class AdminPanelViewModel : ViewModelBase, IPageViewModel
    {
        public ICommand AddNewUserCommand;
        public ICommand ManageUsersCommand;
        public ICommand LogoutCommand;

        public Action CloseAction { get; set; }

        public IBmsData BmsData { get; set; }
        public IViewManager ViewManager { get; set; }

        public string ViewName
        {
            get
            {
                return "Admin Panel";
            }
        }

        public ICommand AddNewUser
        {
            get
            {
                if (this.AddNewUserCommand == null)
                {
                    this.AddNewUserCommand = new RelayCommand(this.HandleAddNewUserCommand);
                }
                return this.AddNewUserCommand;
            }
        }

        public ICommand ManageUsers
        {
            get
            {
                if (this.ManageUsersCommand == null)
                {
                    this.ManageUsersCommand = new RelayCommand(this.HandleManageUsersCommand);
                }
                return this.ManageUsersCommand;
            }
        }

        public ICommand Logout
        {
            get
            {
                if (this.LogoutCommand == null)
                {
                    this.LogoutCommand = new RelayCommand(this.HandleLogoutCommand);
                }
                return this.LogoutCommand;
            }
        }

        public void HandleCloseAppCommand(object parameter)
        {
            Environment.Exit(0);
        }

        private void HandleAddNewUserCommand(object sender)
        {
            var addUserView = this.ViewManager.ComposeObjects<AddUser>();
            addUserView.Show();
            this.CloseAction();
        }

        private void HandleManageUsersCommand(object sender)
        {
            var manageUsersView = this.ViewManager.ComposeObjects<ManageUser>();
            manageUsersView.Show();
            this.CloseAction();
        }

        private void HandleLogoutCommand(object sender)
        {
            var loginForm = this.ViewManager.ComposeObjects<LoginForm>();
            Session.Instance.Logout();
            loginForm.Show();
            this.CloseAction();
        }
    }
}
