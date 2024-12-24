using ShiftItUpApp.Models;
using ShiftItUptApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Java.Util.Jar.Attributes;

namespace ShiftItUpApp.ViewModels
{
    public class RegisterStoreViewModel : ViewModelBase 
    {
        private ShiftItUptWebAPIProxy proxy;   

        public RegisterStoreViewModel(ShiftItUptWebAPIProxy proxy)
        {
            this.proxy = proxy;
            RegisterCommand = new Command(OnRegister);
            CancelCommand = new Command(OnCancel);
            StoreNameError = "Store Name is required";
            StoreAdressError = "Adress is required";
            ManagerEmailError = "Manager Email is required";
            StoreManagerError = " Manager Name is required";
            PasswordError = "Password must be at least 4 characters long and contain letters and numbers";

        }
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
        #region Password
        private bool showPasswordError;

        public bool ShowPasswordError
        {
            get => showPasswordError;
            set
            {
                showPasswordError = value;
                OnPropertyChanged("ShowPasswordError");
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                ValidatePassword();
                OnPropertyChanged("Password");
            }
        }

        private string passwordError;

        public string PasswordError
        {
            get => passwordError;
            set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }

        private void ValidatePassword()
        {
            //Password must include characters and numbers and be longer than 4 characters
            if (string.IsNullOrEmpty(password) ||
                password.Length < 4 ||
                !password.Any(char.IsDigit) ||
                !password.Any(char.IsLetter))
            {
                this.ShowPasswordError = true;
            }
            else
                this.ShowPasswordError = false;
        }

        //This property will indicate if the password entry is a password
        private bool isPassword = true;
        public bool IsPassword
        {
            get => isPassword;
            set
            {
                isPassword = value;
                OnPropertyChanged("IsPassword");
            }
        }
        //This command will trigger on pressing the password eye icon
        public Command ShowPasswordCommand { get; }
        //This method will be called when the password eye icon is pressed
        public void OnShowPassword()
        {
            //Toggle the password visibility
            IsPassword = !IsPassword;
        }
        #endregion

        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }

        public async void OnRegister()
        {
          
           
            ValidateManagerEmail();
           ValidateStoreAdress();
            ValidateStoreName();
            ValidateStoreManager();
            ValidatePassword();
            if (!ShowManagerEmailError & !ShowStoreNameError & !ShowStoreAdressError &! ShowStoreManagerError&!ShowPasswordError)
            {
                //Create a new AppUser object with the data from the registration form
                var newUser = new Store
                {
                    StoreName = StoreName,
                    StoreAddress= StoreAdress,
                    StoreManager = StoreManager,
                    ManagerEmail = ManagerEmail,
                    ManagerPassword=Password
                };

                //Call the Register method on the proxy to register the new user
                InServerCall = true;
                newUser = await proxy.RegisterStore(newUser);
                InServerCall = false;

                //If the registration was successful, navigate to the login page
                if (newUser != null)
                {
                    //UPload profile imae if needed
                    //if (!string.IsNullOrEmpty(LocalPhotoPath))
                    //{
                    //    await proxy.LoginAsync(new LoginInfo { Email = newUser.UserEmail, Password = newUser.UserPassword });
                    //    AppUser? updatedUser = await proxy.UploadProfileImage(LocalPhotoPath);
                    //    if (updatedUser == null)
                    //    {
                    //        InServerCall = false;
                    //        await Application.Current.MainPage.DisplayAlert("Registration", "User Data Was Saved BUT Profile image upload failed", "ok");
                    //    }
                    //}
                    InServerCall = false;

                    ((App)(Application.Current)).MainPage.Navigation.PopAsync();
                }
                else
                {

                    //If the registration failed, display an error message
                    string errorMsg = "Registration failed. Please try again.";
                    await Application.Current.MainPage.DisplayAlert("Registration", errorMsg, "ok");
                }
            }

        }

        public void OnCancel()
        {
            //Navigate back to the login page
            ((App)(Application.Current)).MainPage.Navigation.PopAsync();
        }
    }
}
