namespace BmsWpf.ViewModels
{
    using BMS.DataBaseModels;
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Sessions;
    using BmsWpf.Views.Admin;
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    //To be added: Validation, Redirect to User/Admin menu
    public class LoginFormViewModel : ViewModelBase, IPageViewModel
    {
        public ICommand LoginCommand;
        public ICommand CloseCommand;

        public Action CloseAction { get; set; }

        public IBmsData BmsData { get; set; }
        public IViewManager ViewManager { get; set; }

        public string Username { get; set; }

        public string Name
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

        public void HandleLoginCommand(object parameter)
        {
            var box = (PasswordBox)parameter;
            var pass = box.Password;
            var hashedPass = HashToSha1(pass);

            Session.Instance.SetBmsData(this.BmsData);

            var userService = Session.Instance.UserService;

            try
            {
                var type = userService.LoginUser(this.Username, hashedPass);
                RedirectDependingOnUserType(type);

                Session.Instance.SetUsername(this.Username);

                CloseAction();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private static void RedirectDependingOnUserType(ClearenceType type)
        {
            if (type == ClearenceType.Admin)
            {
                var adminWindow = new AdminPanel();
                adminWindow.Show();
            }
            else
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }

        public void HandleCloseAppCommand(object parameter)
        {
            Environment.Exit(0);
        }

        private static string HashToSha1(string pass)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

    }
}
