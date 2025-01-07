using ShiftItUpApp.ViewModels;

namespace ShiftItUpApp.Views;

public partial class ProfileView : ContentPage
{
	public ProfileView(ProfileViewModel vm)
	{
		 this.BindingContext = vm;
		InitializeComponent();
	}
}