using The49.Maui.BottomSheet;
using ContactsAppMAUI.ViewModels;

namespace ContactsAppMAUI.Views;

public partial class FilterBottomSheet : BottomSheet
{
	public FilterBottomSheet(ContactListViewModel contactListViewModel)
	{
		InitializeComponent();
		BindingContext = contactListViewModel;
	}
}