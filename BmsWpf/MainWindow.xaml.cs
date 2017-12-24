namespace BmsWpf
{
    using BmsWpf.Views.ChildWindows;
    using BmsWpf.Views.Forms;
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

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginForm dash = new LoginForm();
            dash.Show();
            this.Close();
        }

        private void projects_Click(object sender, RoutedEventArgs e)
        {
            var dash = new ActiveProjects();
            dash.Show();
            this.Close();
        }

        private void contragents_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainContragents();
            dash.Show();
            this.Close();
        }

        private void offers_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainOffers();
            dash.Show();
            this.Close();
        }

        private void inquiries_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainInquiries();
            dash.Show();
            this.Close();
        }
    }
}
