using ShiftItUpApp.ViewModels;

namespace ShiftItUpApp.Views;

public partial class ContactsListView : ContentPage
{
	public ContactsListView(ContactsListViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}