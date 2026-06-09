using Assessment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Assessment1.Controllers
{
    public class CountryController : ApiController
    {
        public class AppDbContext : DbContext
        {
            public DbSet<Country> Countries { get; set; }
        }

        private AppDbContext db = new AppDbContext();

        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            var countries = db.Countries.ToList();

            if (countries == null || countries.Count == 0)
                return NotFound();

            return Ok(countries);
        }

        [HttpGet]
        public IHttpActionResult GetCountry(int id)
        {
            var country = db.Countries.Find(id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }

        [HttpPost]
        public IHttpActionResult AddCountry([FromBody] Country country)
        {
            if (country == null)
                return BadRequest("Invalid data.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Countries.Add(country);
            db.SaveChanges();

            return Ok(country);
        }

        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, [FromBody] Country country)
        {
            if (country == null)
                return BadRequest("Invalid data.");

            var existingCountry = db.Countries.Find(id);

            if (existingCountry == null)
                return NotFound();

            existingCountry.CountryName = country.CountryName;
            existingCountry.Capital = country.Capital;

            db.SaveChanges();

            return Ok(existingCountry);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = db.Countries.Find(id);

            if (country == null)
                return NotFound();

            db.Countries.Remove(country);
            db.SaveChanges();

            return Ok("Country deleted successfully.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}