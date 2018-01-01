namespace BmsWpf.Views.Forms
{
    using System;
    using System.Linq;
    using System.Windows;

    using BMS.DataBaseData;
    using BMS.DataBaseModels;

    /// <summary>
    /// Interaction logic for PaymentForm.xaml
    /// </summary>
    public partial class PaymentClientForm : Window
    {
        public PaymentClientForm()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            var context = new BmsContex();
            var clients = context.Contragents.ToList();
            this.ClientComboBox.ItemsSource = clients.Select(c => c.Name);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var context = new BmsContex();
            var clientArgs = this.ClientComboBox.Text;
            var contragent = context.Contragents.FirstOrDefault(n => n.Name == clientArgs);
            var date = this.PaymentDatePicker.SelectedDate.Value.Date;
            var price = decimal.Parse(this.PriceBox.Text);
            var vat = decimal.Parse(this.VatBox.Text);
            var total = decimal.Parse(this.TotalBox.Text);

            var payment = new Payment()
            {
                ContragentId = contragent.Id,
                Date = date,
                Price = price,
                Vat = vat,
                Total = total
            };

            context.Payments.Add(payment);
            context.SaveChanges();
            MessageBox.Show("Payment was added");

            this.Close();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}