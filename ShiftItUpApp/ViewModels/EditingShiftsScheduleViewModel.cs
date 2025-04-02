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
    public class EditingShiftsScheduleViewModel:ViewModelBase
    {
        private ShiftItUptWebAPIProxy proxy;
        private IServiceProvider serviceProvider;
        public EditingShiftsScheduleViewModel(ShiftItUptWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.proxy = proxy;
            this.serviceProvider = serviceProvider; 
            Shifts = new ObservableCollection<WorkerShiftRequest>();
            ReadShiftFromServer();
          

        }
        private ObservableCollection<WorkerShiftRequest> shifts;
        public ObservableCollection<WorkerShiftRequest> Shifts
        {
            get => shifts;
            set
            {
                shifts = value;
                OnPropertyChanged();
            }
        }
        private async void ReadShiftFromServer()
        {

            List<WorkerShiftRequest> list = await proxy.GetShiftRequestOfStore();
            Shifts = new ObservableCollection<WorkerShiftRequest>(list);

        }

      



    }
}



    

