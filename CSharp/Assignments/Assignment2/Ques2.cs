using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Ques2
    {
        enum days { Monday=1,Tuesday=2,Wednesday=3,Thursday=4,Friday=5,Saturday=6,Sunday=7};
        public static void week()
        {
            int n=int.Parse(Console.ReadLine());
            Console.WriteLine(Enum.GetName(typeof(days),n));
        }
    }
}
