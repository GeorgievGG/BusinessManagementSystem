namespace BmsWpf.Views.Forms
{
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
    using BMS.DataBaseData;
    using BMS.DataBaseModels;
    using BmsWpf.Sessions;
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;

    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        public ProjectWindow()
        {
            InitializeComponent();

            ProjectFormViewModel vm = (ProjectFormViewModel)this.DataContext;
        }

        public ProjectWindow(IViewManager viewManager)
        {
            InitializeComponent();
            //ProjectTabs.ItemContainerStyle = this.FindResource("Right90") as Style;

            ProjectFormViewModel vm = (ProjectFormViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
        }

        //private void ProjectTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void FillComboBoxes()
        //{
        //    var context = new BmsContex();
        //    var clients = context.Contragents.ToList();
        //    this.ClientBox.ItemsSource = clients.Select(c => c.Name);
        //    var offers = context.Offers.ToList();
        //    this.OfferComboBox.ItemsSource = offers.Select(o => o.Id);
        //    var inquires = context.Inquiries.ToList();
        //    this.InquireComboBox.ItemsSource = inquires.ToList().Select(q => q.Id);
        //    var creators = context.Users.ToList();
        //    this.creatorBox.Text = Session.Instance.Username;

        //}

        //private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void ButtonSave_Click(object sender, RoutedEventArgs e)
        //{
        //    var context = new BmsContex();
        //    var name = this.NameTextBox.Text;
        //    var offerArgs = int.Parse(this.OfferComboBox.Text);
        //    var offer = context.Offers.FirstOrDefault(o => o.Id == offerArgs);
        //    var inquireArgs = int.Parse(this.InquireComboBox.Text);
        //    var inquire = context.Inquiries.FirstOrDefault(i => i.Id == inquireArgs);
        //    var clientArgs = this.ClientBox.Text;
        //    var client = context.Contragents.FirstOrDefault(n => n.Name == clientArgs);
        //    var contact = this.ContactTextBox.Text;
        //    var phone = this.PhoneBox.Text;
        //    var cretorArgs = this.creatorBox.Text;
        //    var creator = context.Users.FirstOrDefault(u => u.Username == cretorArgs);
        //    var startDate = this.StartDatePicker.SelectedDate.Value.Date;
        //    var timeLimit = this.LimitDatePicker.SelectedDate.Value.Date;
        //    DateTime? endDate = this.EndDatePicker.SelectedDate;

        //    var project = new Project()
        //    {
        //        Name = name,
        //        Creator = creator,
        //        Contragent = client,
        //        Offer = offer,
        //        OfferId = offerArgs,
        //        Inquiry = inquire,
        //        StartDate = startDate,
        //        DeadLine = timeLimit,
        //        EndDate = endDate,
        //        //ContactPerson = contact,
        //        //ContactPhone = phone,
        //    };

        //    context.Projects.Add(project);
        //    context.SaveChanges();
        //    MessageBox.Show("Project was saved");
        //    this.Close();
        //}

        //private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void AddNewPaymentButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var newPayment = new PaymentClientForm();
        //    newPayment.Show();
        //}

        //private void AddInvoiceButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var newClientInvoice = new InvoiceForm();
        //    newClientInvoice.Show();
        //}

        //private void EditInvoicesButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void EditSupplierPaymentsButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void AddNewSupplierInvoiceButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var newSupplierInvoice = new InvoiceForm();
        //    newSupplierInvoice.Show();
        //}

        //private void EditSupplierInvocesButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void ButtonSupplierPayment_Click(object sender, RoutedEventArgs e)
        //{
        //    var newPayment = new PaymentSupplierForm();
        //    newPayment.Show();
        //}

        //private void EditSuppliersPayments_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void AddNewNoteButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var newNote = new NoteForm();
        //    newNote.Show();
        //}

        //private void EditNotesButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void DeleteNoteButton_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}