using ShiftItUptApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
