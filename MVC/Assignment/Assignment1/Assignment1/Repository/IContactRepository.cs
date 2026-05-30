using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Assignment1.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();

        Task CreateAsync(Contact contact);

        Task DeleteAsync(long id);
    }
}