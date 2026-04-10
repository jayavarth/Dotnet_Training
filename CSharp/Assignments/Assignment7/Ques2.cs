using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    internal class Ques2
    {
        public static void Main()
        {
            string[] words = new string[3];
            Console.WriteLine("Enter any three words seperated by space");
            string val = Console.ReadLine();
            words = val.Split(' ');
            foreach (var word in words)
            {
                if (word.StartsWith("a") && word.EndsWith("m"))
                {
                    Console.WriteLine("Word that starts with 'a' and ends with 'm' is : " + word);
                }
            }
        }
    }
}