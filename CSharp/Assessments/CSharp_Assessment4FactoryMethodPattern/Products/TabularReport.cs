using CSharp_Assessment4FactoryMethodPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Assessment4FactoryMethodPattern.Products
{
    public class TabularReport : IReport
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating Tabular Report");
        }
    }
}
