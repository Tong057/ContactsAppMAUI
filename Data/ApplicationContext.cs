using Microsoft.EntityFrameworkCore;
using ContactsAppMAUI.Models;
using Contact = ContactsAppMAUI.Models.Contact;

namespace ContactsAppMAUI.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Address> Addresses => Set<Address>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=" + Constants.DatabasePath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Contact)
                .HasForeignKey<Address>(a => a.ContactId);
        }
    }
}
