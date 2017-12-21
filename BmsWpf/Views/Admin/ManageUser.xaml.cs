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
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void fillingDataGrid()
        {
            var db = new BmsContex();
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("Id", typeof(string));
            DataColumn name = new DataColumn("Username", typeof(string));
            DataColumn type = new DataColumn("Type", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(name);
            dt.Columns.Add(type);

            var users = db.Users.ToArray();

            foreach (var user in users)
            {
                DataRow row = dt.NewRow();
                row[0] = user.Id;
                row[1] = user.Username;
                row[2] = user.Type;
                dt.Rows.Add(row);
            }


            UsersDataGrid.ItemsSource = dt.DefaultView;
        }

        private void UsersDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel dash = new AdminPanel();
            dash.Show();
            this.Close();
        }
    }
}
