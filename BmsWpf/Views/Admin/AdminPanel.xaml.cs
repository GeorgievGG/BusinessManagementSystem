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

namespace BmsWpf.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            AddUser dash = new AddUser();
            dash.Show();
            this.Close();
        }

        private void ManageUsers(object sender, RoutedEventArgs e)
        {
            ManageUser dash = new ManageUser();
            dash.Show();
            this.Close();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            //LoginFormView dash = new LoginFormView();
            //dash.Show();
            this.Close();
        }
    }
}
