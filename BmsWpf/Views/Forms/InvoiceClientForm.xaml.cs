namespace BmsWpf.Views.Forms
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for InvoiceClientForm.xaml
    /// </summary>
    public partial class InvoiceClientForm : Window
    {
        public InvoiceClientForm()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
                var dash = new MainWindow();
                dash.Show();
                this.Close();
        }
    }
}
