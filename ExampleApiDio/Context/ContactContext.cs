using ExampleApiDio.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleApiDio.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext(
            DbContextOptions<ContactContext> options
        ) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}