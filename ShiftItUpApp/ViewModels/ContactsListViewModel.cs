using ShiftItUpApp.Models;
using ShiftItUptApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftItUpApp.ViewModels
{
    public class ContactsListViewModel : ViewModelBase
    {
        private ShiftItUptWebAPIProxy proxy;
        
        public ObservableCollection<Worker> Workers { get; set; }

        public ContactsListViewModel(ShiftItUptWebAPIProxy proxy)
        {
            this.proxy = proxy;
            Workers = new ObservableCollection<Worker>();
            GetAllWorkers();
        }




        //public ContactsListViewModel



        private async void GetAllWorkers()
        {
            List<Worker>? l = await proxy.GetWorkersOfStore();

            if (l != null)
            {
                foreach (Worker t in l)
                {
                    Workers.Add(t);
                }
            }
            
        }


    } 
}
