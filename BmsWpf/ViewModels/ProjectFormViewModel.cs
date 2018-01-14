namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Utilities;
    using BmsWpf.Views.ActiveProjectForms;
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Windows.Input;

    public class ProjectFormViewModel : ViewModelBase
    {
        public ObservableCollection<TabItem> Tabs { get; set; }
        public ProjectFormViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();
        }
        public ICommand WindowLoadedCommand;
        public IViewManager ViewManager { get; set; }
        public DataRowView SelectedProject { get; set; }

        public Action CloseAction { get; set; }

        public Action OpenTab { get; set; }

        public virtual ICommand WindowLoaded
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

        protected virtual void HandleLoadedCommand(object parameter)
        {
            var poView = ViewManager.ComposeObjects<ProjectOverviewView>();
            var poViewVM = (PFOverviewViewModel)poView.DataContext;
            poViewVM.SelectedProject = this.SelectedProject;
            poViewVM.CloseAction = this.CloseAction;
            Tabs.Add(new TabItem { Header = "Project Overview", Content = poView });
            if (this.SelectedProject != null)
            {
                var iView = ViewManager.ComposeObjects<IncomesView>();
                var iViewVM = (PFIncomeViewModel)iView.DataContext;
                iViewVM.SelectedProject = this.SelectedProject;
                iViewVM.CloseAction = this.CloseAction;
                Tabs.Add(new TabItem { Header = "Income", Content = iView });

                var eView = ViewManager.ComposeObjects<ExpensesView>();
                var eViewVM = (PFExpensesViewModel)eView.DataContext;
                eViewVM.SelectedProject = this.SelectedProject;
                eViewVM.CloseAction = this.CloseAction;
                Tabs.Add(new TabItem { Header = "Expenses", Content = eView });

                var nView = ViewManager.ComposeObjects<NotesView>();
                var nViewVM = (PFNotesViewModel)nView.DataContext;
                nViewVM.SelectedProject = this.SelectedProject;
                nViewVM.CloseAction = this.CloseAction;
                Tabs.Add(new TabItem { Header = "Notes", Content = nView });
            }
            else
            {
                poViewVM.HideNotesTab();
                poViewVM.HideNotesLabel();
                poViewVM.HideIncomeBox();
                poViewVM.HideIncomeLabel();
                poViewVM.HideExpensesBox();
                poViewVM.HideExpensesLabel();
                poViewVM.HideProfitBox();
                poViewVM.HideProfitLabel();
            }
            this.OpenTab();
        }
    }
}