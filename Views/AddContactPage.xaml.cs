using ContactsAppMAUI.ViewModels;

namespace ContactsAppMAUI.Views;

public partial class AddContactPage : ContentPage
{
	private readonly ContactViewModel _contactViewModel;
	public AddContactPage(ContactViewModel contactViewModel)
	{
		InitializeComponent();
        BindingContext = contactViewModel;
        _contactViewModel = contactViewModel;
	}
}