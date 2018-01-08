namespace BmsWpf.Views.Forms
{
    using System;
    using System.Linq;
    using System.Windows;

    using BmsWpf.ViewModels;
    using BmsWpf.Views.ChildWindows;

    using BMS.DataBaseData;
    using BMS.DataBaseModels;
    using BMS.DataBaseModels.Enums;
    using BmsWpf.Services.Contracts;

    /// <summary>
    /// Interaction logic for CalendarEventForm.xaml
    /// </summary>
    public partial class CalendarEventForm : Window
    {
        public CalendarEventForm()
        {

            InitializeComponent();
            var vm = new CalendarEventFormViewModel();
	        this.DataContext = vm;
	        if (vm.CloseAction == null)
		        vm.CloseAction = new Action(() => this.Close());
         //   FillComboBox();
        }

        public CalendarEventForm(IViewManager viewManager, ICalendarEventsService calendarEventService)
        {
            InitializeComponent();

            CalendarEventFormViewModel vm = (CalendarEventFormViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.CalendarEventService = calendarEventService;
        }


        //private void FillComboBox()
        //{
        //    var context = new BmsContex();
        //    var creators = context.Users.ToList();
        //    this.CreatorBox.ItemsSource = creators.Select(c => c.Username);
        //}

        //private void Button_Click_Save(object sender, RoutedEventArgs e)
        //{
        //    var context = new BmsContex();
        //    var title = this.TitleBox.Text;
        //    var description = this.DescriptionBox.Text;
        //    var startDate = this.StartDateBox.SelectedDate.Value.Date;
        //    var endDate = this.EndDateBox.SelectedDate.Value.Date;


        //    Enum.TryParse(this.ColorPickerBox.Text, out Color color);
        //    var creatorArgs = this.CreatorBox.Text;
        //    var creator = context.Users.FirstOrDefault(u => u.Username == creatorArgs);

        //    var newCalendarEvent = new CalendarEvent
        //    {
        //        Title = title,
        //        Description = description,
        //        Color = color,
        //        StartTime = startDate,
        //        EndTime = endDate,
        //        CreatorId = creator.Id,
        //    };

        //    context.CalendarEvents.Add(newCalendarEvent);
        //    context.SaveChanges();
        //    MessageBox.Show("The event was created successfully");

        //    var dash = new MainCalendarEvents();
        //    dash.Show();
        //    this.Close();
        //}

        //private void Button_Click_Edit(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Button_Click_Back(object sender, RoutedEventArgs e)
        //{
        //    var dash = new MainCalendarEvents();
        //    dash.Show();
        //    this.Close();
        //}
    }
}
