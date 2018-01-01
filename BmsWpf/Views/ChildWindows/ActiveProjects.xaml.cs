namespace BmsWpf.Views.ChildWindows
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
    using System.Windows;
    /// <summary>
    /// Interaction logic for ActiveProjects.xaml
    /// </summary>
    public partial class ActiveProjects : Window
    {
        public ActiveProjects()
        {
            InitializeComponent();
        }

        public ActiveProjects(IViewManager viewManager, IProjectService projectService)
        {
            InitializeComponent();

            var vm = (ActiveProjectsViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.ProjectService = projectService;
        }

        //private void Add_New_Click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new ProjectForm();
        //    dash.Show();
        //    this.Close();
        //}

        //private void Edit_click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new ProjectForm();
        //    dash.Show();
        //    this.Close();
        //}

        //private void Back_click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new MainWindow();
        //    dash.Show();
        //    this.Close();
        //}
    }
}
