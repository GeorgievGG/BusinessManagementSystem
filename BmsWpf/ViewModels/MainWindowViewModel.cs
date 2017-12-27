namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Views.Forms;
    using System;
    using System.Windows.Input;

    public class MainWindowViewModel : ViewModelBase, IPageViewModel
	{
		public ICommand ClientCommand;

		public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Main Window";
            }
        }

        public ICommand Client
		{
			get
			{
				if (this.ClientCommand == null)
				{
					this.ClientCommand = new RelayCommand(this.HandleClientCommand);
				}
				return this.ClientCommand;
			}
		}

		private void HandleClientCommand(object parameter)
		{
			var contragent = new ContragentForm();
			contragent.Show();


			//CloseAction(); 
		}
	}
}
