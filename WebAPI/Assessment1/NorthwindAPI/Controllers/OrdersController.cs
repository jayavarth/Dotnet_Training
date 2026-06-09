using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NorthwindAPI.Controllers
{
    public class OrdersController : ApiController
    {
        northwindEntities db =new northwindEntities();

        [HttpGet]
        [Route("api/orders/employee5")]
        public IHttpActionResult GetOrdersByEmployee()
        {
            var orders = db.Orders
                           .Where(x => x.EmployeeID == 5)
                           .Select(x => new
                           {
                               x.OrderID,
                               x.CustomerID,
                               x.EmployeeID,
                               x.OrderDate,
                               x.RequiredDate,
                               x.ShippedDate
                           })
                           .ToList();

            return Ok(orders);
        }
    }
}
