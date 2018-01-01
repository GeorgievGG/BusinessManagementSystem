using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BmsWpf.Views.Forms
{
    using BMS.DataBaseData;
    using BMS.DataBaseModels;

    /// <summary>
    /// Interaction logic for PaymentSupplierForm.xaml
    /// </summary>
    public partial class PaymentSupplierForm : Window
    {
        public PaymentSupplierForm()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            var context = new BmsContex();
            var clients = context.Contragents.ToList();
            this.SupplierComboBox.ItemsSource = clients.Select(c => c.Name);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var context = new BmsContex();
            var clientArgs = this.SupplierComboBox.Text;
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
