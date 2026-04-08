using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Assessment2
{
    class NegativeNumException : Exception
    {
        public NegativeNumException(string msg):base(msg) { }
    }

    internal class NegativeException
    {
        public static void Main()
        {
            try
            {
                Console.Write("Enter a number:");
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new NegativeNumException("Number can't be zero");
                }
                else
                {
                    Console.WriteLine("Valid number:" + number);
                }
            }
            catch (NegativeNumException e)
            {
                Console.WriteLine("Exception caught:" + e.Message);
            }
        }

    }
}
