using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftItUpApp.Models;

namespace ShiftItUpApp.ViewModels
{
    internal class EmployeeApprovalsViewModel : ViewModelBase

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
                new Status { Id = 0, Name = "מאושר" },
                new Status { Id = 1, Name = "נדחה" },
                new Status { Id = 2, Name = "ממתין" }
            };

        }

        public ObservableCollection<Status> StatusList { get; }
       
    }

}
