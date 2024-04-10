using ExampleApi.Context;
using ExampleApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ContactContext _context;

        public ContactController(ContactContext context) =>
            _context = context;

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = contact.Id },
                contact
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact is null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var contacts = _context.Contacts.Where(contact =>
                contact.Name.Contains(name)
            );

            if (contacts is null || !contacts.Any())
                return NotFound();

            return Ok(contacts);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            var oldContact = _context.Contacts.Find(id);

            if (oldContact is null)
                return NotFound();

            oldContact.Name = contact.Name;
            oldContact.PhoneNumber = contact.PhoneNumber;
            oldContact.IsActive = contact.IsActive;

            _context.Contacts.Update(oldContact);
            _context.SaveChanges();

            return Ok(oldContact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contactToDelete = _context.Contacts.Find(id);

            if (contactToDelete is null)
                return NotFound();

            _context.Contacts.Remove(contactToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}