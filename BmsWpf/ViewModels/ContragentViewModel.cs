using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BmsWpf.Behaviour;
using BMS.DataBaseData;
using BMS.DataBaseModels;

namespace BmsWpf.ViewModels
{
	class ContragentViewModel : ViewModelBase, IPageViewModel
	{
		public ICommand SaveCommand;
		public ICommand BackCommand;

		public string Name { get; set; }

		public string PersonalVatNumber { get; set; }

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
					PersonalVatNumber = this.PersonalVatNumber
				};

				context.Contragents.Add(contragent);
				context.SaveChanges();
			}
		}

        private void HandleBackCommand(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
