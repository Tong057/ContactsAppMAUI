using ContactsAppMAUI.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactsAppMAUI.Models
{
    public class ContactRepository
    {
        private readonly ApplicationContext _appContext;
        public ContactRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await _appContext.Contacts.Include(c => c.Address).ToListAsync();
        }

        public async Task<Contact> GetContactAsync(int id)
        {
            return await _appContext.Contacts.Include(c => c.Address).FirstAsync(c => c.Id == id);
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await GetContactAsync(id);
            _appContext.Contacts.Remove(contact);
            await _appContext.SaveChangesAsync();
        }

        public async Task AddContactAsync(Contact contact)
        {
            await _appContext.Contacts.AddAsync(contact);
            await _appContext.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact target)
        {
            Contact contact = await GetContactAsync(target.Id);
            contact.FirstName = target.FirstName;
            contact.LastName = target.LastName;
            contact.PhoneNumber = target.PhoneNumber;
            contact.Address.City = target.Address.City;
            contact.Address.Street = target.Address.Street;

            await _appContext.SaveChangesAsync();
        }

        public IEnumerable<Contact> GetContactsByName(string name)
        {
            name = name.ToLower();
            return _appContext.Contacts.Include(c => c.Address)
                    .Where(c => c.FirstName.ToLower()
                    .Contains(name));
        }

        public IEnumerable<Contact> GetContactsBySurname(string surname)
        {
            surname = surname.ToLower();
            return _appContext.Contacts.Include(c => c.Address)
                    .Where(c => c.LastName.ToLower()
                    .Contains(surname));
        }

        public IEnumerable<Contact> GetContactsByCity(string city)
        {
            city = city.ToLower();
            return _appContext.Contacts.Include(c => c.Address)
                    .Where(c => c.Address.City.ToLower()
                    .Contains(city));
        }

        public IEnumerable<Contact> GetContactsByPhone(string phone)
        {
            phone = phone.ToLower();
            return _appContext.Contacts.Include(c => c.Address)
                    .Where(c => c.PhoneNumber.ToLower()
                    .Contains(phone));
        }

        public bool AnyContactsWithName(string name)
        {
            string lowerName = name.ToLower();
            return _appContext.Contacts.Any(c => c.FirstName.ToLower().Equals(lowerName));
        }
        public bool AnyContactsWithNameLength(int length)
        {
            return _appContext.Contacts.Any(c => c.FirstName.Length == length);
        }
        public bool AnyContactsWithPhoneStart(string phoneStart)
        {
            return _appContext.Contacts.Any(c => c.PhoneNumber.StartsWith(phoneStart));
        }

    }
}
