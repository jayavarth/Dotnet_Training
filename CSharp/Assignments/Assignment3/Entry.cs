using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Bank Account");
            Ques1_Account.Account();
            Console.WriteLine("----------------");
            Console.WriteLine("2.Student Marks");
            Ques2_Student.Student();
            Console.WriteLine("----------------");
            Console.WriteLine("3.Sales details");
            Ques3_Sales.Salesdetail();
        }
    }
}
