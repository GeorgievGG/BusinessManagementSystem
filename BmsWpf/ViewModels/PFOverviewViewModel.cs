namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using BmsWpf.Sessions;
    using BmsWpf.Views.ChildWindows;
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    public class PFOverviewViewModel : ViewModelBase
    {
        private string creator;
        public DataRowView selectedProject;
        private ObservableCollection<ContragentListDto> clientsList;
        private ObservableCollection<InquiryListDto> inquiriesList;
        private ObservableCollection<OfferListDto> offersList;
        private DataTable notesAndEvents;
        private ContragentListDto selectedClient;
        private InquiryListDto selectedInquiry;
        private OfferListDto selectedOffer;

        public Action CloseAction { get; set; }
        public Action HideNotesTab { get; set; }
        public Action HideNotesLabel { get; set; }
        public Action HideIncomeBox { get; set; }
        public Action HideExpensesBox { get; set; }
        public Action HideProfitBox { get; set; }
        public Action HideIncomeLabel { get; set; }
        public Action HideExpensesLabel { get; set; }
        public Action HideProfitLabel { get; set; }

        public IProjectService ProjectService { get; set; }
        public IOfferService OfferService { get; set; }
        public IInquiryService InquiryService { get; set; }
        public IUserService UserService { get; set; }
        public IContragentService ContragentService { get; set; }
        public INoteService NoteService { get; set; }
        public IViewManager ViewManager { get; set; }

        private int id;
        private string name;
        private int creatorId;
        private string contactTo;
        private string telephone;
        private DateTime startDate;
        private DateTime deadline;
        private DateTime? endDate;
        private decimal incomes;
        private decimal expenses;
        private decimal profit;

        public ICommand WindowLoadedCommand;
        public ICommand SaveCommand;
        public ICommand BackCommand;

        public PFOverviewViewModel()
        {
            TabTitle = "Project Overview";
            this.StartDate = DateTime.Now;
            this.Deadline = DateTime.Now;
            this.EndDate = DateTime.Now;
        }

        public string Creator
        {
            get
            {
                return this.creator;
            }
            set
            {
                this.creator = value;
                this.OnPropertyChanged(nameof(Creator));
            }
        }

        public DataRowView SelectedProject
        {
            get
            {
                return this.selectedProject;
            }
            set
            {
                this.selectedProject = value;
                this.OnPropertyChanged(nameof(SelectedProject));
            }
        }

        public string TabTitle { get; protected set; }

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

        public string ContactTo
        {
            get
            {
                return this.contactTo;
            }
            set
            {
                this.contactTo = value;
                this.OnPropertyChanged(nameof(ContactTo));
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

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
                this.OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime Deadline
        {
            get
            {
                return this.deadline;
            }
            set
            {
                this.deadline = value;
                this.OnPropertyChanged(nameof(Deadline));
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
                this.OnPropertyChanged(nameof(EndDate));
            }
        }

        public decimal Incomes
        {
            get
            {
                return this.incomes;
            }
            set
            {
                this.incomes = value;
                this.OnPropertyChanged(nameof(Incomes));
            }
        }

        public decimal Expenses
        {
            get
            {
                return this.expenses;
            }
            set
            {
                this.expenses = value;
                this.OnPropertyChanged(nameof(Expenses));
            }
        }

        public decimal Profit
        {
            get
            {
                return this.profit;
            }
            set
            {
                this.profit = value;
                this.OnPropertyChanged(nameof(Profit));
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

        public OfferListDto SelectedOffer
        {
            get
            {
                return this.selectedOffer;
            }
            set
            {
                this.selectedOffer = value;
                OnPropertyChanged(nameof(SelectedOffer));
            }
        }

        public ObservableCollection<OfferListDto> OffersList
        {
            get
            {
                return this.offersList;
            }
            set
            {
                this.offersList = value;
                OnPropertyChanged(nameof(OffersList));
            }
        }

        public DataTable NotesAndEvents
        {
            get
            {
                return this.notesAndEvents;
            }
            set
            {
                this.notesAndEvents = value;
                OnPropertyChanged(nameof(NotesAndEvents));
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

        protected void HandleLoadedCommand(object parameter)
        {
            this.ClientsList = new ObservableCollection<ContragentListDto>(this.ContragentService.GetContragentsForDropdown());
            this.InquiriesList = new ObservableCollection<InquiryListDto>(this.InquiryService.GetInquiriesList());
            this.OffersList = new ObservableCollection<OfferListDto>(this.OfferService.GetOffersList());
            this.Creator = Session.Instance.Username;
            this.creatorId = this.UserService.GetUsernames().SingleOrDefault(x => x.Username == Creator).Id;
            if (this.SelectedProject != null)
            {
                this.Id = (int)SelectedProject.Row.ItemArray[0];
                this.Name = (string)SelectedProject.Row.ItemArray[1];
                var offerDto = (OfferListDto)SelectedProject.Row.ItemArray[2];
                this.SelectedOffer = OffersList.SingleOrDefault(x => x.Id == offerDto.Id);
                var inquiryDto = (InquiryListDto)SelectedProject.Row.ItemArray[3];
                this.SelectedInquiry = InquiriesList.SingleOrDefault(x => x.Id == inquiryDto.Id);
                var clientDto = (ContragentListDto)SelectedProject.Row.ItemArray[5];
                this.SelectedClient = ClientsList.SingleOrDefault(x => x.Id == clientDto.Id);
                this.StartDate = (DateTime)SelectedProject.Row.ItemArray[6];
                this.EndDate = (DateTime?)(SelectedProject.Row.ItemArray[7] == DBNull.Value ? null : SelectedProject.Row.ItemArray[7]);
                this.Deadline = (DateTime)SelectedProject.Row.ItemArray[8];
                this.ContactTo = (string)(SelectedProject.Row.ItemArray[9] == DBNull.Value ? "" : SelectedProject.Row.ItemArray[9]);
                this.Telephone = (string)(SelectedProject.Row.ItemArray[10] == DBNull.Value ? "" : SelectedProject.Row.ItemArray[10]);
                this.Incomes = (decimal)SelectedProject.Row.ItemArray[11];
                this.Expenses = (decimal)SelectedProject.Row.ItemArray[12];
                this.Profit = (decimal)SelectedProject.Row.ItemArray[13];
                this.NotesAndEvents = NoteService.GetLast5NotesAsDataTable(this.Id);
            }
            else
            {
                this.EndDate = null;
            }
        }

        private void HandleSaveCommand(object parameter)
        {
            var result = string.Empty;
            var newProject = new ProjectPostDto()
            {
                Id = this.Id,
                Name = this.Name,
                OfferId = this.SelectedOffer.Id,
                InquiryId = this.SelectedInquiry.Id,
                CreatorId = creatorId,
                ClientId = this.SelectedClient.Id,
                ContactPerson = this.ContactTo,
                ContactPhone = this.Telephone,
                StartDate = this.StartDate,
                Deadline = this.Deadline,
                EndDate = this.EndDate
            };
            try
            {
                if (this.SelectedProject == null)
                {
                    result = this.ProjectService.CreateProject(newProject);
                }
                else
                {
                    result = this.ProjectService.EditProject(newProject);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            MessageBox.Show(result);
            this.RedirectToMainOffers();
        }

        private void HandleBackCommand(object parameter)
        {
            this.RedirectToMainOffers();
        }

        private void RedirectToMainOffers()
        {
            var mainProjectsWindow = this.ViewManager.ComposeObjects<ActiveProjects>();
            mainProjectsWindow.Show();
            this.CloseAction();
        }
    }
}
