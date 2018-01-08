namespace BmsWpf.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Windows;
    using System.Windows.Input;

    using BmsWpf.Behaviour;
    using BmsWpf.Views.ChildWindows;

    using BMS.DataBaseModels.Enums;
    using BmsWpf.Services.DTOs;
    using BmsWpf.Services.Contracts;
    using System.Linq;

    public class CalendarEventFormViewModel:ViewModelBase, IPageViewModel
    {
        private UserListDto selectedUsername;
        private ObservableCollection<UserListDto> usernamesList;
        private int id;
        private string title;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private Color Color;


        public ICommand WindowLoadedCommand;
        public ICommand SaveCommand;
        public ICommand BackCommand;
        public DataRowView selectedCalendarEvent;

        public CalendarEventFormViewModel()
        {
            this.startDate = DateTime.Now;
            this.endDate = DateTime.Now;
        }

        public ICalendarEventsService CalendarEventService { get; set; }
        public IUserService UserService { get; set; }
        public IViewManager ViewManager { get; set; }

        public Action CloseAction { get; set; }

        public string ViewName
        {
            get
            {
                return "Calendar Event Form";
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                this.OnPropertyChanged(nameof(Id));
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.OnPropertyChanged(nameof(this.Title));
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                this.OnPropertyChanged(nameof(Description));
            }
        }


        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
                this.OnPropertyChanged(nameof(this.StartDate));
            }
        }
        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
                this.OnPropertyChanged(nameof(this.EndDate));
            }
        }

        public DataRowView SelectedCalendarEvent
        {
            get
            {
                return this.selectedCalendarEvent;
            }
            set
            {
                this.selectedCalendarEvent = value;
                this.OnPropertyChanged(nameof(this.SelectedCalendarEvent));
            }
        }

        public UserListDto SelectedUsername
        {
            get
            {
                return this.selectedUsername;
            }
            set
            {
                this.selectedUsername = value;
                this.OnPropertyChanged(nameof(this.SelectedUsername));
            }
        }

        public ObservableCollection<UserListDto> UsernameList
        {
            get
            {
                return this.usernamesList;
            }
            set
            {
                this.usernamesList = value;
                OnPropertyChanged(nameof(this.UsernameList));
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


        public ICommand Save
        {
            get
            {
                if (this.SaveCommand == null)
                {
                    this.SaveCommand = new RelayCommand(this.HandleSaveCommand);
                }
                return this.SaveCommand;
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
            this.UsernameList = new ObservableCollection<UserListDto>(this.UserService.GetUsernames());
            if (this.SelectedCalendarEvent != null)
            {
                //  this.Id = (int)this.selectedCalendarEvent.Row.ItemArray[0];

                this.Title = (string)this.selectedCalendarEvent.Row.ItemArray[0];
                this.Description = (string)this.selectedCalendarEvent.Row.ItemArray[1];
                this.StartDate = (DateTime)this.selectedCalendarEvent.Row.ItemArray[2];
                this.EndDate = (DateTime)this.selectedCalendarEvent.Row.ItemArray[3];
                this.Color = (Color)this.selectedCalendarEvent.Row.ItemArray[4];
                var creatorDto = (UserListDto)SelectedCalendarEvent.Row.ItemArray[5];
                this.SelectedUsername = UsernameList.SingleOrDefault(x => x.Id == creatorDto.Id);
            }
        }

        private void HandleSaveCommand(object parameter)
        {
            var result = string.Empty;
            var newCalendarEvent = new CalendarEventsPostDto()
                                       {
                                           Id = this.Id,
                                           CreatorId = this.SelectedUsername.Id,
                                           Title = this.Title,
                                           Description = this.Description,
                                           StartDate = this.StartDate,
                                           EndDate = this.EndDate,
                                           Color = this.Color,
                                       };
            try
            {
                if (this.SelectedCalendarEvent == null)
                {
                    result = this.CalendarEventService.CreateCalendarEvent(newCalendarEvent);
                }
                else
                {
                    result = this.CalendarEventService.EditCalendarEvent(newCalendarEvent);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            MessageBox.Show(result);
            this.RedirectToMainCalendarEvents();
        }

        private void HandleBackCommand(object parameter)
        {
            this.RedirectToMainCalendarEvents();
        }

        private void RedirectToMainCalendarEvents()
        {
            var mainCalendarEventWindow = this.ViewManager.ComposeObjects<MainCalendarEvents>();
            mainCalendarEventWindow.Show();
            this.CloseAction();
        }
    }
}
