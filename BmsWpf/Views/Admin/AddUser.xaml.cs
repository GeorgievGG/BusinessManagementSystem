namespace BmsWpf.Views.Admin
{
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
    using BMS.DataBaseData;
    using BMS.DataBaseModels;
    using System.Security.Cryptography;
    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;

    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
            DataContext = new AddUserViewModel();
        }

        public AddUser(IBmsData bmsData, IViewManager viewManager, IUserService userService)
        {
            InitializeComponent();
            DataContext = new AddUserViewModel();

            var vm = (AddUserViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.BmsData = bmsData;
            vm.ViewManager = viewManager;
            vm.UserService = userService;
        }

        //private void Save_click(object sender, RoutedEventArgs e)
        //{
        //    using (var db = new BmsContex())
        //    {
        //        var password = PasswordBox.Password;
        //        var repeatedPass = RepeatPasswordBox.Password;
        //        var username = UsernameBox.Text;
        //        var userRights = Enum.Parse(typeof(ClearenceType), dropdown.SelectionBoxItem.ToString());

        //        if (password != repeatedPass)
        //        {
        //            MessageBox.Show("Passwords does not match");
        //            return;
        //        }

        //        var usernameAlreadyExists = db.Users.SingleOrDefault(u => u.Username == username);

        //        if (usernameAlreadyExists != null)
        //        {
        //            MessageBox.Show("Username already exists");
        //            return;
        //        }

        //        var hashedPass = HashToSha1(password);

        //        var newUser = new User
        //        {
        //            Username = username,
        //            Password = hashedPass,
        //            Type = (ClearenceType)userRights
        //        };

        //        db.Add(newUser);
        //        db.SaveChanges();
        //        MessageBox.Show("User has been successfully registered");

        //        AdminPanel dash = new AdminPanel();
        //        dash.Show();
        //        this.Close();

        //    }
        //}

        //private static string HashToSha1(string pass)
        //{
        //    using (SHA1Managed sha1 = new SHA1Managed())
        //    {
        //        var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
        //        var sb = new StringBuilder(hash.Length * 2);

        //        foreach (byte b in hash)
        //        {
        //            // can be "x2" if you want lowercase
        //            sb.Append(b.ToString("X2"));
        //        }

        //        return sb.ToString();
        //    }
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    AdminPanel dash = new AdminPanel();
        //    dash.Show();
        //    this.Close();
        //}
    }
}
