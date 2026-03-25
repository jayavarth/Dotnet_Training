using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Ques4
    {
        public static void Multi_Table()
        {
            Console.WriteLine("Enter the number");
            int x = int.Parse(Console.ReadLine());
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{i}x{x}={i*x}");
            }
        }
    }
}
