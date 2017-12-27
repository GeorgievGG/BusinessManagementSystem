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
        }


		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void VATNumber_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainContragents();
            dash.Show();
            this.Close();
        }

		private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
		{

		}
	}

}
