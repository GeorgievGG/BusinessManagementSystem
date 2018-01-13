namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using BmsWpf.Views.ChildWindows;
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    public class OffersFormViewModel : ViewModelBase, IPageViewModel
    {
        private ContragentListDto selectedClient;
        private ObservableCollection<ContragentListDto> clientsList;
        private int id;
        private int creatorId;
        private string personOfContact;
        private string email;
        private string phoneNum;
        private string description;
        private string inquiryCreator;
        private DateTime date;

        public ICommand WindowLoadedCommand;
        public ICommand SaveCommand;
        public ICommand BackCommand;
        public ICommand SelectionChangedCommand;
        public DataRowView selectedInquiry;

        public OffersFormViewModel()
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

        public string InquiryCreator
        {
            get
            {
                return this.inquiryCreator;
            }
            set
            {
                this.inquiryCreator = value;
                this.OnPropertyChanged(nameof(InquiryCreator));
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
                OnPropertyChanged(nameof(ClientsList));
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
            this.ClientsList = new ObservableCollection<ContragentListDto>(this.ContragentService.GetContragentsForDropdown());
            this.creatorId = this.UserService.GetUsernames().SingleOrDefault(x => x.Username == inquiryCreator).Id;
            if (this.SelectedInquiry != null)
            {
                this.Id = (int)selectedInquiry.Row.ItemArray[0];
                var clientDto = (ContragentListDto)selectedInquiry.Row.ItemArray[2];
                this.SelectedClient = ClientsList.SingleOrDefault(x => x.NameAndIdentity == clientDto.NameAndIdentity);
                this.Description = (string)selectedInquiry.Row.ItemArray[3];
                this.Date = DateTime.ParseExact(selectedInquiry.Row.ItemArray[4].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

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
            InquiryPostDto newInquiry;
            try
            {
                newInquiry = new InquiryPostDto()
                {
                    Id = this.Id,
                    CreatorId = this.creatorId,
                    ClientId = this.SelectedClient.Id,
                    Description = this.Description,
                    Date = this.Date
                };
                if (this.SelectedInquiry == null)
                {
                    result = this.InquiryService.CreateInquiry(newInquiry);
                    MessageBox.Show(result);
                    this.RedirectToMainInquiries();
                }
                else
                {
                    result = this.InquiryService.EditInquiry(newInquiry);
                    MessageBox.Show(result);
                    this.RedirectToMainInquiries();
                }
            }
            catch (Exception e)
            {
                result = e.Message;
                MessageBox.Show(result);
            }

        }

        private void HandleBackCommand(object parameter)
        {
            this.RedirectToMainInquiries();
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
