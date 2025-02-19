using ShiftItUptApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        
        public string UserSalary { get; set; }  // Changed to decimal for better salary representation

        public int StatusWorker { get; set; }
        public string StatusName
        {
            get
            {
                List<Status> StatusList = new List<Status>
                {
                    new Status { Id = 0, Name = "Approved" },
                    new Status { Id = 1, Name = "Declined" },
                    new Status { Id = 2, Name = "Pending" }
                };
                Status? status = StatusList.Where(s => s.Id == StatusWorker).FirstOrDefault();
                if (status == null)
                    return "Unknown";
                else
                    return status.Name;
            }
        }
        public int IdStore { get; set; }
        public string UserPassword { get; set; } = null;
        public bool IsManager { get; set; }
        public string ProfileImagePath { get; set; } = "";
        public string ImageURL
        {
            get
            {
                return ShiftItUptWebAPIProxy.ImageBaseAddress + ProfileImagePath;
            }
        }

    }
}
