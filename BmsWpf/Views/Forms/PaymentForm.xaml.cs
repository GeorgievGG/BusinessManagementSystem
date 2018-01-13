namespace BmsWpf.Views.Forms
{
    using System;
    using System.Windows;

    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;

    /// <summary>
    /// Interaction logic for PaymentForm.xaml
    /// </summary>
    public partial class PaymentForm : Window
    {
        public PaymentForm()
        {
           this.InitializeComponent();
          //  FillComboBox();
        }

        public PaymentForm(IViewManager viewManager, IContragentService contragentService, IUserService userService, IProjectService projectService, IPaymentService paymentService)
        {
            this.InitializeComponent();

            PaymentViewModel vm = (PaymentViewModel)this.DataContext; 

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.ContragentService = contragentService;
            vm.UserService = userService;
            vm.ProjectService = projectService;
            vm.PaymentService = paymentService;
        }

        //private void FillComboBox()
        //{
        //    var context = new BmsContex();
        //    var clients = context.Contragents.ToList();
        //    this.ClientComboBox.ItemsSource = clients.Select(c => c.Name);
        //}

        //private void ButtonSave_Click(object sender, RoutedEventArgs e)
        //{
        //    var context = new BmsContex();
        //    var clientArgs = this.ClientComboBox.Text;
        //    var contragent = context.Contragents.FirstOrDefault(n => n.Name == clientArgs);
        //    var date = this.PaymentDatePicker.SelectedDate.Value.Date;
        //    var price = decimal.Parse(this.PriceBox.Text);
        //    var vat = decimal.Parse(this.VatBox.Text);
        //    var total = decimal.Parse(this.TotalBox.Text);

        //    var payment = new Payment()
        //    {
        //        ClientId = contragent.Id,
        //        SupplierId = 0, //needs change
        //        Date = date,
        //        Price = price,
        //        Vat = vat,
        //        Total = total
        //    };

        //    context.Payments.Add(payment);
        //    context.SaveChanges();
        //    MessageBox.Show("Payment was added");

        //    this.Close();
        //}

        //private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}