using CSharp_AssessmentNunit.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_AssessmentNunit.Concrete
{
    class Distance : IDistance
    {
        public int Kilometer { get; set; }
        public Distance(int km)
        {
            Kilometer = km;
        }
        public void Display()
        {
            Console.WriteLine("Total Distance: " + Kilometer + " km");
        }
    }
}
