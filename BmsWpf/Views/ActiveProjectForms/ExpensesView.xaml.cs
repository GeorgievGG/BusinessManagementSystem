namespace BmsWpf.Views.ActiveProjectForms
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for ExpensesTabView.xaml
    /// </summary>
    public partial class ExpensesView : UserControl
    {
        public ExpensesView()
        {
            InitializeComponent();
        }

        public ExpensesView(IViewManager viewManager, IInvoiceService invoiceService/*, IPaymentService paymentService*/)
        {
            InitializeComponent();

            var vm = (PFExpensesViewModel)this.DataContext; // this creates an instance of the ViewModel

            vm.ViewManager = viewManager;
            vm.InvoiceService = invoiceService;
            //vm.PatmentService = paymentService;
        }
    }
}
