namespace BmsWpf.Views.ChildWindows
{
    using System;
    using System.Windows;

    using BmsWpf.Services.Contracts;
    using BmsWpf.ViewModels;

    /// <summary>
    /// Interaction logic for MainCalendarEvents.xaml
    /// </summary>
    public partial class MainCalendarEvents : Window
    {

        public MainCalendarEvents()
        {
            InitializeComponent();
            ShowTime();
            //FillGrid();
            //this.DataContext = new BmsContex();
        }

        private void ShowTime()
        {
            this.timeView.Content = DateTime.Today.ToShortDateString();
        }

        public MainCalendarEvents(IViewManager viewManager, ICalendarEventsService calendarEventService)
        {
            InitializeComponent();

            MainCalendarEventsViewModel vm = (MainCalendarEventsViewModel)this.DataContext; // this creates an instance of the ViewModel

            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());

            vm.ViewManager = viewManager;
            vm.CalendarEventService = calendarEventService;
        }
        //private void FillGrid()
        //{
        //    var context = new BmsContex();
        //    var events = context.CalendarEvents.Where(ce => ce.EndTime > DateTime.Now).ToList();
        //    this.eventView.ItemsSource = events;

        //}

        //private void Back_OnClickButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var dash = new MainWindow();
        //    dash.Show();
        //    this.Close();
        //}

        //private void addEventButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var addNewEvent = new CalendarEventForm();
        //    addNewEvent.Show();
        //    this.Close();
        //}

        //private void EditEventButton_OnClickEventButton_Click(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void DeleteEventButton_OnClickEventButton_Click(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void eventView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
