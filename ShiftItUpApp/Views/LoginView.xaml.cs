using ShiftItUpApp.ViewModels;

namespace ShiftItUpApp.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel vm)
	{
		this.BindingContext = vm;	
		InitializeComponent();
	}
}