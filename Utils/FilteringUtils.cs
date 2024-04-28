using ContactsAppMAUI.Models;
using System.Collections.ObjectModel;
using Contact = ContactsAppMAUI.Models.Contact;

namespace ContactsAppMAUI.Utils
{
    public static class FilteringUtils
    {
        public static IEnumerable<Contact> FindContacts(string filterText, int? selectedFilterIndex, ContactRepository contactRepository)
        {
            filterText = filterText.ToLower();
            switch (selectedFilterIndex)
            {
                case 0:
                    return contactRepository.GetContactsByName(filterText);
                case 1:
                    return contactRepository.GetContactsBySurname(filterText);
                case 2:
                    return contactRepository.GetContactsByCity(filterText);
                case 3:
                    return contactRepository.GetContactsByPhone(filterText);
                default:
                    goto case 0;
            }
        }

        public static IEnumerable<Contact> SortContacts(int? selectedSortIndex, ObservableCollection<Contact> contacts)
        {
            switch (selectedSortIndex)
            {
                case 0:
                    return contacts.OrderBy(c => c.FirstName).ToList();
                case 1:
                    return contacts.OrderByDescending(c => c.FirstName).ToList();
                default:
                    goto case 0;
            }
        }

        public static IEnumerable<Contact> TransformContacts(int? selectedTransformIndex, ObservableCollection<Contact> contacts)
        {
            switch (selectedTransformIndex)
            {
                case 0:
                    return contacts
                        .Select(c => new Contact(
                            c.Id,
                            c.FirstName.ToUpper(),
                            c.LastName.ToUpper(),
                            c.PhoneNumber,
                            new Address
                            {
                                City = c.Address.City,
                                Street = c.Address.Street
                            })).ToList();

                case 1:
                    return contacts.Select(c => new Contact(
                        c.Id,
                        TransformCase(c.FirstName),
                        TransformCase(c.LastName),
                        c.PhoneNumber,
                        new Address
                        {
                            City = c.Address.City,
                            Street = c.Address.Street
                        })).ToList();

                case 2:
                    char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                    return contacts.Select(c => new Contact(
                        c.Id,
                        RemoveVowels(c.FirstName),
                        RemoveVowels(c.LastName),
                        c.PhoneNumber,
                        new Address
                        {
                            City = c.Address.City,
                            Street = c.Address.Street
                        })).ToList();

                default:
                    goto case 0;
            }
        }

        private static string TransformCase(string input)
        {
            return input.Select((c, i) => i % 2 == 0 ? char.ToUpper(c) : char.ToLower(c))
                .Aggregate(string.Empty, (result, c) => result + c);
        }

        private static bool IsVowel(char c) => "aeiouAEIOU".Contains(c);
        private static string RemoveVowels(string input) => new string(input.Where(c => !IsVowel(c)).ToArray());


        public static bool TestContacts(string filterText, string selectedTestItem, ContactRepository contactRepository)
        {
            switch (selectedTestItem)
            {
                case "Any contacts with this Name":
                    return contactRepository.AnyContactsWithName(filterText);

                case "Any contacts with this Name length":
                    int.TryParse(filterText, out int length);
                    return contactRepository.AnyContactsWithNameLength(length);

                case "Any contacts with this number start":
                    return contactRepository.AnyContactsWithPhoneStart(filterText);

                default:
                    return false;
            }
        }

        public static string AggregateContacts(string selectedAggregateItem, ObservableCollection<Contact> contacts)
        {
            switch (selectedAggregateItem)
            {
                case "Amount of contacts":
                    int amount = contacts.Aggregate(0, (amount, contact) => amount + 1);
                    return amount.ToString();

                case "Average name length":
                    double average = contacts.Aggregate(0.0, (total, contact) =>
                        total + contact.FirstName.Length + contact.LastName.Length, result => result / contacts.Count);
                    return average.ToString();

                case "Longest phone number":
                    Contact contact = contacts.Aggregate((maxContact, nextContact) =>
                        nextContact.PhoneNumber.Length > maxContact.PhoneNumber.Length ? nextContact : maxContact);
                    return $"{contact.FullName} has the longest phone number: {contact.PhoneNumber}";

                default:
                    return "";
            }
        }


    }
}
