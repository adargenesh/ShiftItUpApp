using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftItUptApp.Services;
using ShiftItUpApp.Models;
using System.Collections.ObjectModel;


namespace ShiftItUpApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private ShiftItUptWebAPIProxy proxy;
        public RegisterViewModel(ShiftItUptWebAPIProxy proxy)
        {
            this.proxy = proxy;
            RegisterCommand = new Command(OnRegister);
            CancelCommand = new Command(OnCancel);
            ShowPasswordCommand = new Command(OnShowPassword);
            //UploadPhotoCommand = new Command(OnUploadPhoto);
            //PhotoURL = proxy.GetDefaultProfilePhotoUrl();
            //LocalPhotoPath = "";
            Fill();
            IsPassword = true;
            NameError = "Name is required";
            LastNameError = "Last name is required";
            EmailError = "Email is required";
            PasswordError = "Password must be at least 4 characters long and contain letters and numbers";
        }


        //Defiine properties for each field in the registration form including error messages and validation logic
        #region Name
        private bool showNameError;

        public bool ShowNameError
        {
            get => showNameError;
            set
            {
                showNameError = value;
                OnPropertyChanged("ShowNameError");
            }
        }

        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                ValidateName();
                OnPropertyChanged("Name");
            }
        }

        private string nameError;

        public string NameError
        {
            get => nameError;
            set
            {
                nameError = value;
                OnPropertyChanged("NameError");
            }
        }

        private void ValidateName()
        {
            this.ShowNameError = string.IsNullOrEmpty(Name);
        }
        #endregion

        #region LastName
        private bool showLastNameError;

        public bool ShowLastNameError
        {
            get => showLastNameError;
            set
            {
                showLastNameError = value;
                OnPropertyChanged("ShowLastNameError");
            }
        }

        private string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                ValidateLastName();
                OnPropertyChanged("LastName");
            }
        }

        private string lastNameError;

        public string LastNameError
        {
            get => lastNameError;
            set
            {
                lastNameError = value;
                OnPropertyChanged("LastNameError");
            }
        }

        private void ValidateLastName()
        {
            this.ShowLastNameError = string.IsNullOrEmpty(LastName);
        }
        #endregion

        #region Email
        private bool showEmailError;

        public bool ShowEmailError
        {
            get => showEmailError;
            set
            {
                showEmailError = value;
                OnPropertyChanged("ShowEmailError");
            }
        }

        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                ValidateEmail();
                OnPropertyChanged("Email");
            }
        }

        private string emailError;

        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value;
                OnPropertyChanged("EmailError");
            }
        }

        private void ValidateEmail()
        {
            this.ShowEmailError = string.IsNullOrEmpty(Email);
            if (!ShowEmailError)
            {
                //check if email is in the correct format using regular expression
                if (!System.Text.RegularExpressions.Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    EmailError = "Email is not valid";
                    ShowEmailError = true;
                }
                else
                {
                    EmailError = "";
                    ShowEmailError = false;
                }
            }
            else
            {
                EmailError = "Email is required";
            }
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
            this.ShowNameError = string.IsNullOrEmpty(Name);
        }
        #endregion


        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }

        public async void OnRegister()
        {
            ValidateName();
            ValidateLastName();
            ValidateEmail();
            ValidatePassword();
            ValidateStoreName();

            if (!ShowNameError && !ShowLastNameError && !ShowEmailError && !ShowPasswordError&!ShowStoreNameError)
            {
                //Create a new AppUser object with the data from the registration form
                var newUser = new Worker
                {
                    UserName = Name,
                    UserLastName = LastName,
                    UserEmail = Email,
                    UserPassword = Password,
                    IsManager = false,
                    IdStore= StoreSelected.IdStore,
                    UserSalary = "0"
                };

                //Call the Register method on the proxy to register the new user
                InServerCall = true;
                newUser = await proxy.Register(newUser);
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


        #region pICKER
        private ObservableCollection<Store> stores;
        public ObservableCollection<Store> Stores
        {
            get => stores;
            set
            {
                if (value != stores)
                {
                    stores = value;
                    OnPropertyChanged();
                }
            }
        }

        private Store storeSelected;
        public Store StoreSelected
        {
            get => storeSelected;
            set
            {
                if (value != storeSelected)
                {
                    storeSelected = value;
                    
                    OnPropertyChanged();
                }
            }
        }

        private async void Fill()
        {
            List<Store> stores = await this.proxy.GetAllStores();
            //add error msg if null
            Stores = new ObservableCollection<Store>(stores);
        }
        #endregion  

        public void OnCancel()
        {
            //Navigate back to the login page
            ((App)(Application.Current)).MainPage.Navigation.PopAsync();
        }

    }
}

