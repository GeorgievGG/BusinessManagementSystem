namespace BmsWpf.Views.Forms
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for NoteForm.xaml
    /// </summary>
    public partial class NoteForm : Window
    {
        public NoteForm()
        {
            InitializeComponent();
            //ShowTime();
            //this.DataContext = new BmsContex();

        }

        public NoteForm(IViewManager viewManager, IUserService userService, IProjectService projectService, INoteService noteService)
        {
            this.InitializeComponent();

            NoteViewModel vm = (NoteViewModel)this.DataContext;

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.UserService = userService;
            vm.ProjectService = projectService;
            vm.NoteService = noteService;
        }

        //private void ShowTime()
        //{
        //        this.Date.Content = DateTime.Now.ToShortDateString();            
        //}

        //private void Button_Click_Save(object sender, RoutedEventArgs e)
        //{
        //    var context = new BmsContex();
        //    Enum.TryParse(this.NoteTypeBox.Text, out NoteType type);
        //    var date = DateTime.Now;
        //    var description = this.DescriptionBox.Text;

        //}

        //private void Button_Click_Edit(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Button_Click_Back(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
