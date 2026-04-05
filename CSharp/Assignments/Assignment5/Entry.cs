using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exception Handling:Banking system");
            Ques1.Accounts();
            Console.WriteLine("----------------\nException Handling:Scholarship");
            Ques2.Qualify();
            Console.WriteLine("----------------\nIndexers:Books");
            Ques3.Bookindex();
        }
    }
}
