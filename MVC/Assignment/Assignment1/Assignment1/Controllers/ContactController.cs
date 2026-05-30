using Assignment1.Models;
using Assignment1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactRepository repository;

        public ContactController()
        {
            repository = new ContactRepository();
        }

        public async Task<ActionResult> Index()
        {
            var contacts =
                await repository.GetAllAsync();

            return View(contacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(contact);

                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
            await repository.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}