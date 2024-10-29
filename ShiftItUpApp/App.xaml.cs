using ShiftItUpApp.Models;

namespace ShiftItUpApp
{
    public partial class App : Application
    {

        public Worker? LoggedInUser { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
