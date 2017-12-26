namespace BmsWpf.Views.Admin
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;
    using BmsWpf.Views.Forms;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        public AdminPanel(IViewManager viewManager)
        {
            InitializeComponent();

            var vm = (AdminPanelViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
        }
    }
}
