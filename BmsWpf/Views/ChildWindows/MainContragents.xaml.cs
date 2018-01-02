namespace BmsWpf.Views.ChildWindows
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
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

        public MainContragents(IViewManager viewManager, IContragentService contragentService)
        {
            InitializeComponent();

            MainContragentsViewModel vm = (MainContragentsViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.ContragentService = contragentService;
        }

        //      private void ContragentDataGrid_Loaded(object sender, RoutedEventArgs e)
        //      {
        //          this.fillingDataGrid();
        //      }

        //      public void fillingDataGrid()
        //      {
        //          var db = new BmsContex();
        //          DataTable dt = new DataTable();
        //          DataColumn contragentId = new DataColumn("Id", typeof(int));
        //          DataColumn companyName = new DataColumn("Company Name", typeof(string));
        //          DataColumn vat = new DataColumn("VAT Number", typeof(string));
        //          DataColumn pin = new DataColumn("Personal Id", typeof(string));
        //          DataColumn phone = new DataColumn("Telephone", typeof(string));
        //          DataColumn email = new DataColumn("Email", typeof(string));
        //          DataColumn contactPerson = new DataColumn("Contact Person", typeof(string));
        //          DataColumn address = new DataColumn("Address", typeof(string));
        //          DataColumn bankDetails = new DataColumn("Bank Details", typeof(string));
        //          DataColumn notes = new DataColumn("Notes", typeof(string));

        //          dt.Columns.Add(contragentId);
        //          dt.Columns.Add(companyName);
        //          dt.Columns.Add(vat);
        //          dt.Columns.Add(pin);
        //          dt.Columns.Add(contactPerson);
        //          dt.Columns.Add(phone);
        //          dt.Columns.Add(email);
        //          dt.Columns.Add(address);
        //          dt.Columns.Add(bankDetails);
        //          dt.Columns.Add(notes);


        //          var contragents = db.Contragents.ToArray();

        //          foreach (var contragent in contragents)
        //          {
        //              DataRow row = dt.NewRow();
        //              row[0] = contragent.Id;
        //              row[1] = contragent.Name;
        //              row[2] = contragent.PersonalVatNumber;
        //              row[3] = contragent.PersonalIndentityNumber;
        //              row[4] = contragent.PersonForContact;
        //              row[5] = contragent.Telephone;
        //              row[6] = contragent.Email;
        //              row[7] = contragent.Address;
        //              row[8] = contragent.BankDetails;
        //              row[9] = contragent.Description;
        //              dt.Rows.Add(row);
        //          }
        //          ContragentDataGrid.ItemsSource = dt.DefaultView;
        //      }

        //      private void Add_New_Click(object sender, RoutedEventArgs e)
        //      {
        //          var dash = new ContragentForm();
        //          dash.Show();
        //          this.Close();
        //      }

        //      private void Edit_Click(object sender, RoutedEventArgs e)
        //      {
        //       DataRowView dataRow = (DataRowView)ContragentDataGrid.SelectedItem;
        //       if (dataRow == null)
        //       {
        //		MessageBox.Show("Please select a contragent to continue");
        //        return;
        //	}
        //	EditForm();
        //}

        //      private void ContragentDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //      {
        //	EditForm();
        //}

        //private void EditForm()
        //      {
        //          var db = new BmsContex();
        //          var contr = db.Contragents.ToList();

        //          var dash = new ContragentForm();
        //          DataRowView dataRow = (DataRowView)ContragentDataGrid.SelectedItem;
        //          Contragent currentContr = contr.Where(u => u.Id.ToString() == dataRow.Row.ItemArray[0].ToString()).SingleOrDefault();
        //	dash.Show();
        //       dash.Name.Text = currentContr.Name.ToString();
        //       dash.PersonalVatNumber.Text = currentContr.PersonalVatNumber.ToString();
        //       dash.PersonalIndentityNumber.Text = currentContr.PersonalIndentityNumber.ToString();
        //       dash.PersonForContact.Text = currentContr.PersonForContact.ToString();
        //       dash.Telephone.Text = currentContr.Telephone.ToString();
        //       dash.Email.Text = currentContr.Email.ToString();
        //       dash.Address.Text = currentContr.Address.ToString();
        //       dash.BankDetails.Text = currentContr.BankDetails.ToString();
        //       dash.Description.Text = currentContr.Description.ToString();
        //          //dash.Show();
        //          this.Close();
        //      }

        //      private void Back_click(object sender, RoutedEventArgs e)
        //      {
        //          var dash = new MainWindow();
        //          dash.Show();
        //          this.Close();
        //      }

        //      private void Delete_Click(object sender, RoutedEventArgs e)
        //      {
        //          var db = new BmsContex();
        //          DataRowView dataRow = (DataRowView)ContragentDataGrid.SelectedItem;
        //          var itemId = dataRow.Row.ItemArray[0].ToString();
        //          var currentContragent = db.Contragents.Where(o => o.Id.ToString() == itemId).SingleOrDefault();
        //          db.Contragents.Remove(currentContragent);
        //          db.SaveChanges();
        //          MessageBox.Show("Contragent Removed Successfully!");
        //          var dash = new MainContragents();
        //          dash.Show();
        //          this.Close();
        //      }

        //        private void openEditForm()
        //        {
        //            var dash = new ContragentForm();
        //            dash.Show();
        //            this.Close();
        //        }
    }
}
