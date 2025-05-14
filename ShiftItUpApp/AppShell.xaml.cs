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
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("managerEditWorker", typeof(ManagerEditWorker));
            Routing.RegisterRoute("DefiningShiftsView", typeof(DefiningShiftsView));
            
        }

        public event Action<Type> DataChanged;
        public void Refresh(Type type)
        {
            if (DataChanged != null)
            {
                DataChanged(type);
            }
        }
    }
}
