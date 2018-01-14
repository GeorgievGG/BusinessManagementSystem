namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.ChildWindows;
    using BmsWpf.Views.Forms;
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Input;

    public class PFNotesViewModel : ViewModelBase
    {
        public string TabTitle { get; protected set; }

        public PFNotesViewModel()
        {
            TabTitle = "Notes";
        }

        private DataTable notes;
        private DataRowView selectedNote;

        public ICommand WindowLoadedCommand;
        public ICommand SearchCommand;
        public ICommand AddNewNoteCommand;
        public ICommand EditNoteCommand;
        public ICommand DoubleClickCommand;
        public ICommand AddNewPaymentCommand;
        public ICommand EditPaymentCommand;
        public ICommand DeleteCommand;
        public ICommand DoublePaymentClickCommand;

        public DataRowView SelectedProject { get; set; }
        public INoteService NoteService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public DataRowView SelectedNote
        {
            get
            {
                return this.selectedNote;
            }
            set
            {
                this.selectedNote = value;
                this.OnPropertyChanged(nameof(SelectedNote));
            }
        }

        public DataTable Notes
        {
            get
            {
                return notes;
            }
            private set
            {
                this.notes = value;
                this.OnPropertyChanged(nameof(Notes));
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

        public ICommand AddNewNote
        {
            get
            {
                if (this.AddNewNoteCommand == null)
                {
                    this.AddNewNoteCommand = new RelayCommand(this.HandleAddNewCommand);
                }
                return this.AddNewNoteCommand;
            }
        }

        public ICommand EditNote
        {
            get
            {
                if (this.EditNoteCommand == null)
                {
                    this.EditNoteCommand = new RelayCommand(this.HandleEditCommand);
                }
                return this.EditNoteCommand;
            }
        }

        public ICommand DoubleClick
        {
            get
            {
                if (this.DoubleClickCommand == null)
                {
                    this.DoubleClickCommand = new RelayCommand(this.HandleEditCommand);
                }
                return this.DoubleClickCommand;
            }
        }

        public ICommand Delete
        {
            get
            {
                if (this.DeleteCommand == null)
                {
                    this.DeleteCommand = new RelayCommand(this.HandleDeleteCommand);
                }
                return this.DeleteCommand;
            }
        }

        private void HandleLoadedCommand(object parameter)
        {
            var projectId = (int)this.SelectedProject.Row.ItemArray[0];
            this.Notes = NoteService.GetNotesAsDataTable(projectId);
        }

        private void HandleEditCommand(object parameter)
        {
            if (this.SelectedNote == null)
            {
                MessageBox.Show("Please select an note to continue");
                return;
            }

            var noteForm = this.ViewManager.ComposeObjects<NoteForm>();
            var vm = (NoteViewModel)noteForm.DataContext;
            vm.SelectedNote = this.SelectedNote;
            noteForm.Show();
        }

        private void HandleAddNewCommand(object parameter)
        {
            var noteForm = this.ViewManager.ComposeObjects<NoteForm>();
            var vm = (NoteViewModel)noteForm.DataContext;
            vm.InitialProjectId = 1;
            noteForm.Show();
        }

        private void HandleDeleteCommand(object parameter)
        {
            var noteId = (int)this.SelectedNote.Row.ItemArray[0];

            var result = string.Empty;

            try
            {
                result = this.NoteService.Delete(noteId);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            MessageBox.Show(result);
            var notesWindow = ViewManager.ComposeObjects<ActiveProjects>();
            notesWindow.Show();
            this.CloseAction();
        }
    }
}
