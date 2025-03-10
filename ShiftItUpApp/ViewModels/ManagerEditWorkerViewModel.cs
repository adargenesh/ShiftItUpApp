using ShiftItUpApp.Models;
using ShiftItUptApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftItUpApp.ViewModels
{
    [QueryProperty("TheWorker", "selectedWorker")]
    [QueryProperty("StatusList", "Statuses")]
    public class ManagerEditWorkerViewModel : ViewModelBase
    {
        private Worker theWorker;
        public Worker TheWorker
        {
            get { return theWorker; }
            set
            {
                if (theWorker != value)
                {
                    theWorker = value;
                    OnPropertyChanged();
                    //InitData();
                }
                
            }
        }

        private ShiftItUptWebAPIProxy proxy;
        public ManagerEditWorkerViewModel(ShiftItUptWebAPIProxy proxy)
        {
            this.proxy = proxy;
            theWorker = new Worker();
            statusList = new ObservableCollection<Status>();
            SelectedStatus = null;
            SaveCommand = new Command(OnSave);
        }

        private Status selectedStatus;
        public Status SelectedStatus
        {
            get
            {
                return selectedStatus;
            }
            set
            {
                if (value != selectedStatus)
                {
                    selectedStatus = value;
                    OnPropertyChanged(nameof(SelectedStatus));
                    
                }

            }
        }

        private ObservableCollection<Status> statusList;
        public ObservableCollection<Status> StatusList
        {
            get { return statusList; }
            set
            {
                if (statusList != value)
                {
                    statusList = value;
                    OnPropertyChanged();
                    InitData();
                }
            }
        }

        private string salary;
        public string Salary
        {
            get { return salary; }
            set
            {
                if (salary != value)
                {
                    salary = value;
                    
                    OnPropertyChanged();
                }
                
            }
        }

        private void InitData()
        {
            Salary = TheWorker.UserSalary;
            foreach (var status in statusList) 
            {
                if (status.Id == TheWorker.StatusWorker)
                {
                    SelectedStatus = status;
                }
            }
        }

        public Command SaveCommand { get; set; }
        private async void OnSave()
        {
            TheWorker.UserSalary = Salary;
            TheWorker.StatusWorker = SelectedStatus.Id;
            bool success = await proxy.UpdateUser(TheWorker);

            if (success)
                await Shell.Current.Navigation.PopAsync();
            else
            {
                await Shell.Current.DisplayAlert("Error", "Data was not saved! Try again later!", "Ok");
            }
        }
    }
}
