using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_AssessmentNunit.Concrete;

namespace CSharp_AssessmentNunit.BL
{
    internal class DistanceBL
    {
        public static Distance Add(Distance d1, Distance d2)
        {
            int sum = d1.Kilometer + d2.Kilometer;
            return new Distance(sum);
        }
    }
}
