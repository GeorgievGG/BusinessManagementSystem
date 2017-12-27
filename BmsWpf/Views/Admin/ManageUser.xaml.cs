using BMS.DataBaseData;
using BMS.DataBaseModels;
using BmsWpf.Services.Contracts;
using BmsWpf.ViewModels;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            //var db = new BmsContex();
            //var users = db.Users.ToArray();
            //UserBox.ItemsSource = users.Select(u => u.Username + " | " + u.Type.ToString());
        }

        public ManageUser(IViewManager viewManager, IUserService userService)
        {
            InitializeComponent();

            var vm = (ManageUserViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.UserService = userService;
        }

        //private void UserBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var selectedUser = UserBox.SelectedItem;
        //    if (selectedUser != null)
        //    {
        //        var values = selectedUser.ToString().Split('|').Select(s => s.Trim()).ToArray();

        //        var userName = values[0];
        //        var role = values[1];
        //        txtUser.Text = userName;
        //        txtUser.IsEnabled = false;

        //        txtRole.Items.Clear();
        //        if (txtRole.Items.Contains("Admin") && txtRole.Items.Contains("User")) return;

        //        txtRole.Items.Add("Admin");
        //        txtRole.Items.Add("User");

        //        if (role == "Admin") txtRole.SelectedIndex = 0;
        //        else if (role == "User") txtRole.SelectedIndex = 1;
        //    }
        //}

        //private void Save_Click(object sender, RoutedEventArgs e)
        //{
        //    var db = new BmsContex();
        //    var users = db.Users.ToArray();
        //    User changedUser = users.Where(u => u.Username == txtUser.Text).SingleOrDefault();
        //    var userRights = Enum.Parse(typeof(ClearenceType), txtRole.SelectionBoxItem.ToString());
        //    changedUser.Type = (ClearenceType)userRights;
        //    db.SaveChanges();
        //    MessageBox.Show("User rights changed successfully");
        //    UserBox.ItemsSource = users.Select(u => u.Username + " | " + u.Type.ToString());
        //}

        //private void Back_click(object sender, RoutedEventArgs e)
        //{
        //    AdminPanel dash = new AdminPanel();
        //    dash.Show();
        //    this.Close();
        //}
    }
}
