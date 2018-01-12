namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Sessions;
    using BmsWpf.Views.Forms;
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Input;

    public class ActiveProjectsViewModel : ViewModelBase, IPageViewModel
    {
        public ICommand WindowLoadedCommand;
        public ICommand DoubleClickCommand;
        public ICommand SearchCommand;
        public ICommand SortCommand;
        public ICommand AddNewProjectCommand;
        public ICommand EditProjectCommand;
        public ICommand BackCommand;

        private DataTable chosenProjects;
        private DataRowView selectedProject;

        public Action CloseAction { get; set; }
        
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

        public DataTable ChosenProjects
        {
            get
            {
                return chosenProjects;
            }
            set
            {
                this.chosenProjects = value;
                this.OnPropertyChanged(nameof(ChosenProjects));
            }
        }

        public DataRowView SelectedProject
        {
            get
            {
                return selectedProject;
            }
            set
            {
                this.selectedProject = value;
                this.OnPropertyChanged(nameof(SelectedProject));
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

        public ICommand DoubleClick
        {
            get
            {
                if (this.DoubleClickCommand == null)
                {
                    this.DoubleClickCommand = new RelayCommand(this.HandleEditProjectCommand);
                }
                return this.DoubleClickCommand;
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
            this.ChosenProjects = ProjectService.GetProjectsAsDataTable();
        }

        private void HandleSearchCommand(object parameter)
        {
            var chosenProjectsQueryable = ProjectService.FilterProjects(BeginDate, EndDate);
            this.ChosenProjects = chosenProjectsQueryable;
        }

        private void HandleAddNewProjectCommand(object parameter)
        {
            var addPrjView = this.ViewManager.ComposeObjects<ProjectWindow>();
            var vm = (PFOverviewViewModel)addPrjView.DataContext;
            vm.Creator = Session.Instance.Username;
            addPrjView.Show();
            this.CloseAction();
        }

        private void HandleEditProjectCommand(object parameter)
        {
            if (this.SelectedProject == null)
            {
                MessageBox.Show("Please select a project to continue");
                return;
            }
            var editPrjView = this.ViewManager.ComposeObjects<ProjectWindow>();
            var vm = (PFOverviewViewModel)editPrjView.DataContext;
            vm.SelectedProject = this.SelectedProject;
            vm.Creator = Session.Instance.Username;
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
