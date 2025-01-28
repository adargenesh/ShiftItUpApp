using ShiftItUpApp.Models;
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
        private string UserName;
        public string userName { get { return userName; } set { userName = value; } }

        private string UserLastName;
        public string userLastName { get { return userLastName; } set { userLastName = value; } }

        private string UserEmail;
        public string userEmail { get { return userEmail; } set { userEmail = value; } }

        private string ProfileImagePath;
        public string profileImagePath { get { return profileImagePath; } set { profileImagePath = value; } }
        public ObservableCollection<Worker> Workers { get; set; }




        //public ContactsListViewModel



        //private async void GetAllTeachers()
        //{
        //    List<WorkerDto> l = await proxy.GetAllWorkers();


        //    foreach (WorkerDto t in l)
        //    {
        //        WorkersList.Add(t);
        //        FilteredWorkersList.Add(t);


        //    }
        //}


    } 
}
