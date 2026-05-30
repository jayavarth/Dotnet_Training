using Assignment1.Models;
using Assignment1.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Assignment1.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext db;

        public ContactRepository()
        {
            db = new ContactContext();
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await db.Contacts.ToListAsync();
        }

        public async Task CreateAsync(Contact contact)
        {
            db.Contacts.Add(contact);

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            Contact contact =
                await db.Contacts.FindAsync(id);

            if (contact != null)
            {
                db.Contacts.Remove(contact);

                await db.SaveChangesAsync();
            }
        }
    }
}
