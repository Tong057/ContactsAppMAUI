using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsAppMAUI.Models;
using ContactsAppMAUI.Views;
using ContactsAppMAUI.Utils;
using System.Collections.ObjectModel;
using Contact = ContactsAppMAUI.Models.Contact;

namespace ContactsAppMAUI.ViewModels
{
    public partial class ContactListViewModel : ObservableObject
    {
        private readonly ContactRepository _contactBook;

        public ContactListViewModel(ContactRepository contactRepository)
        {
            _contactBook = contactRepository;
            _contacts = new ObservableCollection<Contact>();
        }

        [ObservableProperty]
        private ObservableCollection<Contact> _contacts;

        [RelayCommand]
        private async Task ResetFilterOptions()
        {
            FilterText = "";
            await LoadContactsAsync();
        }

        [RelayCommand]
        private async Task OpenAddPage()
        {
            await Shell.Current.GoToAsync(nameof(AddContactPage));
        }

        [RelayCommand]
        private async Task OpenEditPage(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={id}");
        }

        [RelayCommand]
        private async Task DeleteContact(int id)
        {
            await _contactBook.DeleteContactAsync(id);
            await LoadContactsAsync();
        }

        public async Task LoadContactsAsync()
        {
            Contacts.Clear();

            var contacts = await _contactBook.GetAllContactsAsync();
            if (contacts != null && contacts.Any())
            {
                foreach (var contact in contacts)
                {
                    Contacts.Add(contact);
                }
            }
        }

        public void LoadContacts(IEnumerable<Contact> contacts)
        {
            Contacts.Clear();

            if (contacts != null && contacts.Any())
            {
                foreach (var contact in contacts)
                {
                    Contacts.Add(contact);
                }
            }
        }

        #region Filtering section

        private string _filterText;
        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));
                LoadContacts(FilteringUtils.FindContacts(_filterText, SelectedFilterIndex, _contactBook));
            }
        }

        [ObservableProperty]
        private int? _selectedFilterIndex;


        private int? _selectedSortIndex;
        public int? SelectedSortIndex
        {
            get => _selectedSortIndex;
            set
            {
                _selectedSortIndex = value;
                if (_selectedSortIndex != null)
                    LoadContacts(FilteringUtils.SortContacts(_selectedSortIndex, Contacts));
            }
        }

        private int? _selectedTransformIndex;
        public int? SelectedTransformIndex
        {
            get => _selectedTransformIndex;
            set
            {
                _selectedTransformIndex = value;
                if (_selectedTransformIndex != null)
                    LoadContacts(FilteringUtils.TransformContacts(_selectedTransformIndex, Contacts));
            }
        }

        private string _selectedTestItem;
        public string SelectedTestItem
        {
            get => _selectedTestItem;
            set
            {
                _selectedTestItem = value;
                if (_selectedTestItem != null)
                {
                    AppShell.Current.DisplayAlert(_selectedTestItem + "?",
                        FilteringUtils.TestContacts(FilterText, _selectedTestItem, _contactBook).ToString(), "Ok");
                }
            }
        }

        private string _selectedAggregateItem;
        public string SelectedAggregateItem
        {
            get => _selectedAggregateItem;
            set
            {
                _selectedAggregateItem = value;
                if (_selectedAggregateItem != null)
                {
                    AppShell.Current.DisplayAlert(_selectedAggregateItem, FilteringUtils.AggregateContacts(_selectedAggregateItem, Contacts), "Ok");
                }
            }
        }
        #endregion

    }
}
