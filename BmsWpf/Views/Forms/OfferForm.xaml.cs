namespace BmsWpf.Views.Forms
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for OfferForm.xaml
    /// </summary>
    public partial class OfferForm : Window
    {
        public OfferForm()
        {
            InitializeComponent();
            //fillCombos();
        }

        public OfferForm(IViewManager viewManager, IInquiryService inquiryService, IContragentService contragentService, IUserService userService, IOfferService offerService)
        {
            InitializeComponent();

            OfferFormViewModel vm = (OfferFormViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.InquiryService = inquiryService;
            vm.ContragentService = contragentService;
            vm.UserService = userService;
            vm.OfferService = offerService;
        }

        //private void fillCombos()
        //{
        //    var db = new BmsContex();

        //    var clients = db.Contragents.ToList();
        //    ClientCombo.ItemsSource = clients.Select(c => c.Name);

        //    var inquiries = db.Inquiries.ToList();
        //    InquiryCombo.ItemsSource = inquiries.Select(c => c.Description);

        //    var creators = db.Users.ToList();
        //    CreatorCombo.ItemsSource = creators.Select(c => c.Username);

        //}

        //private void Back_Click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new MainOffers();
        //    dash.Show();
        //    this.Close();
        //}

        //private void Save_Click(object sender, RoutedEventArgs e)
        //{
        //    var db = new BmsContex();
        //    var client_form = ClientCombo.SelectedItem.ToString();
        //    var inquiry_form = InquiryCombo.SelectedItem.ToString();
        //    var creator_form = CreatorCombo.SelectedItem.ToString();
        //    var desc_form = offer_description.Text;
        //    var date_form = date.SelectedDate.ToString(); // 6.12.2017 г. 0:00:00
        //    var format = "d.MM.yyyy г. h:mm:ss";

        //    if (date_form == string.Empty)
        //    {
        //        MessageBox.Show("Please insert date");
        //        return;
        //    }
        //    if (desc_form == string.Empty)
        //    {
        //        MessageBox.Show("Please insert description");
        //        return;
        //    }

        //    var clientId = db.Contragents.Where(u => u.Name == client_form).SingleOrDefault().Id;
        //    var creatorId = db.Users.Where(u => u.Username == creator_form).SingleOrDefault().Id;
        //    var inquiryId = db.Inquiries.Where(u => u.Description == inquiry_form).SingleOrDefault().Id;
        //    var offerId = offer_id.Text;

        //    if (offerId == string.Empty)
        //    {
        //        var newOffer = new Offer
        //        {
        //            ClientId = clientId,
        //            CreatorId = creatorId,
        //            InquiryId = inquiryId,
        //            Description = desc_form,
        //            Date = DateTime.ParseExact(date_form, format, CultureInfo.InvariantCulture)
        //        };
        //        db.Offers.Add(newOffer);
        //        db.SaveChanges();
        //        MessageBox.Show("Offer Successfully created!");
        //    }
        //    else
        //    {
        //        var currentOffer = db.Offers.Where(o => o.Id.ToString() == offerId).SingleOrDefault();
        //        currentOffer.ClientId = clientId;
        //        currentOffer.CreatorId = creatorId;
        //        currentOffer.Date = DateTime.ParseExact(date_form, format, CultureInfo.InvariantCulture);
        //        currentOffer.Description = desc_form;
        //        db.SaveChanges();
        //        MessageBox.Show("Offer Edited successfully!");
        //    }
        //    var dash = new MainOffers();
        //    dash.Show();
        //    this.Close();
        //}
    }
}
