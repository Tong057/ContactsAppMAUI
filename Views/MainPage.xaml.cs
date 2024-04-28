using ContactsAppMAUI.Views;
using ContactsAppMAUI.ViewModels;

namespace ContactsAppMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly FilterBottomSheet _bottomSheet;
        private readonly ContactListViewModel _contactListViewModel;
        public MainPage(ContactListViewModel contactListViewModel)
        {
            InitializeComponent();
            BindingContext = contactListViewModel;
            _contactListViewModel = contactListViewModel;
            _bottomSheet = new FilterBottomSheet(contactListViewModel);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _contactListViewModel.LoadContactsAsync();
        }

        private async void FilterBottomSheetButton_Clicked(object sender, EventArgs e)
        {
            await _bottomSheet.ShowAsync();
        }

    }

}
