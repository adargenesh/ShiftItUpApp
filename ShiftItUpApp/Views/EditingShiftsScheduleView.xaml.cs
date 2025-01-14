using ShiftItUpApp.ViewModels;
namespace ShiftItUpApp.Views;

public partial class EditingShiftsScheduleView : ContentPage
{
	public EditingShiftsScheduleView( EditingShiftsScheduleViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}