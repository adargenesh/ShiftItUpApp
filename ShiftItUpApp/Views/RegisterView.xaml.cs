using ShiftItUpApp.ViewModels;

namespace ShiftItUpApp.Views;

public partial class RegisterView : ContentPage
{
	public RegisterView(RegisterViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}