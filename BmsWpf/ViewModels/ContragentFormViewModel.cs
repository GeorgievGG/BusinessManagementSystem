namespace BmsWpf.ViewModels
{
    using BMS.DataBaseData;
    using BMS.DataBaseModels;
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using BmsWpf.Views.ChildWindows;
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Input;

    public class ContragentFormViewModel : ViewModelBase, IPageViewModel
    {
        private DataRowView selectedContragent;
        private int id;
        private string name;
        private string personalVatNumber;
        private string personalIndentityNumber;
        private string address;
        private string telephone;
        private string bankDetails;
        private string personOfContact;
        private string email;
        private string description;

        public ICommand WindowLoadedCommand;
        public ICommand SaveCommand;
        public ICommand BackCommand;
        public ICommand SelectionChangedCommand;

        public IContragentService ContragentService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
		{
			get
			{
				return "Contragent Form";
			}
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged(nameof(Name));
            }
        }

        public string PersonalVatNumber
        {
            get
            {
                return this.personalVatNumber;
            }
            set
            {
                this.personalVatNumber = value;
                this.OnPropertyChanged(nameof(PersonalVatNumber));
            }
        }

        public string PersonalIndentityNumber
        {
            get
            {
                return this.personalIndentityNumber;
            }
            set
            {
                this.personalIndentityNumber = value;
                this.OnPropertyChanged(nameof(PersonalIndentityNumber));
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
                this.OnPropertyChanged(nameof(Address));
            }
        }

        public string Telephone
        {
            get
            {
                return this.telephone;
            }
            set
            {
                this.telephone = value;
                this.OnPropertyChanged(nameof(Telephone));
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
                this.OnPropertyChanged(nameof(Email));
            }
        }

        public string PersonForContact
        {
            get
            {
                return this.personOfContact;
            }
            set
            {
                this.personOfContact = value;
                this.OnPropertyChanged(nameof(PersonForContact));
            }
        }

        public string BankDetails
        {
            get
            {
                return this.bankDetails;
            }
            set
            {
                this.bankDetails = value;
                this.OnPropertyChanged(nameof(BankDetails));
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                this.OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand WindowLoaded
        {
            get
            {
                if (this.WindowLoadedCommand == null)
                {
                    this.WindowLoadedCommand = new RelayCommand(this.HandleLoadedCommand);
                }
                return this.WindowLoadedCommand;
            }
        }

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

        public DataRowView SelectedContragent { get => selectedContragent; set => selectedContragent = value; }

        private void HandleLoadedCommand(object parameter)
        {
            if (this.SelectedContragent != null)
            {
                this.Id = (int)SelectedContragent.Row.ItemArray[0];
                this.Name = (string)SelectedContragent.Row.ItemArray[1];
                this.PersonalIndentityNumber = (string)SelectedContragent.Row.ItemArray[2];
                this.PersonalVatNumber = (string)SelectedContragent.Row.ItemArray[3];
                this.Address = (string)SelectedContragent.Row.ItemArray[4];
                this.Telephone = (string)SelectedContragent.Row.ItemArray[5];
                this.Email = (string)SelectedContragent.Row.ItemArray[6];
                this.PersonForContact = (string)SelectedContragent.Row.ItemArray[7];
                this.BankDetails = (string)SelectedContragent.Row.ItemArray[8];
                this.Description = (string)SelectedContragent.Row.ItemArray[9];
            }
        }

        private void HandleSaveCommand(object parameter)
        {
            var result = string.Empty;
            var newContragent = new ContragentPostDto()
            {
                Id = this.Id,
                Name = this.Name,
                PersonalIndentityNumber = this.PersonalIndentityNumber,
                PersonalVatNumber = this.PersonalVatNumber,
                Address = this.Address,
                Telephone = this.Telephone,
                Email = this.Email,
                PersonForContact = this.PersonForContact,
                BankDetails = this.BankDetails,
                Description = this.Description
            };
            try
            {
                if (this.SelectedContragent == null)
                {
                    result = this.ContragentService.CreateContragent(newContragent);
                }
                else
                {
                    result = this.ContragentService.EditContragent(newContragent);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            MessageBox.Show(result);
            this.RedirectToMainContragents();

            //using (var context = new BmsContex())
            //{
            //	var contragent = new Contragent()
            //	{
            //		Name = this.Name,
            //		PersonalVatNumber = this.PersonalVatNumber,
            //		PersonalIndentityNumber = this.PersonalIndentityNumber,
            //		Address = this.Address,
            //		Telephone = this.Telephone,
            //		Email = this.Email,
            //		PersonForContact = this.PersonForContact,
            //		BankDetails = this.BankDetails,
            //		Description = this.Description
            //	};

            //	context.Contragents.Add(contragent);
            //	context.SaveChanges();
            //	MessageBox.Show("Contragent details saved successfully");

            this.RedirectToMainContragents();
		}

		private void HandleBackCommand(object parameter)
        {
            this.RedirectToMainContragents();
        }

        private void RedirectToMainContragents()
        {
            var mainContragentsWindow = this.ViewManager.ComposeObjects<MainContragents>();
            mainContragentsWindow.Show();
            this.CloseAction();
        }
    }
}
