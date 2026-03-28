using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and then four times in the next row, with no separation. You should do it twice: Use the console. Write and use {0}.");
            Ques1.Pattern();
            Console.WriteLine("2. Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.");
            Ques2.week();
            Console.WriteLine("1. Write a Program to assign integer values to an array  and then print the following\r\n\ta.\tAverage value of Array elements\r\n\tb.\tMinimum and Maximum value in an array ");
            ArrayQues1.Array_fun();
            Console.WriteLine("2. Write a program in C# to accept ten marks and display the following\r\n\ta.\tTotal\r\n\tb.\tAverage\r\n\tc.\tMinimum marks\r\n\td.\tMaximum marks\r\n\te.\tDisplay marks in ascending order\r\n\tf.\tDisplay marks in descending order");
            ArrayQues2.Marks();
            Console.WriteLine("3. Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions, write your own logic)\r\n");
            ArrayQues3.CopyArray();
            Console.WriteLine("Strings Assignment :\r\n\r\n1.\tWrite a program in C# to accept a word from the user and display the length of it.\r\n2.\tWrite a program in C# to accept a word from the user and display the reverse of it. \r\n3.\tWrite a program in C# to accept two words from user and find out if they are same. ");
            Strings.Manipulation();
        }
    }
}
