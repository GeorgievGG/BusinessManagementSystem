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

    public class OfferFormViewModel : ViewModelBase, IPageViewModel
    {
        private ObservableCollection<ContragentListDto> clientsList;
        private ObservableCollection<InquiryListDto> inquiriesList;
        private ContragentListDto selectedClient;
        private InquiryListDto selectedInquiry;

        private int id;
        private DateTime date;
        private string offerCreator;

        public ICommand WindowLoadedCommand;
        public ICommand SaveCommand;
        public ICommand BackCommand;
        public DataRowView selectedOffer;
        private string description;

        public OfferFormViewModel()
        {
            this.Date = DateTime.Now;
        }

        public IOfferService OfferService { get; set; }
        public IInquiryService InquiryService { get; set; }
        public IUserService UserService { get; set; }
        public IContragentService ContragentService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Offer Form";
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

        public string OfferCreator
        {
            get
            {
                return this.offerCreator;
            }
            set
            {
                this.offerCreator = value;
                this.OnPropertyChanged(nameof(OfferCreator));
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

        public DataRowView SelectedOffer
        {
            get
            {
                return this.selectedOffer;
            }
            set
            {
                this.selectedOffer = value;
                this.OnPropertyChanged(nameof(SelectedOffer));
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

        public InquiryListDto SelectedInquiry
        {
            get
            {
                return this.selectedInquiry;
            }
            set
            {
                this.selectedInquiry = value;
                OnPropertyChanged(nameof(SelectedInquiry));
            }
        }

        public ObservableCollection<InquiryListDto> InquiriesList
        {
            get
            {
                return this.inquiriesList;
            }
            set
            {
                this.inquiriesList = value;
                OnPropertyChanged(nameof(InquiriesList));
            }
        }

        private int creatorId;

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

        private void HandleLoadedCommand(object parameter)
        {
            this.ClientsList = new ObservableCollection<ContragentListDto>(this.ContragentService.GetContragentsForDropdown());
            this.InquiriesList = new ObservableCollection<InquiryListDto>(this.InquiryService.GetInquiriesList());
            this.creatorId = this.UserService.GetUsernames().SingleOrDefault(x => x.Username == offerCreator).Id;

            if (this.SelectedOffer != null)
            {
                this.Id = (int)SelectedOffer.Row.ItemArray[0];
                var clientDto = (ContragentListDto)SelectedOffer.Row.ItemArray[2];
                this.SelectedClient = ClientsList.SingleOrDefault(x => x.Id == clientDto.Id);
                var inquiryDto = (InquiryListDto)SelectedOffer.Row.ItemArray[3];
                this.SelectedInquiry = InquiriesList.SingleOrDefault(x => x.Id == inquiryDto.Id);
                this.Description = (string)SelectedOffer.Row.ItemArray[4];
                this.Date = DateTime.ParseExact(SelectedOffer.Row.ItemArray[5].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
        }

        private void HandleSaveCommand(object parameter)
        {
            var result = string.Empty;
            OfferPostDto newOffer;
            try
            {
                newOffer = new OfferPostDto
                {
                    Id = this.Id,
                    CreatorId = creatorId,
                    ClientId = this.SelectedClient.Id,
                    InquiryId = this.SelectedInquiry.Id,
                    Description = this.Description,
                    Date = this.Date
                };
                if (this.SelectedOffer == null)
                {
                    result = this.OfferService.CreateOffer(newOffer);
                    MessageBox.Show(result);
                    this.RedirectToMainOffers();
                }
                else
                {
                    result = this.OfferService.EditOffer(newOffer);
                    MessageBox.Show(result);
                    this.RedirectToMainOffers();
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
            this.RedirectToMainOffers();
        }

        private void RedirectToMainOffers()
        {
            var mainOffersWindow = this.ViewManager.ComposeObjects<MainOffers>();
            mainOffersWindow.Show();
            this.CloseAction();
        }
    }
}
