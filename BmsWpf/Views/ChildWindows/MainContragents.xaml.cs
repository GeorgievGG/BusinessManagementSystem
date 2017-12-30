namespace BmsWpf.Views.ChildWindows
{
    using BMS.DataBaseData;
    using BmsWpf.Views.Forms;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Data;
    using System.Linq;
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

        private void ContragentDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGrid();
        }

        public void fillingDataGrid()
        {
            var db = new BmsContex();
            DataTable dt = new DataTable();
            DataColumn contragentId = new DataColumn("Id", typeof(int));
            DataColumn companyName = new DataColumn("Company Name", typeof(string));
            DataColumn vat = new DataColumn("VAT Number", typeof(string));
            DataColumn pin = new DataColumn("Personal Id", typeof(string));
            DataColumn phone = new DataColumn("Telephone", typeof(string));
            DataColumn email = new DataColumn("Email", typeof(string));
            DataColumn contactPerson = new DataColumn("Contact Person", typeof(string));
            DataColumn address = new DataColumn("Address", typeof(string));
            DataColumn bankDetails = new DataColumn("Bank Details", typeof(string));
            DataColumn notes = new DataColumn("Notes", typeof(string));

            dt.Columns.Add(contragentId);
            dt.Columns.Add(companyName);
            dt.Columns.Add(vat);
            dt.Columns.Add(pin);
            dt.Columns.Add(contactPerson);
            dt.Columns.Add(phone);
            dt.Columns.Add(email);
            dt.Columns.Add(address);
            dt.Columns.Add(bankDetails);
            dt.Columns.Add(notes);


            var contragents = db.Contragents.ToArray();

            foreach (var contragent in contragents)
            {
                DataRow row = dt.NewRow();
                row[0] = contragent.Id;
                row[1] = contragent.Name;
                row[2] = contragent.PersonalVatNumber;
                row[3] = contragent.PersonalIndentityNumber;
                row[4] = contragent.PersonForContact;
                row[5] = contragent.Telephone;
                row[6] = contragent.Email;
                row[7] = contragent.Address;
                row[8] = contragent.BankDetails;
                row[9] = contragent.Description;
                dt.Rows.Add(row);
            }
            ContragentDataGrid.ItemsSource = dt.DefaultView;
        }

        private void Add_New_Click(object sender, RoutedEventArgs e)
        {
            var dash = new ContragentForm();
            dash.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            openEditForm();
        }

        private void ContragentDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            openEditForm();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            var dash = new MainWindow();
            dash.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var db = new BmsContex();
            DataRowView dataRow = (DataRowView)ContragentDataGrid.SelectedItem;
            var itemId = dataRow.Row.ItemArray[0].ToString();
            var currentContragent = db.Contragents.Where(o => o.Id.ToString() == itemId).SingleOrDefault();
            db.Contragents.Remove(currentContragent);
            db.SaveChanges();
            MessageBox.Show("Contragent Removed Successfully!");
            var dash = new MainContragents();
            dash.Show();
            this.Close();
        }

        private void openEditForm()
        {
            var dash = new ContragentForm();
            dash.Show();
            this.Close();
        }
    }
}
