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

namespace BmsWpf.Views
{
    using System.Data;
    using System.Data.SqlClient;

    using BMS.DataBaseData;
    using BmsWpf.ViewModels;

    /// <summary>
    /// Interaction logic for LoginFormView.xaml
    /// </summary>
    public partial class LoginFormView : Window
    {
        public LoginFormView()
        {
            InitializeComponent();
            LoginFormViewModel vm = (LoginFormViewModel)this.DataContext; // this creates an instance of the ViewModel
            
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }
    }
}
