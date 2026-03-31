using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Ques3_Sales
    {
        int salesNo, productNo, qty;
        double price, totalAmount;
        string dateOfSale;

        public Ques3_Sales(int salesNo, int productNo, double price, int qty, string date)
        {
            this.salesNo = salesNo;
            this.productNo = productNo;
            this.price = price;
            this.qty = qty;
            this.dateOfSale = date;
        }

        public void Sales()
        {
            totalAmount = qty * price;
        }

        public void ShowData()
        {
            Console.WriteLine($"SalesNo: {salesNo}, ProductNo: {productNo}, Price: {price}, Qty: {qty}, Date: {dateOfSale}, Total: {totalAmount}");
        }

        public static void Salesdetail()
        {
            Console.WriteLine("Enter Sales No:");
            int sNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product No:");
            int pNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Price:");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Quantity:");
            int qty = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Date:");
            string date = Console.ReadLine();

            Ques3_Sales s = new Ques3_Sales(sNo, pNo, price, qty, date);

            s.Sales();
            s.ShowData();
        }
    }
}
