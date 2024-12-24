using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftItUpApp.Models
{
    public class Store
    {
        public int IdStore { get; set; }

        public string StoreName { get; set; } = string.Empty;

        public string StoreAddress { get; set; } = null;

        public string StoreManager { get; set; } = null;

        public string ManagerEmail { get; set; } = null;
        public string ManagerPassword { get; set; } = null;
        public string ProfileImagePath { get; set; } = "";
    }
}
