using CSharp_AssessmentNunit.BL;
using CSharp_AssessmentNunit.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_AssessmentNunit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter distance 1:");
            int km1 = int.Parse(Console.ReadLine());
            Console.Write("Enter distance 2:");
            int km2 = int.Parse(Console.ReadLine());

            Distance d1 = new Distance(km1);
            Distance d2 = new Distance(km2);
            Distance d3 = DistanceBL.Add(d1, d2);
            d3.Display();

            Console.ReadLine();
        }
    }
}
