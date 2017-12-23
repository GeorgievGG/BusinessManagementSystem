using System;
using System.Collections.Generic;
using System.Data;
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
using System.Linq;
using BMS.DataBaseModels;

namespace BmsWpf.Views.Admin
{
    /// <summary>
    /// Interaction logic for ManageUser.xaml
    /// </summary>
    public partial class ManageUser : Window
    {
        public ManageUser()
        {
            InitializeComponent();
            var db = new BmsContex();
            var users = db.Users.ToArray();
            UserBox.ItemsSource = users.Select(u => u.Username + " | " + u.Type.ToString());
        }

        private void UserBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedUser = UserBox.SelectedItem;
            if (selectedUser != null)
            {
                var values = selectedUser.ToString().Split('|').Select(s => s.Trim()).ToArray();

                var userName = values[0];
                var role = values[1];
                txtUser.Text = userName;
                txtUser.IsEnabled = false;

                txtRole.Items.Clear();
                if (txtRole.Items.Contains("Admin") && txtRole.Items.Contains("User")) return;

                txtRole.Items.Add("Admin");
                txtRole.Items.Add("User");

                if (role == "Admin") txtRole.SelectedIndex = 0;
                else if (role == "User") txtRole.SelectedIndex = 1;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var db = new BmsContex();
            var users = db.Users.ToArray();
            User changedUser = users.Where(u => u.Username == txtUser.Text).SingleOrDefault();
            var userRights = Enum.Parse(typeof(ClearenceType), txtRole.SelectionBoxItem.ToString());
            changedUser.Type = (ClearenceType)userRights;
            db.SaveChanges();
            MessageBox.Show("User rights changed successfully");
            UserBox.ItemsSource = users.Select(u => u.Username + " | " + u.Type.ToString());
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            AdminPanel dash = new AdminPanel();
            dash.Show();
            this.Close();
        }
    }
}
