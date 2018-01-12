namespace BmsWpf.Views.ActiveProjectForms
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for ProjectOverviewTabView.xaml
    /// </summary>
    public partial class ProjectOverviewView : UserControl
    {
        public ProjectOverviewView()
        {
            InitializeComponent();
        }

        public ProjectOverviewView(IViewManager viewManager, IInquiryService inquiryService, IContragentService contragentService, IUserService userService, IOfferService offerService, INoteService noteService, IProjectService projectService)
        {
            InitializeComponent();

            PFOverviewViewModel vm = (PFOverviewViewModel)this.DataContext; // this creates an instance of the ViewModel
            if (vm.HideNotesTab == null)
            {
                vm.HideNotesTab = new Action(() => this.NotesGrid.Visibility = Visibility.Hidden);
            }
            if (vm.HideNotesLabel == null)
            {
                vm.HideNotesLabel = new Action(() => this.NotesLabel.Visibility = Visibility.Hidden);
            }
            if (vm.HideIncomeBox == null)
            {
                vm.HideIncomeBox = new Action(() => this.IncomeBox.Visibility = Visibility.Hidden);
            }
            if (vm.HideExpensesBox == null)
            {
                vm.HideExpensesBox = new Action(() => this.ExpensesBox.Visibility = Visibility.Hidden);
            }
            if (vm.HideProfitBox == null)
            {
                vm.HideProfitBox = new Action(() => this.ProfitBox.Visibility = Visibility.Hidden);
            }
            if (vm.HideIncomeLabel == null)
            {
                vm.HideIncomeLabel = new Action(() => this.IncomeLabel.Visibility = Visibility.Hidden);
            }
            if (vm.HideExpensesLabel == null)
            {
                vm.HideExpensesLabel = new Action(() => this.ExpensesLabel.Visibility = Visibility.Hidden);
            }
            if (vm.HideProfitLabel == null)
            {
                vm.HideProfitLabel = new Action(() => this.ProfitLabel.Visibility = Visibility.Hidden);
            }

            vm.ViewManager = viewManager;
            vm.InquiryService = inquiryService;
            vm.ContragentService = contragentService;
            vm.UserService = userService;
            vm.OfferService = offerService;
            vm.NoteService = noteService;
            vm.ProjectService = projectService;
        }
    }
}
