using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Ques5
    {
        public static void Triplet()
        {
            Console.WriteLine("Enter the value of x:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the value of y:");
            int y = int.Parse(Console.ReadLine());
            int sum=x+y;
            Console.WriteLine(x==y?3*sum:sum);
        }
    }
}
