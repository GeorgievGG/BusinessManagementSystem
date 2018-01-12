namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class ProjectFormViewModel : ViewModelBase
    {
        private ObservableCollection<ViewModelBase> _pageViews;

        public ICommand WindowLoadedCommand;

        public Action CloseAction { get; set; }

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

        private void HandleLoadedCommand(object parameter)
        {
            PageViews.Add(this.ViewManager.ComposeObjects<PFOverviewViewModel>());
            PageViews.Add(this.ViewManager.ComposeObjects<PFIncomeViewModel>());
            PageViews.Add(this.ViewManager.ComposeObjects<PFExpensesViewModel>());
            PageViews.Add(this.ViewManager.ComposeObjects<PFNotesViewModel>());
        }
    }
}