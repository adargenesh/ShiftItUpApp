using ShiftItUpApp.ViewModels;

namespace ShiftItUpApp.Views;

public partial class EmployeeApprovalsView : ContentPage
{
	public EmployeeApprovalsView(EmployeeApprovalsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}