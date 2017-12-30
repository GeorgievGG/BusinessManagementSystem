namespace BmsWpf.ViewModels
{
    using System;
    using System.Windows.Input;

    using BmsWpf.Behaviour;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Sessions;
    using BmsWpf.Views.Admin;
    using BmsWpf.Views.ChildWindows;
    using BmsWpf.Views.Forms;

    using BMS.DataBaseData;
    using BMS.DataBaseModels;
    using BMS.DataBaseModels.Enums;

    class CalendarEventsViewModel : ViewModelBase, IPageViewModel
    {

        public ICommand AddNewCalendarEventCommand;

        public ICommand SaveCalendarEventCommand;

        public ICommand EditCalendarEventCommand;

        public ICommand BackCommand;

        public Action CloseAction { get; set; }

        public int EventId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Color Color { get; set; }

        public IViewManager ViewManager { get; set; }


        public string ViewName
        {
            get
            {
                return "Add new event";
            }
        }

        public ICommand AddNewCalendarEvent
        {
            get
            {
                if (this.AddNewCalendarEventCommand == null)
                {
                    this.AddNewCalendarEventCommand = new RelayCommand(this.HandleAddNewCalendarEventCommand);
                }
                return this.AddNewCalendarEventCommand;
            }
        }

        public ICommand EditCalendarEvent
        {
            get
            {
                if (this.EditCalendarEventCommand == null)
                {
                    this.EditCalendarEventCommand = new RelayCommand(this.HandleEditCalendarEventCommand);
                }
                return this.EditCalendarEventCommand;
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

        public ICommand Save
        {
            get
            {
                if (this.SaveCalendarEventCommand == null)
                {
                    this.SaveCalendarEventCommand = new RelayCommand(this.HandleSaveCommand);
                }
                return this.SaveCalendarEventCommand;
            }
        }

        private void HandleEditCalendarEventCommand(object parameter)
        {
            var editCalendarEventView = this.ViewManager.ComposeObjects<CalendarEventForm>();
            editCalendarEventView.Show();
            this.CloseAction();
        }

        private void HandleAddNewCalendarEventCommand(object parameter)
        {
            var addNewCalendarEventView = this.ViewManager.ComposeObjects<CalendarEventForm>();
            addNewCalendarEventView.Show();
            this.CloseAction();
        }

        private void HandleSaveCommand(object parameter)
        {

            using (var context = new BmsContex())
            {
                var calendarEvent = new CalendarEvent()
                {
                    Title = this.Title,
                    Description = this.Description,
                    StartTime = this.StartTime,
                    EndTime = this.EndTime,
                    Color = this.Color
                };

                context.CalendarEvents.Add(calendarEvent);
                context.SaveChanges();
            }
        }

        private void HandleBackCommand(object parameter)
        {
            var adminPanel = this.ViewManager.ComposeObjects<MainCalendarEvents>();
            adminPanel.Show();
        }


    }
}
