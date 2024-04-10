using ExampleApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext(
            DbContextOptions<ContactContext> options
        ) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}