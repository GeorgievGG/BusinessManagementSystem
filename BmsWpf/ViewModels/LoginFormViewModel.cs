namespace BmsWpf.ViewModels
{
    using System;
    using System.Windows.Input;
    using System.Windows.Controls;

    using BmsWpf.Behaviour;
    using BmsWpf.Services;

    public class LoginFormViewModel : ViewModelBase, IPageViewModel
    {
        public ICommand LoginCommand;
        private string Message;
        public string Password { get; set; }

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

        public void HandleLoginCommand(object parameter)
        {
            this.Message = $"Successful login for user {this.Username} with password {parameter}";

            //Change to SHA1
            var hashedPass = parameter.ToString();

            var userService = new UserService();

            userService.LoginUser(this.Username, hashedPass);
        }

        public void Close()
        {
            Environment.Exit(0);
        }

    }
}
