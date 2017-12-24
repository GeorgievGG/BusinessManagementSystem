using BmsWpf.Views.Forms;
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

namespace BmsWpf.Views.ChildWindows
{
    /// <summary>
    /// Interaction logic for ActiveProjects.xaml
    /// </summary>
    public partial class ActiveProjects : Window
    {
        public ActiveProjects()
        {
            InitializeComponent();
        }

        private void Add_New_Click(object sender, RoutedEventArgs e)
        {
            var dash = new ProjectForm();
            dash.Show();
            this.Close();
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {
            var dash = new ProjectForm();
            dash.Show();
            this.Close();
        }

        private void Back_click(object sender, RoutedEventArgs e)
        {
            var dash = new MainWindow();
            dash.Show();
            this.Close();
        }
    }
}
