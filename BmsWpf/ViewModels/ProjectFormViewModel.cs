namespace BmsWpf.ViewModels
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.ActiveProjectForms;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;

    public class ProjectFormViewModel
    {
        private ObservableCollection<ViewModelBase> _pageViews;

        public ProjectFormViewModel()
        {
            PageViews.Add(new PFOverviewViewModel());
            PageViews.Add(new PFIncomeViewModel());
            PageViews.Add(new PFExpensesViewModel());
            PageViews.Add(new PFNotesViewModel());
        }

        public IViewManager ViewManager { get; set; }

        public ObservableCollection<ViewModelBase> PageViews
        {
            get
            {
                if (_pageViews == null)
                {
                    _pageViews = new ObservableCollection<ViewModelBase>();
                }
                return _pageViews;
            }
        }
    }
}