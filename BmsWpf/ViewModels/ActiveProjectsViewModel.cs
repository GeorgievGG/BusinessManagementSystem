namespace BmsWpf.ViewModels
{
    using BMS.DataBaseModels;
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.Forms;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class ActiveProjectsViewModel : ViewModelBase, IPageViewModel
    {
        public ICommand SearchCommand;
        public ICommand SortCommand;
        public ICommand AddNewProjectCommand;
        public ICommand EditProjectCommand;
        public ICommand BackCommand;
        public ICommand WindowLoadedCommand;
        
        private ObservableCollection<string> chosenProjects;

        public Action CloseAction { get; set; }

        public IBmsData BmsData { get; set; }
        public IViewManager ViewManager { get; set; }
        public IProjectService ProjectService { get; set; }

        public ActiveProjectsViewModel()
        {
            this.BeginDate = DateTime.Now;
            this.EndDate = DateTime.Now;
        }

        public string ViewName
        {
            get
            {
                return "Active Projects";
            }
        }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public ObservableCollection<string> ChosenProjects
        {
            get
            {
                return chosenProjects;
            }
            private set
            {
                this.chosenProjects = value;
                this.OnPropertyChanged("ChosenProjects");
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

        public ICommand Search
        {
            get
            {
                if (this.SearchCommand == null)
                {
                    this.SearchCommand = new RelayCommand(this.HandleSearchCommand);
                }
                return this.SearchCommand;
            }
        }

        public ICommand AddNewProject
        {
            get
            {
                if (this.AddNewProjectCommand == null)
                {
                    this.AddNewProjectCommand = new RelayCommand(this.HandleAddNewProjectCommand);
                }
                return this.AddNewProjectCommand;
            }
        }

        public ICommand EditProject
        {
            get
            {
                if (this.EditProjectCommand == null)
                {
                    this.EditProjectCommand = new RelayCommand(this.HandleEditProjectCommand);
                }
                return this.EditProjectCommand;
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
            this.ChosenProjects = new ObservableCollection<string>(ProjectService.GetProjects());
        }

        private void HandleSearchCommand(object parameter)
        {
            var chosenProjectsQueryable = ProjectService.FilterProjects(BeginDate, EndDate);
            this.ChosenProjects = new ObservableCollection<string>(chosenProjectsQueryable);
        }

        private void HandleAddNewProjectCommand(object parameter)
        {
            var addPrjView = this.ViewManager.ComposeObjects<ProjectForm>();
            addPrjView.Show();
            this.CloseAction();
        }

        private void HandleEditProjectCommand(object parameter)
        {
            var editPrjView = this.ViewManager.ComposeObjects<ProjectForm>();
            editPrjView.Show();
            this.CloseAction();
        }

        private void HandleBackCommand(object parameter)
        {
            var mainWindow = this.ViewManager.ComposeObjects<MainWindow>();
            mainWindow.Show();
            this.CloseAction();
        }
    }
}
