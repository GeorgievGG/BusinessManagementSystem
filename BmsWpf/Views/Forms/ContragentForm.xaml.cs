using BmsWpf.Views.ChildWindows;
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
using BmsWpf.ViewModels;

namespace BmsWpf.Views.Forms
{
    /// <summary>
    /// Interaction logic for ContragentForm.xaml
    /// </summary>
    public partial class ContragentForm : Window
    {
        public ContragentForm()
        {
			InitializeComponent();
	        var vm = new ContragentViewModel();
	        this.DataContext = vm;
	        if (vm.CloseAction == null)
		        vm.CloseAction = new Action(() => this.Close());
		}

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainContragents();
            dash.Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainContragents();
            dash.Show();
            this.Close();
        }

    }

}
