namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using BmsWpf.Views.ChildWindows;
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    public class InquireFormViewModel : ViewModelBase, IPageViewModel
    {
        private ContragentListDto selectedClient;
        private ObservableCollection<UserListDto> usernamesList;
        private ObservableCollection<ContragentListDto> clientsList;
        private UserListDto selectedUsername;
        private int id;
        private string personOfContact;
        private string email;
        private string phoneNum;
        private string description;
        private DateTime date;

        public ICommand WindowLoadedCommand;
        public ICommand SaveCommand;
        public ICommand BackCommand;
        public ICommand SelectionChangedCommand;
        public DataRowView selectedInquiry;

        public InquireFormViewModel()
        {
            this.Date = DateTime.Now;
        }

        public IInquiryService InquiryService { get; set; }
        public IUserService UserService { get; set; }
        public IContragentService ContragentService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Inquiry Form";
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
                this.OnPropertyChanged(nameof(Id));
            }
        }

        public string PersonOfContact
        {
            get
            {
                return this.personOfContact;
            }
            set
            {
                this.personOfContact = value;
                this.OnPropertyChanged(nameof(PersonOfContact));
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

        public string PhoneNum
        {
            get
            {
                return this.phoneNum;
            }
            set
            {
                this.phoneNum = value;
                this.OnPropertyChanged(nameof(PhoneNum));
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

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
                this.OnPropertyChanged(nameof(Date));
            }
        }

        public DataRowView SelectedInquiry
        {
            get
            {
                return this.selectedInquiry;
            }
            set
            {
                this.selectedInquiry = value;
                this.OnPropertyChanged(nameof(SelectedInquiry));
            }
        }

        public UserListDto SelectedUsername
        {
            get
            {
                return this.selectedUsername;
            }
            set
            {
                this.selectedUsername = value;
                this.OnPropertyChanged(nameof(SelectedUsername));
            }
        }

        public ObservableCollection<UserListDto> UsernameList
        {
            get
            {
                return this.usernamesList;
            }
            set
            {
                this.usernamesList = value;
                OnPropertyChanged(nameof(UsernameList));
            }
        }

        public ContragentListDto SelectedClient
        {
            get
            {
                return this.selectedClient;
            }
            set
            {
                this.selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        public ObservableCollection<ContragentListDto> ClientsList
        {
            get
            {
                return this.clientsList;
            }
            set
            {
                this.clientsList = value;
                OnPropertyChanged("ClientsList");
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

        public ICommand SelectionChanged
        {
            get
            {
                if (this.SelectionChangedCommand == null)
                {
                    this.SelectionChangedCommand = new RelayCommand(this.HandleSelectionChangedCommand);
                }
                return this.SelectionChangedCommand;
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

        private void HandleLoadedCommand(object parameter)
        {
            this.UsernameList = new ObservableCollection<UserListDto>(this.UserService.GetUsernames());
            this.ClientsList = new ObservableCollection<ContragentListDto>(this.ContragentService.GetAllContragents());
            if (this.SelectedInquiry != null)
            {
                this.Id = (int)selectedInquiry.Row.ItemArray[0];
                var creatorDto = (UserListDto)SelectedInquiry.Row.ItemArray[1];
                this.SelectedUsername = UsernameList.SingleOrDefault(x => x.Id == creatorDto.Id);
                var clientDto = (ContragentListDto)selectedInquiry.Row.ItemArray[2];
                this.SelectedClient = ClientsList.SingleOrDefault(x => x.NameAndIdentity == clientDto.NameAndIdentity);
                this.Description = (string)selectedInquiry.Row.ItemArray[3];
                this.Date = (DateTime)selectedInquiry.Row.ItemArray[4];

                var clientId = clientDto.Id;

                var client = this.ContragentService.GetClientById(clientId);

                this.PersonOfContact = client.Contact;
                this.Email = client.Email;
                this.PhoneNum = client.PhoneNum;
            }
        }

        private void HandleSaveCommand(object parameter)
        {
            var result = string.Empty;
            var newInquiry = new InquiryPostDto()
            {
                Id = this.Id,
                CreatorId = this.SelectedUsername.Id,
                ClientId = this.SelectedClient.Id,
                Description = this.Description,
                Date = this.Date
            };
            try
            {
                if (this.SelectedInquiry == null)
                {
                    result = this.InquiryService.CreateInquiry(newInquiry);
                }
                else
                {
                    result = this.InquiryService.EditInquiry(newInquiry);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            MessageBox.Show(result);
            this.RedirectToMainInquiries();
        }

        private void HandleBackCommand(object parameter)
        {
            RedirectToMainInquiries();
        }

        private void HandleSelectionChangedCommand(object parameter)
        {
            if (this.SelectedClient != null)
            {
                var clientInfo = ContragentService.GetClientById(this.SelectedClient.Id);

                this.PersonOfContact = clientInfo.Contact;
                this.Email = clientInfo.Email;
                this.PhoneNum = clientInfo.PhoneNum;
            }
        }

        private void RedirectToMainInquiries()
        {
            var mainInquiriesWindow = this.ViewManager.ComposeObjects<MainInquiries>();
            mainInquiriesWindow.Show();
            this.CloseAction();
        }
    }
}
