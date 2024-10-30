using ShiftItUpApp.Models;
using ShiftItUpApp.ViewModels;
using ShiftItUpApp.Views;

namespace ShiftItUpApp
{
    public partial class App : Application
    {

        public Worker? LoggedInUser { get; set; }
        public App(ServiceProvider serviceProvider)
        {
            InitializeComponent();
            LoginView? v=serviceProvider.GetService<LoginView>();
            MainPage = v;
        }
    }
}
