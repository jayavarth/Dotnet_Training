using Newtonsoft.Json;
using NorthwindMVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NorthwindMVC.Controllers
{
    public class OrdersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();

            string apiUrl =
             "https://localhost:44300/api/orders/employee5";

            HttpResponseMessage response =
                await client.GetAsync(apiUrl);

            string json =
                await response.Content.ReadAsStringAsync();

            List<OrderModel> orders =
                JsonConvert.DeserializeObject<List<OrderModel>>(json);

            return View(orders);
        }
    }
}