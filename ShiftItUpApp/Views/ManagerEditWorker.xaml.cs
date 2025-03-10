using ShiftItUpApp.ViewModels;

namespace ShiftItUpApp.Views;

public partial class ManagerEditWorker : ContentPage
{
	public ManagerEditWorker(ManagerEditWorkerViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}