using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using WpfApp1.Behaviour;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private ICommand loginCommand;
        private string message;

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        //This is for testing purposes and should be deleted after you connect the service to the database
        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
                //This triggers change notification so the messega would appear in the UI
                this.OnPropertyChanged("Message");
            }
        }

        //This is how you implement methods for buttons - a property fires the method execution
        public ICommand Login
        {
            get
            {
                if (this.loginCommand == null)
                {
                    this.loginCommand = new RelayCommand(this.HandleLoginCommand);
                }
                return this.loginCommand;
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
