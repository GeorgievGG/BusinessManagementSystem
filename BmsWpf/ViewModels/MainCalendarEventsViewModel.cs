namespace BmsWpf.ViewModels
{
    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Views.ChildWindows;
    using BmsWpf.Views.Forms;
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Input;

    public class MainCalendarEventsViewModel:ViewModelBase,IPageViewModel
    {
        private DataTable calendarEvents;
        private DataRowView selectedCalendarEvent;

        public ICommand WindowLoadedCommand;
        public ICommand DoubleClickCommand;
        public ICommand AddNewCommand;
        public ICommand EditCommand;
        public ICommand DeleteCommand;
        public ICommand BackCommand;

        public ICalendarEventService CalendarEventService { get; set; }
        public IViewManager ViewManager { get; set; }
        public string TimeView { get; set; }
        public Action CloseAction { get; set; }

        public MainCalendarEventsViewModel()
        {
            this.TimeView = DateTime.Today.ToShortDateString();
        }

        public string ViewName
        {
            get
            {
                return "Calendar Events";
            }
        }

        public DataRowView SelectedCalendarEvents
        {
            get
            {
                return this.selectedCalendarEvent;
            }
            set
            {
                this.selectedCalendarEvent = value;
                this.OnPropertyChanged(nameof(this.SelectedCalendarEvents));
            }
        }

        public DataTable CalendarEvents
        {
            get
            {
                return this.calendarEvents;
            }
            private set
            {
                this.calendarEvents = value;
                this.OnPropertyChanged(nameof(this.calendarEvents));
            }
        }

        public ICommand WindowLoaded
        {
            get
            {
                if (this.WindowLoadedCommand == null)
                {
                    this.WindowLoadedCommand = new RelayCommand(this.HandleLoadedCommand);
                }
                return this.WindowLoadedCommand;
            }
        }

        public ICommand DoubleClick
        {
            get
            {
                if (this.DoubleClickCommand == null)
                {
                    this.DoubleClickCommand = new RelayCommand(this.HandleEditCommand);
                }
                return this.DoubleClickCommand;
            }
        }

        public ICommand AddNew
        {
            get
            {
                if (this.AddNewCommand == null)
                {
                    this.AddNewCommand = new RelayCommand(this.HandleAddNewCommand);
                }
                return this.AddNewCommand;
            }
        }

        public ICommand Edit
        {
            get
            {
                if (this.EditCommand == null)
                {
                    this.EditCommand = new RelayCommand(this.HandleEditCommand);
                }
                return this.EditCommand;
            }
        }

        public ICommand Delete
        {
            get
            {
                if (this.DeleteCommand == null)
                {
                    this.DeleteCommand = new RelayCommand(this.HandleDeleteCommand);
                }
                return this.DeleteCommand;
            }
        }

        public ICommand Back
        {
            get
            {
                if (this.BackCommand == null)
                {
                    this.BackCommand = new RelayCommand(this.HandleBackCommand);
                }
                return this.BackCommand;
            }
        }

        private void HandleLoadedCommand(object parameter)
        {
            this.CalendarEvents = this.CalendarEventService.GetCalendarEventsAsDataTable();
        }

        private void HandleAddNewCommand(object parameter)
        {
            var addNewCalendarEventWindow = this.ViewManager.ComposeObjects<CalendarEventForm>();
            addNewCalendarEventWindow.Show();
            this.CloseAction();
        }

        private void HandleEditCommand(object parameter)
        {
            if (this.SelectedCalendarEvents == null)
            {
                MessageBox.Show("Please select an event to continue");
                return;
            }
            var addNewCalendarEventWindow = this.ViewManager.ComposeObjects<CalendarEventForm>();
            var vm = (CalendarEventFormViewModel)addNewCalendarEventWindow.DataContext;
            vm.SelectedCalendarEvent = this.SelectedCalendarEvents;
            addNewCalendarEventWindow.Show();
            this.CloseAction();
        }

        private void HandleDeleteCommand(object parameter)
        {
            if (this.SelectedCalendarEvents == null)
            {
                MessageBox.Show("Please select an event to continue");
                return;
            }
            var calendarEventId = (int)this.selectedCalendarEvent.Row.ItemArray[0];

            var result = string.Empty;

            try
            {
                result = this.CalendarEventService.Delete(calendarEventId);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            MessageBox.Show(result);
            var mainEventsWindow = this.ViewManager.ComposeObjects<MainCalendarEvents>();
            mainEventsWindow.Show();
            this.CloseAction();
        }

        private void HandleBackCommand(object parameter)
        {
            var mainWindow = this.ViewManager.ComposeObjects<MainWindow>();
            mainWindow.Show();
            this.CloseAction();
        }
    }
}