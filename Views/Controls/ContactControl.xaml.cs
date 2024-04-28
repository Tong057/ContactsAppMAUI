using System.Runtime.CompilerServices;

namespace ContactsAppMAUI.Views.Controls;

public partial class ContactControl : ContentView
{
    public bool IsForAdd { get; set; }
    public bool IsForEdit { get; set; }

    public ContactControl()
	{
		InitializeComponent();
	}
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (IsForAdd && !IsForEdit)
        {
            SaveButton.SetBinding(Button.CommandProperty, "AddContactCommand");
        }
        else if (!IsForAdd && IsForEdit)
        {
            SaveButton.SetBinding(Button.CommandProperty, "EditContactCommand");
        }
    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopAsync();
    }
}