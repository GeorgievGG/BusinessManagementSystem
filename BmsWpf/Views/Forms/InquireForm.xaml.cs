namespace BmsWpf.Views.Forms
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for InquireForm.xaml
    /// </summary>
    public partial class InquireForm : Window
    {
        public InquireForm()
        {
            InitializeComponent();
            //fillCombos();
        }

        public InquireForm(IViewManager viewManager, IInquiryService inquiryService, IContragentService contragentService, IUserService userService)
        {
            InitializeComponent();

            InquireFormViewModel vm = (InquireFormViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.InquiryService = inquiryService;
            vm.ContragentService = contragentService;
            vm.UserService = userService;
        }

    //    private void fillCombos()
    //    {
    //        var db = new BmsContex();

    //        var clients = db.Contragents.ToList();
    //        ClientCombo.ItemsSource = clients.Select(c => c.Name);

    //        var creators = db.Users.ToList();
    //        CreatorCombo.ItemsSource = creators.Select(c => c.Username);
    //    }

    //    private void Back_Click(object sender, RoutedEventArgs e)
    //    {
    //        var dash = new MainInquiries();
    //        dash.Show();
    //        this.Close();
    //    }

    //    private void ClientCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //    {
    //        var db = new BmsContex();
    //        var inqu = db.Inquiries.Include(i => i.Client).ToList();
    //        var clients = db.Contragents.ToList();

    //        var clientName = ClientCombo.SelectedItem.ToString();
    //        var currentClient = clients.Where(i => i.Name == clientName).SingleOrDefault();
    //        poc_form.Text = currentClient.PersonForContact;
    //        email_form.Text = currentClient.Email;
    //        phone_form.Text = currentClient.Telephone;
    //    }

    //    private void Save_Click(object sender, RoutedEventArgs e)
    //    {
    //        var db = new BmsContex();
    //        var client_form = ClientCombo.SelectedItem.ToString();
    //        var creator_form = CreatorCombo.SelectedItem.ToString();
    //        var desc_form = description_form.Text;
    //        var date_form = date.SelectedDate.ToString(); // 6.12.2017 г. 0:00:00
    //        var format = "d.MM.yyyy г. h:mm:ss";

    //        if (date_form == string.Empty)
    //        {
    //            MessageBox.Show("Please insert date");
    //            return;
    //        }
    //        if (desc_form == string.Empty)
    //        {
    //            MessageBox.Show("Please insert description");
    //            return;
    //        }

    //        var clientId = db.Contragents.Where(u => u.Name == client_form).SingleOrDefault().Id;
    //        var creatorId = db.Users.Where(u => u.Username == creator_form).SingleOrDefault().Id;
    //        var inquiryId = inquiry_id.Text;

    //        if (inquiryId == string.Empty)
    //        {
    //            var newInquiry = new Inquiry
    //            {
    //                ClientId = clientId,
    //                CreatorId = creatorId,
    //                Description = description_form.Text,
    //                Date = DateTime.ParseExact(date_form, format, CultureInfo.InvariantCulture)
    //            };
    //            db.Inquiries.Add(newInquiry);
    //            db.SaveChanges();
    //            MessageBox.Show("Inquiry Successfully created!");
    //        }
    //        else
    //        {
    //            var currentInquiry = db.Inquiries.Where(o => o.Id.ToString() == inquiryId).SingleOrDefault();
    //            currentInquiry.ClientId = clientId;
    //            currentInquiry.CreatorId = creatorId;
    //            currentInquiry.Date = DateTime.ParseExact(date_form, format, CultureInfo.InvariantCulture);
    //            currentInquiry.Description = description_form.Text;
    //            db.SaveChanges();
    //            MessageBox.Show("Inquiry Edited successfully!");
    //        }
    //        var dash = new MainInquiries();
    //        dash.Show();
    //        this.Close();
    //    }
    }
}
