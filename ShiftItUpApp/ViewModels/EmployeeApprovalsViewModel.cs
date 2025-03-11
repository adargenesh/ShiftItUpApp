using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShiftItUpApp.Models;
using ShiftItUptApp.Services;

namespace ShiftItUpApp.ViewModels
{
    public class EmployeeApprovalsViewModel : ViewModelBase

    {


        private ObservableCollection<Status> statusList;
        public ObservableCollection<Worker> Workers { get; set; }
        private ObservableCollection<Worker> allWorkers;


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
                    FilterWorkers();
                    OnPropertyChanged(nameof(SelectedStatus));
                }

            }
        }
        private Worker selectedWorker;
        private ShiftItUptWebAPIProxy proxy;



        public EmployeeApprovalsViewModel(ShiftItUptWebAPIProxy proxy)
        {
            this.proxy = proxy;
            // אתחול רשימת הסטטוסים עם ערכים קבועים
            StatusList = new ObservableCollection<Status>
            {
                new Status { Id = 0, Name = "Approved" },
                new Status { Id = 1, Name = "Declined" },
                new Status { Id = 2, Name = "Pending" }
            };

            
            allWorkers = new ObservableCollection<Worker>();
            Workers = new ObservableCollection<Worker>();
            selectedStatus = StatusList[2];
            EditCommand = new Command<Worker>(OnEdit);
            GetAllWorkers();

        }

        public ObservableCollection<Status> StatusList { get; }

        private async void GetAllWorkers()
        {
            List<Worker>? l = await proxy.GetWorkersOfStore();

            if (l != null)
            {
                foreach (Worker t in l)
                {
                    allWorkers.Add(t);
                    if (t.StatusWorker == 2)
                        Workers.Add(t);
                }
            }

        }

        private void FilterWorkers()
        {
            Workers.Clear();
            foreach (Worker t in allWorkers)
            {
                if (t.StatusWorker == SelectedStatus.Id)
                    Workers.Add(t);
            }


        }


        public ICommand EditCommand { get; set; }
        public async void OnEdit(Worker w)
        {
            var navParam = new Dictionary<string, object>
                {
                    { "selectedWorker", w}, {"Statuses", StatusList}
                };
            //Navigate to the task details page
            await Shell.Current.GoToAsync("managerEditWorker", navParam);

        }

        public override void Refresh()
        {
            base.Refresh();
            FilterWorkers();

        }
    }
}
