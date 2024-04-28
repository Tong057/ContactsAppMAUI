using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactsAppMAUI.Models
{
    public class Address : ObservableObject
    {
        [Key]
        public int Id { get; set; }

        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }
        private string _city;

        public string Street { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public Address() { }

        public override string ToString()
        {
            return $"{City} {Street}";
        }

    }
}
