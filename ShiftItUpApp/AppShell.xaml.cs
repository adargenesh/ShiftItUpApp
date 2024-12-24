using ShiftItUpApp.ViewModels;
using ShiftItUpApp.Views;

namespace ShiftItUpApp
{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel vm)
        {
            BindingContext = vm;
            InitializeComponent();
        }
    }
}
