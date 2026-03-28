using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Ques1
    {
        public static void Pattern()
        {
            int n=int.Parse(Console.ReadLine());
            for(int i = 0; i <= 1; i++)
            {
                Console.WriteLine($"{n} {n} {n} {n}\n{n}{n}{n}{n}");
            }
        }
    }
}
