using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Ques2
    {
        public static void Exchange()
        {
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();

            if (str.Length <= 1)
            {
                Console.WriteLine("Result: " + str);
            }
            else
            {
                char first = str[0];
                char last = str[str.Length - 1];

                string middle = str.Substring(1, str.Length - 2);

                string result = last + middle + first;

                Console.WriteLine("Result: " + result);
            }
        }
    }
}
