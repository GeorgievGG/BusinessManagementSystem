namespace BmsWpf.Views.Forms
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using BmsWpf.Views.ChildWindows;

    using BMS.DataBaseData;
    using BMS.DataBaseModels;
    using BMS.DataBaseModels.Enums;

    /// <summary>
    /// Interaction logic for CalendarEventForm.xaml
    /// </summary>
    public partial class CalendarEventForm : Window
    {
        public CalendarEventForm()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            var context = new BmsContex();
            var creators = context.Users.ToList();
            this.CreatorBox.ItemsSource = creators.Select(c => c.Username);
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            var db = new BmsContex();
            var title = this.TitleBox.Text;
            var description = this.DescriptionBox.Text;
            var startDate = this.StartDateBox.SelectedDate.Value.Date;
            var endDate = this.EndDateBox.SelectedDate.Value.Date;
            Enum.TryParse(this.ColorPickerBox.Text, out Color color);
            var creatorArgs = this.CreatorBox.ToString();
            var creator = db.Users.FirstOrDefault(u => u.Username == creatorArgs).Id;



            var newCalendarEvent = new CalendarEvent
            {
                Title = title,
                Description = description,
                Color = color,
                StartTime = startDate,
                EndTime = endDate,
                CreatorId = creator,
            };

            db.CalendarEvents.Add(newCalendarEvent);
            db.SaveChanges();
            MessageBox.Show("The event was created successfully");

            var dash = new MainCalendarEvents();
            dash.Show();
            this.Close();

        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            var dash = new MainCalendarEvents();
            dash.Show();
            this.Close();
        }

        private void Creator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
