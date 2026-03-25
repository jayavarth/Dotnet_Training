using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Ques3
    {
        public static void Calculator()
        {
            int x, y;
            char c;
            Console.WriteLine("Input first number:");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Input operation:");
            //c = Console.ReadKey().KeyChar;
            c = Console.ReadLine()[0];
            Console.WriteLine("Input Second number:");
            y = int.Parse(Console.ReadLine());

            switch (c)
            {
                case '+':
                    Console.WriteLine($"{x}{c}{y}={x+y}");
                    break;
                case '-':
                    Console.WriteLine($"{x}{c}{y}={x-y}");
                    break;
                case '*':
                    Console.WriteLine($"{x}{c}{y}={x*y}");
                    break;
                case '/':
                    Console.WriteLine($"{x}{c}{y}={x/y}");
                    break;
                default: 
                    Console.WriteLine("Invalid operator");
                    break;
            }
        }
    }
}
