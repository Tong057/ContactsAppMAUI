using ContactsAppMAUI.ViewModels;

namespace ContactsAppMAUI.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private readonly ContactViewModel _contactViewModel;
	public EditContactPage(ContactViewModel contactViewModel)
	{
		InitializeComponent();
		BindingContext = contactViewModel;
		_contactViewModel = contactViewModel;
	}

    public string ContactId
    {
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out int contactId))
            {
                LoadContact(contactId);
            }
        }
    }

    private async void LoadContact(int contactId)
    {
        await _contactViewModel.LoadContactAsync(contactId);
    }
}