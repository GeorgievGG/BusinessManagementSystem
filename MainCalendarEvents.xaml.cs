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
    using BmsWpf.Behaviour;
    using BmsWpf.Views.Forms;

    /// <summary>
    /// Interaction logic for MainCalendarEvents.xaml
    /// </summary>
    public partial class MainCalendarEvents : Window
    {
 
        public MainCalendarEvents()
        {
            InitializeComponent();
        }

        private void Back_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainWindow();
            dash.Show();
            this.Close();
        }

        private void addEventButton_Click(object sender, RoutedEventArgs e)
        {
            var addNewEvent = new CalendarEventForm();
           addNewEvent.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
