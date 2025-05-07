using ShiftItUpApp.ViewModels;

namespace ShiftItUpApp.Views;

public partial class DefiningShiftsView : ContentPage
{
	public DefiningShiftsView(DefiningShiftsViewModel vm)
	{
		this.BindingContext = vm;
        InitializeComponent();
	}
}