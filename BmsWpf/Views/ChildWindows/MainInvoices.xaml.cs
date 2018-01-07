namespace BmsWpf.Views.ChildWindows
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows;

    using BmsWpf.Views.Forms;

    using BMS.DataBaseData;
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;

    /// <summary>
    /// Interaction logic for MainInvoices.xaml
    /// </summary>
    public partial class MainInvoices : Window
    {
        public MainInvoices()
        {
            InitializeComponent();
        }

        public MainInvoices(IViewManager viewManager, IInvoiceService invoiceService)
        {
            InitializeComponent();

            MainInvoicesViewModel vm = (MainInvoicesViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.InvoiceService = invoiceService;
        }

        private void EditSupplierInvoiceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddClientInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            var clientInvoice = new InvoiceClientForm();
            clientInvoice.Show();
            this.ClientInvoicesGrid.ItemsSource = clientInvoice.Content.ToString();
        }

        private void EditClientInvoicesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSupplierInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            var supplierInvoice = new InvoinceSupplierForm();
            supplierInvoice.Show();
            this.ClientInvoicesGrid.ItemsSource = supplierInvoice.Content.ToString();

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var context = new BmsContex();
            var find = this.SearchTextBox.Text;
            var dateSearch = DateTime.ParseExact(find, "dd/MM/yy", CultureInfo.InvariantCulture);
            var numberSearch = int.Parse(find);

            var found = context.ClientIncoices.Select(
                s => s.Date == dateSearch || s.Client.Name == find || s.Id == numberSearch).ToList();
            foreach (var f in found)
            {
                this.ClientInvoicesGrid.ItemsSource = f.ToString();
            }


        }

        private void DeleteInvoiceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainWindow();
            dash.Show();
            this.Close();
        }
    }
}