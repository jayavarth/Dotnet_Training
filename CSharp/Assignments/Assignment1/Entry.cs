using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Write a C# Sharp program to accept two integers and check whether they are equal or not.");
            Ques1.IsEqual();
            Console.WriteLine("2. Write a C# Sharp program to check whether a given number is positive or negative.");
            Ques2.Ispositive();
            Console.WriteLine("3. Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. ");
            Ques3.Calculator();
            Console.WriteLine("4. Write a C# Sharp program that prints the multiplication table of a number as input.\r\n");
            Ques4.Multi_Table();
            Console.WriteLine("5.  Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.");
            Ques5.Triplet();
        }
    }
}
