namespace BmsWpf
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IViewManager viewManager)
        {
            InitializeComponent();

            var vm = (MainWindowViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
            
            vm.ViewManager = viewManager;
        }

        //private void Logout(object sender, RoutedEventArgs e)
        //{
        //    LoginForm dash = new LoginForm();
        //    dash.Show();
        //    this.Close();
        //}

        //private void projects_Click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new ActiveProjects();
        //    dash.Show();
        //    this.Close();
        //}

        //private void contragents_Click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new MainContragents();
        //    dash.Show();
        //    this.Close();
        //}

        //private void offers_Click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new MainOffers();
        //    dash.Show();
        //    this.Close();
        //}

        //private void inquiries_Click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new MainInquiries();
        //    dash.Show();
        //    this.Close();
        //}
    }
}
