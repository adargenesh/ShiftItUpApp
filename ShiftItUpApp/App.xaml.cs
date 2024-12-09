using ShiftItUpApp.Models;
using ShiftItUpApp.ViewModels;
using ShiftItUpApp.Views;

namespace ShiftItUpApp
{
    public partial class App : Application
    {

        public Object? LoggedInUser { get; set; }
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = new NavigationPage(serviceProvider.GetService<LoginView>());
        }
    }
}
