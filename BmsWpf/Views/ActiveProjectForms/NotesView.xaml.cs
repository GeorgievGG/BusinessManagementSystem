namespace BmsWpf.Views.ActiveProjectForms
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for NotesTabView.xaml
    /// </summary>
    public partial class NotesView : UserControl
    {
        public NotesView()
        {
            InitializeComponent();
        }

        public NotesView(IViewManager viewManager, INoteService noteService)
        {
            this.InitializeComponent();

            PFNotesViewModel vm = (PFNotesViewModel)this.DataContext;

            vm.ViewManager = viewManager;
            vm.NoteService = noteService;
        }
    }
}
