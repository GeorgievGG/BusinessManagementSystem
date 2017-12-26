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

        public string ViewName
        {
            get
            {
                return "Contragent View";
            }
        }

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
