using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindMVC.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }
    }
}
