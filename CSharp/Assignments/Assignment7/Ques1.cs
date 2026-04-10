using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    internal class Ques1
    {
        static void Main(string[] args)
        {
            int[] n = new int[3];
            Console.WriteLine("Enter 3 array values");
            for (int i = 0; i < n.Length; i++)
            {
                n[i] = int.Parse(Console.ReadLine());
            }

            var res = n.Where(x => x * x > 20).Select(x => x);

            foreach (int x in res)
            {
                Console.WriteLine($"{x}=>{x * x}");
            }
        }
    }
}