using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftItUpApp.Models;
using ShiftItUptApp.Services;


namespace ShiftItUpApp.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private ShiftItUptWebAPIProxy proxy;
        private IServiceProvider serviceProvider;
        public ProfileViewModel(ShiftItUptWebAPIProxy proxy, IServiceProvider serviceProvider)
        {
            this.proxy = proxy;
            ShowPasswordCommand = new Command(OnShowPassword);
            UploadPhotoCommand = new Command(OnUploadPhoto);
            PhotoURL = proxy.GetDefaultProfilePhotoUrl();
            LocalPhotoPath = "";
            IsPassword = true;
            NameError = "Name is required";
            LastNameError = "Last name is required";
            EmailError = "Email is required";
            PasswordError = "Password must be at least 4 characters long and contain letters and numbers";
            SaveCommand = new Command(OnSave);
            Object u = ((App)Application.Current).LoggedInUser;
            Worker w = new Worker();
            if (u is Worker)
            {
                w = (Worker)u;
                Name = w.UserName;
                LastName = w.UserLastName;
                Email = w.UserEmail;
                Password = w.UserPassword;
                PhotoURL = proxy.GetImagesBaseAddress() + w.ProfileImagePath;
            }
            else
            {
                Store store = (Store)u;
                Name = store.StoreName;
                LastName = store.StoreManager;
                Email = store.ManagerEmail;
                Password = store.ManagerPassword;
                StoreAdress= store.StoreAddress;
                PhotoURL = proxy.GetImagesBaseAddress() + store.ProfileImagePath;

            }


        }
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




        #region Photo

        private string photoURL;

        public string PhotoURL
        {
            get => photoURL;
            set
            {
                photoURL = value;
                OnPropertyChanged("PhotoURL");
            }
        }

        private string localPhotoPath;

        public string LocalPhotoPath
        {
            get => localPhotoPath;
            set
            {
                localPhotoPath = value;
                OnPropertyChanged("LocalPhotoPath");
            }
        }

        public Command UploadPhotoCommand { get; }
        //This method open the file picker to select a photo
        private async void OnUploadPhoto()
        {
            try
            {
                var result = await MediaPicker.Default.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = "Please select a photo",
                });

                if (result != null)
                {
                    // The user picked a file
                    this.LocalPhotoPath = result.FullPath;
                    this.PhotoURL = result.FullPath;
                }
            }
            catch (Exception ex)
            {
            }

        }
        public Command GalleryPhotoCommand { get; }
        //This method open the file picker to select a photo
        private async void OnGalleryPhoto()
        {
            try
            {
                var result = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please select a photo",
                });

                if (result != null)
                {
                    // The user picked a file
                    this.LocalPhotoPath = result.FullPath;
                    this.PhotoURL = result.FullPath;
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void UpdatePhotoURL(string virtualPath)
        {
            Random r = new Random();
            PhotoURL = proxy.GetImagesBaseAddress() + virtualPath + "?v=" + r.Next();
            LocalPhotoPath = "";
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

        public Command SaveCommand { get; }
        public async void OnSave()
        {
            ValidateName();
            ValidateLastName();
            ValidateEmail();
            ValidatePassword();

            if (!ShowNameError && !ShowLastNameError && !ShowEmailError && !ShowPasswordError)
            {

                //Update AppUser object with the data from the Edit form
                Object theUser = ((App)App.Current).LoggedInUser;
                bool success;
                Worker worker = new Worker();
                if (theUser is Worker)
                {
                    worker = (Worker)theUser;
                    worker.UserName = Name;
                    worker.UserLastName = LastName;
                    worker.UserEmail = Email;
                    worker.UserPassword = Password;
                    InServerCall = true;
                    success = await proxy.UpdateUser(worker);


                    //If the save was successful, navigate to the login page
                    if (success)
                    {
                        //UPload profile imae if needed
                        if (!string.IsNullOrEmpty(LocalPhotoPath))
                        {
                            Worker? worker1Update = await proxy.UploadProfileImage(LocalPhotoPath);
                            if (worker1Update == null)
                            {
                                await Shell.Current.DisplayAlert("Save Profile", "User Data Was Saved BUT Profile image upload failed", "ok");
                            }
                            else
                            {
                                worker.ProfileImagePath = worker1Update.ProfileImagePath;
                                UpdatePhotoURL(worker.ProfileImagePath);
                            }

                        }
                        InServerCall = false;
                        await Shell.Current.DisplayAlert("Save Profile", "Profile saved successfully", "ok");
                    }


                    Store store = new Store();
                    if (theUser is Store)
                    {
                        store = (Store)theUser;
                        store.StoreManager = Name;
                        store.StoreName = LastName;
                        store.ManagerEmail = Email;
                        store.ManagerPassword = Password;
                        store.StoreAddress = storeAdress;

                        InServerCall = true;
                        success = await proxy.UpdateProfileStore(store);


                        //If the save was successful, navigate to the login page
                        if (success)
                        {
                            //UPload profile imae if needed
                            if (!string.IsNullOrEmpty(LocalPhotoPath))
                            {
                                Worker? worker1Update = await proxy.UploadProfileImage(LocalPhotoPath);
                                if (worker1Update == null)
                                {
                                    await Shell.Current.DisplayAlert("Save Profile", "User Data Was Saved BUT Profile image upload failed", "ok");
                                }
                                else
                                {
                                    worker.ProfileImagePath = worker1Update.ProfileImagePath;
                                    UpdatePhotoURL(worker.ProfileImagePath);
                                }

                            }
                            InServerCall = false;
                            await Shell.Current.DisplayAlert("Save Profile", "Profile saved successfully", "ok");

                        }







                        else
                        {
                            InServerCall = false;
                            //If the registration failed, display an error message
                            string errorMsg = "Save Profile failed. Please try again.";
                            await Shell.Current.DisplayAlert("Save Profile", errorMsg, "ok");
                        }
                    }



                    //Call the Register method on the proxy to register the new user

                }

            }
        }
    }
}
    
