using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftItUpApp.Models
{
    public class WorkerShiftRequest
    {
        public int RequestId { get; set; }

        public int WeekNum { get; set; }

        public int Year { get; set; }

        public int WorkerId { get; set; }
        public Worker? Worker { get; set; }

        public string Remarks { get; set; } = null!;

        public WorkerShiftRequest() { }
    }
}
