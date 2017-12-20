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

    /// <summary>
    /// Interaction logic for LoginFormView.xaml
    /// </summary>
    public partial class LoginFormView : UserControl
    {
        public LoginFormView()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Copy_OnClick(object sender, RoutedEventArgs e)
        {
            //SqlConnection sqlCon = new SqlConnection(ServerConfiguration.ConfigurationString);
            //try
            //{
            //    if (sqlCon.State == ConnectionState.Closed)
            //        sqlCon.Open();
            //    String query = "SELECT COUNT(1) FROM tblUser WHERE Username=@Username AND Password=@Password";
            //    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            //    sqlCmd.CommandType = CommandType.Text;
            //    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            //    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
            //    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            //    if (count == 1)
            //    {
            //        MainWindow dashboard = new MainWindow();
            //        dashboard.Show();
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Username or password is incorrect.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    sqlCon.Close();
            //}
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Environment.Exit(0);
        }
    }
}
