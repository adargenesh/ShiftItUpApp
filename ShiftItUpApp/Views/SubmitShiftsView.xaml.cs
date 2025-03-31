using ShiftItUpApp.ViewModels;

namespace ShiftItUpApp.Views;

public partial class SubmitShiftsView : ContentPage
{
	public SubmitShiftsView(SubmitShiftsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}