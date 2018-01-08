namespace BmsWpf.Views.Forms
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for InvoiceClientForm.xaml
    /// </summary>
    public partial class InvoiceForm : Window
    {
        public InvoiceForm()
        {
            InitializeComponent();
        }

        public InvoiceForm(IViewManager viewManager, IInvoiceService invoiceService, IContragentService contragentService, IProjectService projectService)
        {
            InitializeComponent();

            InvoiceFormViewModel vm = (InvoiceFormViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
            if (vm.LockInvoiceNumAction == null)
                vm.LockInvoiceNumAction = new Action(() => this.NumberTextBox.IsEnabled = false);
            if (vm.UnlockInvoiceNumAction == null)
                vm.UnlockInvoiceNumAction = new Action(() => this.NumberTextBox.IsEnabled = true);

            vm.ViewManager = viewManager;
            vm.InvoiceService = invoiceService;
            vm.ContragentService = contragentService;
            vm.ProjectService = projectService;
        }
    }
}
