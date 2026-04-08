using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Assessment2
{
    class Calculator
    {
        public delegate int Operation(int a, int b);
        public static int Add(int a, int b) { return a+b; }
        public static int Subtract(int a, int b) { return a-b; }
        public static int Multiply(int a, int b) { return a*b; }
    }

    internal class Arithmetic
    {
        public static void Main()
        {
            Console.Write("Enter first number:");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter second number:");
            int y = int.Parse(Console.ReadLine());

            Calculator.Operation val;
            val = Calculator.Add;
            Console.WriteLine($"Addition:{x}+{y}={val(x,y)}");
            val = Calculator.Subtract;
            Console.WriteLine($"Subtraction:{x}-{y}={val(x,y)}");
            val = Calculator.Multiply;
            Console.WriteLine($"Multiplication:{x}*{y}={val(x,y)}");
        }
    }
}
