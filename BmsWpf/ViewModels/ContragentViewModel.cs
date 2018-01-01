using System.Windows;
using BmsWpf.Views.Admin;
using BmsWpf.Views.Forms;

namespace BmsWpf.ViewModels
{
	using BMS.DataBaseData;
	using BMS.DataBaseModels;
	using BmsWpf.Behaviour;
	using System;
	using System.Windows.Input;

	public class ContragentViewModel : ViewModelBase, IPageViewModel
	{
		public ICommand SaveCommand;
		public ICommand BackCommand;

		public Action CloseAction { get; set; }

		public string ViewName
		{
			get
			{
				return "Contragent View";
			}
		}

		public string Name { get; set; }

		public string PersonalVatNumber { get; set; }

		public string PersonalIndentityNumber { get; set; }

		public string Address { get; set; }

		public string Telephone { get; set; }

		public string Email { get; set; }

		public string PersonForContact { get; set; }

		public string BankDetails { get; set; }

		public string Description { get; set; }

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
			using (var context = new BmsContex())
			{
				var contragent = new Contragent()
				{
					Name = this.Name,
					PersonalVatNumber = this.PersonalVatNumber,
					PersonalIndentityNumber = this.PersonalIndentityNumber,
					Address = this.Address,
					Telephone = this.Telephone,
					Email = this.Email,
					PersonForContact = this.PersonForContact,
					BankDetails = this.BankDetails,
					Description = this.Description
				};

				context.Contragents.Add(contragent);
				context.SaveChanges();
				MessageBox.Show("Client details saved successfully");

				var dash = new MainWindow();
				dash.Show();
				this.CloseAction();
			}
		}

		private void HandleBackCommand(object parameter)
		{
			var dash = new MainWindow();
			dash.Show();
			this.CloseAction();
		}



	}
}
