using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BmsWpf.Annotations;
using BmsWpf.Behaviour;
using BmsWpf.Views.Forms;

namespace BmsWpf.ViewModels
{
	public class MainWindowViewModel : ViewModelBase, IPageViewModel
	{
		public ICommand ClientCommand;

		public Action CloseAction { get; set; }

		public string Name { get; }

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
