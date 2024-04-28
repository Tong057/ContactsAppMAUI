using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsAppMAUI.Models;
using Contact = ContactsAppMAUI.Models.Contact;

namespace ContactsAppMAUI.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private Contact _contact;
        private readonly ContactRepository _contactRepository;

        public bool IsNameProvided { get; set; }
        public bool IsSurnameProvided { get; set; }
        public bool IsPhoneProvided { get; set; }
        public bool IsCityProvided { get; set; }
        public bool IsStreetProvided { get; set; }

        public Contact Contact
        {
            get => _contact;
            set
            {
                SetProperty(ref _contact, value);
            }
        }

        public ContactViewModel(ContactRepository contactRepository)
        {
            Contact = new();
            _contactRepository = contactRepository;
        }

        public async Task LoadContactAsync(int id)
        {
            var contact = await _contactRepository.GetContactAsync(id);

            Contact = new Contact
            {
                Id = id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber,
                Address = new Address
                {
                    City = contact.Address.City,
                    Street = contact.Address.Street
                } 
            };
        }

        [RelayCommand]
        public async Task EditContact()
        {
            if (await ValidateContact())
            {
                await _contactRepository.UpdateContactAsync(_contact);
                await Shell.Current.Navigation.PopAsync(true);
            }
        }

        [RelayCommand]
        public async Task AddContact()
        {
            if (await ValidateContact())
            {
                await _contactRepository.AddContactAsync(_contact);
                await Shell.Current.Navigation.PopAsync(true);
            }
        }

        private async Task<bool> ValidateContact()
        {
            if (!IsNameProvided)
            {
                await Shell.Current.DisplayAlert("Error", "Name is required.", "OK");
                return false;
            }
            if (!IsSurnameProvided)
            {
                await Shell.Current.DisplayAlert("Error", "Surname is required.", "OK");
                return false;
            }
            if (!IsPhoneProvided)
            {
                await Shell.Current.DisplayAlert("Error", "Phone is required.", "OK");
                return false;
            }
            if (!IsCityProvided)
            {
                _contact.Address.City = "";
            }
            if (!IsStreetProvided)
            {
                _contact.Address.Street = "";
            }

            return true;
        }

    }
}
