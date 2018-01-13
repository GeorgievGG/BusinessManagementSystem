namespace BmsWpf.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using BMS.DataBaseModels.Enums;

    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using BmsWpf.Views.ChildWindows;

    public class NoteViewModel : ViewModelBase, IPageViewModel
    {
        private ProjectListDto selectedProject;
        private ObservableCollection<ProjectListDto> projectsList;
        private int id;
        private string description;
        private DateTime noteDate;
        private NoteType selectedType;
        private readonly ObservableCollection<NoteType> types;


        public ICommand WindowLoadedCommand;
        public ICommand SaveCommand;
        public DataRowView selectedNote;

        public NoteViewModel()
        {

            this.noteDate = DateTime.Now;

            var typeList = Enum.GetValues(typeof(NoteType)).Cast<NoteType>().ToList();
            this.types = new ObservableCollection<NoteType>(typeList);
        }

        public INoteService NoteService { get; set; }
        public IUserService UserService { get; set; }
        public IProjectService ProjectService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Note Form";
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

        public DateTime NoteDate
        {
            get
            {
                return this.noteDate;
            }
            set
            {
                this.noteDate = value;
                this.OnPropertyChanged(nameof(this.NoteDate));
            }
        }

        public int InitialProjectId { get; set; }

        public DataRowView SelectedNote
        {
            get
            {
                return this.selectedNote;
            }
            set
            {
                this.selectedNote = value;
                this.OnPropertyChanged(nameof(this.SelectedNote));
            }
        }

        public ProjectListDto SelectedProject
        {
            get
            {
                return this.selectedProject;
            }
            set
            {
                this.selectedProject = value;
                this.OnPropertyChanged(nameof(this.SelectedProject));
            }
        }

        public ObservableCollection<ProjectListDto> ProjectsList
        {
            get
            {
                return this.projectsList;
            }
            set
            {
                this.projectsList = value;
                OnPropertyChanged(nameof(this.ProjectsList));
            }
        }

        public NoteType SelectedType
        {
            get
            {
                return this.selectedType;
            }
            set
            {
                this.selectedType = value;
                this.OnPropertyChanged(nameof(this.SelectedType));
            }
        }

        public ObservableCollection<NoteType> Types
        {
            get
            {
                return this.types;
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
            this.ProjectsList = new ObservableCollection<ProjectListDto>(this.ProjectService.GetProjectsForDropdown());
            if (this.InitialProjectId != 0)
            {
                this.SelectedProject = this.ProjectsList.SingleOrDefault(x => x.Id == this.InitialProjectId);
            }
            if (this.SelectedNote !=null)
            {
                this.Id = (int)this.SelectedNote.Row.ItemArray[0];
                this.Description = (string)this.SelectedNote.Row.ItemArray[1];
                this.NoteDate = (DateTime)this.SelectedNote.Row.ItemArray[2];
                this.SelectedType = (NoteType)this.SelectedNote.Row.ItemArray[3];
                var projectDto = (ProjectListDto)this.SelectedNote.Row.ItemArray[4];
                if (projectDto != null)
                {
                    this.SelectedProject = this.ProjectsList.SingleOrDefault(x => x.Id == projectDto.Id);
                }
                
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

        private void HandleSaveCommand(object parameter)
        {
            var result = string.Empty;

            try
            {
                var newNote = new NotePostDto()
                                  {
                                      Id = this.id,
                                      Date = this.noteDate,
                                      Description = this.description,
                                      Type = this.selectedType,
                                      ProjectId = this.selectedProject.Id,
                                  };

                if (this.SelectedNote == null)
                {
                    result = this.NoteService.CreateNote(newNote);
                    MessageBox.Show(result);
                    this.CloseAction();
                }
                else
                {
                    result = this.NoteService.EditNote(newNote);
                    MessageBox.Show(result);
                    this.CloseAction();
                }
            }
            catch (Exception e)
            {
                result = e.Message;
                MessageBox.Show(result);
            }
        }
    }
}
