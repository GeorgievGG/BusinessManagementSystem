namespace BmsWpf.ViewModels
{
    using BMS.DataBaseModels;
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Sessions;
    using BmsWpf.Views.Admin;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    //To be added: Validation, Redirect to User/Admin menu
    public class LoginFormViewModel : ViewModelBase, IPageViewModel
    {
        public ICommand LoginCommand;
        public ICommand CloseCommand;

        public Action CloseAction { get; set; }
        
        public IViewManager ViewManager { get; set; }
        public IUserService UserService { get; set; }

        public string Username { get; set; }

        public string ViewName
        {
            get
            {
                return "Login Form";
            }
        }

        public ICommand Login
        {
            get
            {
                if (this.LoginCommand == null)
                {
                    this.LoginCommand = new RelayCommand(this.HandleLoginCommand);
                }
                return this.LoginCommand;
            }
        }

        public ICommand CloseApp
        {
            get
            {
                if (this.CloseCommand == null)
                {
                    this.CloseCommand = new RelayCommand(this.HandleCloseAppCommand);
                }
                return this.CloseCommand;
            }
        }

        private void HandleLoginCommand(object parameter)
        {
            var box = (PasswordBox)parameter;
            var pass = box.Password;
            var hashedPass = this.UserService.HashToSha1(pass);

            try
            {
                var cleareanceType = this.UserService.LoginUser(this.Username, hashedPass);
                RedirectDependingOnUserType(cleareanceType);

                Session.Instance.SetUsername(this.Username);

                CloseAction();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void HandleCloseAppCommand(object parameter)
        {
            Environment.Exit(0);
        }

        private void RedirectDependingOnUserType(ClearenceType type)
        {
            if (type == ClearenceType.Admin)
            {
                var adminWindow = this.ViewManager.ComposeObjects<AdminPanel>();
                adminWindow.Show();
            }
            else
            {
                var mainWindow = this.ViewManager.ComposeObjects<MainWindow>();
                mainWindow.Show();
            }
        }
    }
}
