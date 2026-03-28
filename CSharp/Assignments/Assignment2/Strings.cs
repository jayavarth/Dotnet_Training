using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Strings
    {
        public static void Manipulation()
        {
            Console.WriteLine("Enter a word :");
            string w=Console.ReadLine();
            Console.WriteLine("Length of the word:",w.Length);

            string reverse = "";
            for(int i = w.Length - 1; i >= 0; i--)
            {
                reverse+= w[i];
            }
            Console.WriteLine("Reversed word:",reverse);

            Console.WriteLine("First word : ");
            string w1 = Console.ReadLine();
            Console.WriteLine("Second word : ");
            string w2 = Console.ReadLine();
            if (w1.Equals(w2))
            {
                Console.WriteLine("Both are same");
            }
            else
            {
                Console.WriteLine('Both are different');
            }
        }
    }
}
