using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftItUpApp.Models
{
    public class DefiningShift
    {
        public int DefiningShiftId { get; set; }

        public int IdStore { get; set; }

        public int DayOfWeek { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public int NumEmployees { get; set; }

        public DefiningShift() { }
    }
}
