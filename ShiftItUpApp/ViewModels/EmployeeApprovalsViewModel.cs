using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftItUpApp.Models;
using ShiftItUptApp.Services;

namespace ShiftItUpApp.ViewModels
{
    public class EmployeeApprovalsViewModel : ViewModelBase

    {


        private ObservableCollection<Status> statusList;
        private ObservableCollection<Worker> workers;
        private Status selectedStatus;
        private Worker selectedWorker;



        public EmployeeApprovalsViewModel()
        {
            // אתחול רשימת הסטטוסים עם ערכים קבועים
            StatusList = new ObservableCollection<Status>
            {
                new Status { Id = 0, Name = "Approved" },
                new Status { Id = 1, Name = "Declined" },
                new Status { Id = 2, Name = "Pending" }
            };

        }

        public ObservableCollection<Status> StatusList { get; }

    }

}
