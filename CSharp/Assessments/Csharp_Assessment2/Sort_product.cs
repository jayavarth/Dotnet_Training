using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Assessment2
{
    class Product
    {
        public int ProductId {get;set;}
        public string ProductName {get;set;}
        public double Price {get;set;}
    }

    internal class Sort_product
    {
        public static void Main()
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("Enter 10 product details:");

            for (int i = 0; i < 10; i++)
            {
                Product p = new Product();
                Console.Write("Product ID:");
                p.ProductId = int.Parse(Console.ReadLine());
                Console.Write("Product name:");
                p.ProductName = Console.ReadLine();
                Console.Write("Price:");
                p.Price = double.Parse(Console.ReadLine());
                products.Add(p);
            }
            products.Sort((a, b) => a.Price.CompareTo(b.Price));

            Console.WriteLine("Sorted Products by Price:");
            Console.WriteLine("Product Id / p.Product Name / Price");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductId} - {p.ProductName} - {p.Price}");
            }
    }
}
}
