using ShiftItUptApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftItUpApp.ViewModels
{
    public class RegisterStoreViewModel : ViewModelBase 
    {
        private ShiftItUptWebAPIProxy proxy;   

        //Defiine properties for each field in the registration form including error messages and validation logic
        #region StoreName
        private bool showStoreNameError;

        public bool ShowStoreNameError
        {
            get => showStoreNameError;
            set
            {
                showStoreNameError = value;
                OnPropertyChanged("ShowStoreNameError");
            }
        }

        private string storeName;

        public string StoreName
        {
            get => storeName;
            set
            {
                storeName = value;
                ValidateStoreName();
                OnPropertyChanged("StoreName");
            }
        }

        private string storeNameError;

        public string StoreNameError
        {
            get => storeNameError;
            set
            {
                storeNameError = value;
                OnPropertyChanged("StoreNameError");
            }
        }

        private void ValidateStoreName()
        {
            this.ShowStoreNameError = string.IsNullOrEmpty(StoreName);
        }
        #endregion



        #region StoreAdress
        private bool showStoreAdressError;

        public bool ShowStoreAdressError
        {
            get => showStoreAdressError;
            set
            {
                showStoreAdressError = value;
                OnPropertyChanged("ShowStoreAdressError");
            }
        }

        private string storeAdress;

        public string StoreAdress
        {
            get => storeAdress;
            set
            {
                storeAdress = value;
                ValidateStoreAdress();
                OnPropertyChanged("StoreAdress");
            }
        }

        private string storeAdressError;

        public string StoreAdressError
        {
            get => storeAdressError;
            set
            {
                storeAdressError = value;
                OnPropertyChanged("StoreAdressError");
            }
        }

        private void ValidateStoreAdress()
        {
            this.ShowStoreAdressError = string.IsNullOrEmpty(StoreAdress);
        }
        #endregion

        #region StoreManager
        private bool showStoreManagerError;

        public bool ShowStoreManagerError
        {
            get => showStoreManagerError;
            set
            {
                showStoreManagerError = value;
                OnPropertyChanged("ShowStoreManagerError");
            }
        }

        private string storeManager;

        public string StoreManager
        {
            get => storeManager;
            set
            {
                storeManager = value;
                ValidateStoreManager();
                OnPropertyChanged("StoreManager");
            }
        }

        private string storeManagerError;

        public string StoreManagerError
        {
            get => storeManagerError;
            set
            {
                storeManagerError = value;
                OnPropertyChanged("StoreManagerError");
            }
        }

        private void ValidateStoreManager()
        {
            this.ShowStoreManagerError = string.IsNullOrEmpty(StoreManager);
        }
        #endregion


        #region ManagerEmail
        private bool showManagerEmailError;

        public bool ShowManagerEmailError
        {
            get => showManagerEmailError;
            set
            {
                showManagerEmailError = value;
                OnPropertyChanged("ShowManagerEmailError");
            }
        }

        private string managerEmail;

        public string ManagerEmail
        {
            get => managerEmail;
            set
            {
                managerEmail = value;
                ValidateManagerEmail();
                OnPropertyChanged("ManagerEmail");
            }
        }

        private string managerEmailError;

        public string ManagerEmailError
        {
            get => managerEmailError;
            set
            {
                managerEmailError = value;
                OnPropertyChanged("ManagerEmailError");
            }
        }

        private void ValidateManagerEmail()
        {
            this.ShowManagerEmailError = string.IsNullOrEmpty(ManagerEmail);
        }
        #endregion


    }
}
