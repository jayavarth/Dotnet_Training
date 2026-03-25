using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Ques2
    {
        public static void Ispositive()
        {
            Console.WriteLine("Enter the number:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine(x==0?$"{x}-Neither ositive nor negative":(x>0)?$"{x} is a positive number":$"{x} is a negative number");
        }
    }
}
