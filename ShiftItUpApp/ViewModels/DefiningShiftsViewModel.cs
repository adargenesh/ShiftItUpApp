using ShiftItUpApp.Models;
using ShiftItUptApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShiftItUpApp.ViewModels
{
    public class DefiningShiftsViewModel:ViewModelBase
    {
        private ObservableCollection<DefiningShift> shifts;
        public ObservableCollection<DefiningShift> Shifts 
        { 
            get
            {
                return shifts;
            } 
            set
            {
                shifts = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddShiftCommand { get; }
        public ICommand RemoveShiftCommand { get; }
        public ICommand SaveShiftsCommand { get; }
        private ShiftItUptWebAPIProxy proxy;
        public DefiningShiftsViewModel(ShiftItUptWebAPIProxy proxy)
        {
            this.proxy = proxy;
            Shifts = new ObservableCollection<DefiningShift>();
            ReadShifts();
            AddShiftCommand = new Command(AddShift);
            RemoveShiftCommand = new Command<DefiningShift>(RemoveShift);
            SaveShiftsCommand = new Command(SaveShifts);
        }

        private async void ReadShifts()
        {
            List<DefiningShift> shifts = await proxy.GetDefiningShifts();
            if (shifts != null)
                Shifts = new ObservableCollection<DefiningShift>(shifts);
        }
        private void AddShift()
        {
            Store store = (Store)(((App)Application.Current).LoggedInUser);
            Shifts.Add(new DefiningShift
            {
                IdStore = store.IdStore, // Assuming you have a way to get the current store ID
                StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(16, 0),
                NumEmployees = 1,
                DayOfWeek = 0 // Default to Sunday
            });
        }

        private void RemoveShift(DefiningShift shift)
        {
            if (Shifts.Contains(shift))
                Shifts.Remove(shift);
        }

        private async void SaveShifts()
        {
            // Replace with your API call to save shifts to the server
            bool success = await proxy.UpdateDefiningShifts(Shifts.ToList());
            if (success)
            {
                // Optionally, show a success message or update the UI
                await Application.Current.MainPage.DisplayAlert("Success", "Shifts saved successfully.", "OK");
                await Shell.Current.Navigation.PopAsync();
            }
            else
            {
                // Optionally, show an error message
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to save shifts.", "OK");
            }
        }
    }
}
