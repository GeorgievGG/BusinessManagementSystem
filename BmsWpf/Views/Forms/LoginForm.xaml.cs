namespace BmsWpf.Views.Forms
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(IBmsData bmsData, IViewManager viewManager, IUserService userService)
        {
            InitializeComponent();

            LoginFormViewModel vm = (LoginFormViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.BmsData = bmsData;
            vm.ViewManager = viewManager;
            vm.UserService = userService;
        }
    }
}
