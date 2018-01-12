namespace BmsWpf.Views.ActiveProjectForms
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for IncomesTabView.xaml
    /// </summary>
    public partial class IncomesView : UserControl
    {
        public IncomesView()
        {
            InitializeComponent();
        }
    }

    public partial class IncomesView : UserControl
    {
        public IncomesView(IViewManager viewManager, IInvoiceService invoiceService/*, IPaymentService paymentService*/)
        {
            InitializeComponent();

            var vm = (PFIncomeViewModel)this.DataContext; // this creates an instance of the ViewModel

            vm.ViewManager = viewManager;
            vm.InvoiceService = invoiceService;
            //vm.PatmentService = paymentService;
        }
    }
}
