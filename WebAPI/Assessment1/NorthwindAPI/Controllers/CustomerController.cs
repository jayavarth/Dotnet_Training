using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NorthwindAPI.Controllers
{
    public class CustomerController : ApiController
    {
        northwindEntities db =
            new northwindEntities();

        [HttpGet]
        [Route("api/customer/bycountry/{country}")]
        public IHttpActionResult GetCustomerByCountry(string country)
        {
            var customers =
                db.GetCustomersByCountry(country);

            return Ok(customers);
        }
    }
}
