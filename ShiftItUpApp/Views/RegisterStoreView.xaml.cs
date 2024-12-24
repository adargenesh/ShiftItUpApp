using ShiftItUpApp.ViewModels;

namespace ShiftItUpApp.Views;

public partial class RegisterStoreView : ContentPage
{
	public RegisterStoreView(RegisterStoreViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}