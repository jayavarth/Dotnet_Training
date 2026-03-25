using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Ques1
    {
        public static void IsEqual()
        {
            int a, b;
            Console.WriteLine("Input 1st number: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Input 2nd number: ");
            b = int.Parse(Console.ReadLine());

            Console.WriteLine(a == b ? $"{a} and {b} are equal" : $"{a} and {b} are not equal");
        }
    }
}
