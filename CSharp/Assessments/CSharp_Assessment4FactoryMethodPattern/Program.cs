using CSharp_Assessment4FactoryMethodPattern.Factory;
using CSharp_Assessment4FactoryMethodPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Assessment4FactoryMethodPattern
{
    internal class Program
    {
        public static void Main()
        {
            IReportFactory factory = new ReportFactory();

            Console.Write("Enter Report Type (chart/tabular/summary): ");
            string choice = Console.ReadLine();
            IReport report = factory.CreateReport(choice);

            if (report != null)
                report.GenerateReport();
            else
                Console.WriteLine("Invalid Type");
        }
    }
}
