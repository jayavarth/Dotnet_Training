using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.");
            Ques1.Remove();
            Console.WriteLine("2.Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.\r\n");
            Ques2.Exchange();
            Console.WriteLine("3.Write a C# program to sort the elements of a given stack in descending order. ");
            Ques3.Stack_desc();
        }
    }
}
