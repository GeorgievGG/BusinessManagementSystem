namespace BmsWpf.Views.ChildWindows
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainInquiries.xaml
    /// </summary>
    public partial class MainInquiries : Window
    {
        public MainInquiries()
        {
            InitializeComponent();
        }

        public MainInquiries(IViewManager viewManager, IInquiryService inquiryService)
        {
            InitializeComponent();

            MainInquiriesViewModel vm = (MainInquiriesViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
            
            vm.ViewManager = viewManager;
            vm.InquiryService = inquiryService;
        }

        //private void Add_New_Click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new InquireForm();
        //    dash.Show();
        //    this.Close();
        //}

        //private void Back_click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new MainWindow();
        //    dash.Show();
        //    this.Close();
        //}

        //public void fillingDataGrid()
        //{
        //    var db = new BmsContex();
        //    DataTable dt = new DataTable();
        //    DataColumn inquiryId = new DataColumn("Id", typeof(int));
        //    DataColumn creator = new DataColumn("Creator", typeof(string));
        //    DataColumn client = new DataColumn("Client", typeof(string));
        //    DataColumn description = new DataColumn("Description", typeof(string));
        //    DataColumn date = new DataColumn("Date", typeof(DateTime));

        //    dt.Columns.Add(inquiryId);
        //    dt.Columns.Add(creator);
        //    dt.Columns.Add(client);
        //    dt.Columns.Add(description);
        //    dt.Columns.Add(date);


        //    var inquiries = db.Inquiries.Include(e => e.Client).Include(e => e.Creator).ToArray();

        //    foreach (var inqu in inquiries)
        //    {
        //        DataRow row = dt.NewRow();
        //        row[0] = inqu.Id;
        //        row[1] = inqu.Creator.Username;
        //        row[2] = inqu.Client.Name;
        //        row[3] = inqu.Description;
        //        row[4] = inqu.Date;
        //        dt.Rows.Add(row);
        //    }


        //    InquDataGrid.ItemsSource = dt.DefaultView;
        //}

        //private void InquDataGrid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    this.fillingDataGrid();
        //}


        //private void Edit_Click(object sender, RoutedEventArgs e)
        //{
        //    EditForm();
        //}

        //private void InquDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    EditForm();
        //}

        //private void EditForm()
        //{
        //    var db = new BmsContex();
        //    var inqu = db.Inquiries.Include(i => i.Client).ToList();
          
        //    var dash = new InquireForm();
        //    DataRowView dataRow = (DataRowView)InquDataGrid.SelectedItem;
        //    Inquiry currentInqu = inqu.Where(u => u.Id.ToString() == dataRow.Row.ItemArray[0].ToString()).SingleOrDefault();
        //    dash.inquiry_id.Text = dataRow.Row.ItemArray[0].ToString();
        //    dash.CreatorCombo.SelectedItem = dataRow.Row.ItemArray[1].ToString();
        //    dash.ClientCombo.SelectedItem = dataRow.Row.ItemArray[2].ToString();
        //    dash.description_form.Text = dataRow.Row.ItemArray[3].ToString();
        //    dash.poc_form.Text = currentInqu.Client.PersonForContact.ToString();
        //    dash.email_form.Text = currentInqu.Client.Email.ToString();
        //    dash.phone_form.Text = currentInqu.Client.Telephone.ToString();
        //    dash.Show();
        //    this.Close();
        //}


        //private void Delete_Click(object sender, RoutedEventArgs e)
        //{
        //    var db = new BmsContex();
        //    DataRowView dataRow = (DataRowView)InquDataGrid.SelectedItem;
        //    var itemId = dataRow.Row.ItemArray[0].ToString();
        //    var currentInquiry = db.Inquiries.Where(o => o.Id.ToString() == itemId).SingleOrDefault();
        //    db.Inquiries.Remove(currentInquiry);
        //    try
        //    {
        //        db.SaveChanges();
        //        MessageBox.Show("Inquire Removed Successfully!");
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("You cannot delete inquiry that is used in an offer!");
        //        return;
        //    } 

        //    var dash = new MainInquiries();
        //    dash.Show();
        //    this.Close();

        //}
    }
}
