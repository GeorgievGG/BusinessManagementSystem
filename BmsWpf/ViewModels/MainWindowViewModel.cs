namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Sessions;
    using BmsWpf.Views.ChildWindows;
    using BmsWpf.Views.Forms;
    using System;
    using System.Windows.Input;

    public class MainWindowViewModel : ViewModelBase, IPageViewModel
	{
		public ICommand ActiveProjectsCommand;
        public ICommand ContragentsCommand;
        public ICommand OffersCommand;
        public ICommand InquiriesCommand;
        public ICommand LogoutCommand;

        public Action CloseAction { get; set; }
        public IViewManager ViewManager { get; set; }

        public string ViewName
        {
            get
            {
                return "Main Window";
            }
        }

        public ICommand ActiveProjects
		{
			get
			{
				if (this.ActiveProjectsCommand == null)
				{
					this.ActiveProjectsCommand = new RelayCommand(this.HandleActiveProjectsCommand);
				}
				return this.ActiveProjectsCommand;
			}
        }

        public ICommand Contragents
        {
            get
            {
                if (this.ContragentsCommand == null)
                {
                    this.ContragentsCommand = new RelayCommand(this.HandleContragentsCommand);
                }
                return this.ContragentsCommand;
            }
        }

        public ICommand Offers
        {
            get
            {
                if (this.OffersCommand == null)
                {
                    this.OffersCommand = new RelayCommand(this.HandleOffersCommand);
                }
                return this.OffersCommand;
            }
        }

        public ICommand Inquiries
        {
            get
            {
                if (this.InquiriesCommand == null)
                {
                    this.InquiriesCommand = new RelayCommand(this.HandleInquiriesCommand);
                }
                return this.InquiriesCommand;
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

        private void HandleActiveProjectsCommand(object parameter)
        {
            var activeProjectsWindow = ViewManager.ComposeObjects<ActiveProjects>();
            activeProjectsWindow.Show();
            this.CloseAction();
        }

        private void HandleContragentsCommand(object parameter)
        {
            var contragentsWindow = ViewManager.ComposeObjects<MainContragents>();
            contragentsWindow.Show();
            this.CloseAction();
        }

        private void HandleOffersCommand(object parameter)
        {
            var offersWindow = ViewManager.ComposeObjects<MainOffers>();
            offersWindow.Show();
            this.CloseAction();
        }

        private void HandleInquiriesCommand(object parameter)
        {
            var inquiriesWindow = ViewManager.ComposeObjects<MainInquiries>();
            inquiriesWindow.Show();
            this.CloseAction();
        }

        private void HandleLogoutCommand(object parameter)
        {
            Session.Instance.Logout();
            var loginWindow = ViewManager.ComposeObjects<LoginForm>();
            loginWindow.Show();
            this.CloseAction();
        }
    }
}
