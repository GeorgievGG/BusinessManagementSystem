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

    using BMS.DataBaseData;
    using BMS.DataBaseModels;

    /// <summary>
    /// Interaction logic for MainCalendarEvents.xaml
    /// </summary>
    public partial class MainCalendarEvents : Window
    {
 
        public MainCalendarEvents()
        {
            InitializeComponent();
            ShowTime();
            FillGrid();
            DataContext = new BmsContex();
        }

        private void ShowTime()
        {
            this.timeView.Content = DateTime.Today.ToShortDateString();
        }

        private void FillGrid()
        {
            var context = new BmsContex();
            var events = context.CalendarEvents.Where(ce => ce.EndTime > DateTime.Now).ToList();
            this.eventView.ItemsSource = events;

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

        private void EditEventButton_OnClickEventButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteEventButton_OnClickEventButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
