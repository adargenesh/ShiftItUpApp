using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftItUpApp.Models
{
  public class Worker
    {
        public int WorkerId { get; set; }

        public string UserName { get; set; } = null;

        public string UserLastName { get; set; } = null;

        public string UserEmail { get; set; } = null;

        public string UserStoreName { get; set; } = null;

        public string UserSalary { get; set; }  // Changed to decimal for better salary representation

        public int StatusWorker { get; set; }
        public int IdStore { get; set; }
        public string UserPassword { get; set; } = null;
        public bool IsManager { get; set; }
        public string ProfileImagePath { get; set; } = "";

    }
}
