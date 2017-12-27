namespace BmsWpf.Views.ChildWindows
{
    using BmsWpf.Views.Forms;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainContragents.xaml
    /// </summary>
    public partial class MainContragents : Window
    {
        public MainContragents()
        {
            InitializeComponent();
        }

        private void Add_New_Click(object sender, RoutedEventArgs e)
        {
            var dash = new ContragentForm();
            dash.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var dash = new ContragentForm();
            dash.Show();
            this.Close();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            var dash = new MainWindow();
            dash.Show();
            this.Close();
        }
    }
}
