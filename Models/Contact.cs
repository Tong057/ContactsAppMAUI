using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactsAppMAUI.Models
{
    public class Contact : ObservableObject
    {
        [Key]
        public int Id { get; set; }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        private string _firstName;

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
        private string _lastName;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }
        private string _phoneNumber;

        public Address Address { get; set; } = new Address();

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public Contact(string firstName, string lastName, string phoneNumber, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public Contact(int id, string firstName, string lastName, string phoneNumber, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public Contact()
        {

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {PhoneNumber}";
        }
    }
}