using ShiftItUpApp.Models;
using ShiftItUptApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftItUpApp.ViewModels
{
    public class SubmitShiftsViewModel:ViewModelBase
    {

        private ObservableCollection<DateTime> sundays;
        public ObservableCollection<DateTime> Sundays
        {
            get
            {
                return sundays;
            }
            set
            {
                if (sundays != value)
                {
                    sundays = value;
                }
                OnPropertyChanged();
            }
        }

        private DateTime selectedSunday;
        public DateTime SelectedSunday
        {
            get { return selectedSunday; }
            set
            {
                if (selectedSunday != value)
                {
                    selectedSunday = value;
                }
                OnPropertyChanged();
            }
        }

        private string remarks;
        public string Remarks
        {
            get { return remarks; }
            set
            {
                if (remarks != value)
                {
                    remarks = value;
                }
                OnPropertyChanged();
            }
        }

        private bool showRemarksError;

        public bool ShowRemarksError
        {
            get => showRemarksError;
            set
            {
                showRemarksError = value;
                OnPropertyChanged("ShowRemarksError");
            }
        }

        private string remarksError;

        public string RemarksError
        {
            get => remarksError;
            set
            {
                remarksError = value;
                OnPropertyChanged("RemarksError");
            }
        }

        private void ValidateRemarks()
        {
            //Remarks must not be empty
            if (string.IsNullOrEmpty(remarks))
            {
                this.ShowRemarksError = true;
            }
            else
                this.ShowRemarksError = false;
        }

        public Command SaveCommand { get; set; }
        public Command CancelCommand { get; set; }

        private async void OnSave()
        {
            ValidateRemarks();
            if (!ShowRemarksError)
            {
                int workerID = 0;
                Object? user = ((App)Application.Current).LoggedInUser;
                if (user is Worker)
                {

                    Worker w = (Worker)user;
                    workerID = w.WorkerId;
                }

                WorkerShiftRequest request = new WorkerShiftRequest()
                {
                    Remarks = remarks,
                    WeekNum = GetWeekNumber(SelectedSunday),
                    Year = SelectedSunday.Year,
                    WorkerId = workerID
                };

                WorkerShiftRequest? result = await proxy.AddShiftRequest(request);

                if (result == null)
                {
                    await Shell.Current.DisplayAlert("Error", "Data was not saved!", "Ok");
                }
                else
                    OnCancel();
            }
        }

        private int GetWeekNumber(DateTime dateTime)
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            Calendar calendar = culture.Calendar;
            CalendarWeekRule weekRule = culture.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
            int weekNumber = calendar.GetWeekOfYear(dateTime, weekRule, firstDayOfWeek);
            return weekNumber;
        }

        private async void OnCancel()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private ShiftItUptWebAPIProxy proxy;
        public SubmitShiftsViewModel(ShiftItUptWebAPIProxy proxy)
        {
            this.proxy = proxy;
            //Build weeks list
            Sundays = new ObservableCollection<DateTime>();
            DateTime today = DateTime.Today;
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSunday = today.AddDays(daysUntilSunday);
            for(int i = 0; i<4; i++)
            {
                Sundays.Add(nextSunday);
                nextSunday.AddDays(7);
            }

            SelectedSunday = Sundays[0];

            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

    }
}
