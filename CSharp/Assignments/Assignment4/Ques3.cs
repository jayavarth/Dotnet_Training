using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Ques3
    {
        public static void Stack_desc()
        {
            Stack<int> stack = new Stack<int>();

            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter elements:");
            for (int i = 0; i < n; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }

            List<int> list = new List<int>(stack);
            list.Sort((a, b) => b.CompareTo(a));
            stack = new Stack<int>();
            foreach (int item in list)
            {
                stack.Push(item);
            }

            Console.WriteLine("Stack elements in descending order:");
            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
