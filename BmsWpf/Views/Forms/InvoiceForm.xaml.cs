namespace BmsWpf.Views.Forms
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for InvoiceForm.xaml
    /// </summary>
    public partial class InvoiceForm : Window
    {
        public InvoiceForm()
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
