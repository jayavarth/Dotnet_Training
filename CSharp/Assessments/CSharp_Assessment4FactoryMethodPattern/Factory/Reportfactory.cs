using CSharp_Assessment4FactoryMethodPattern.Interface;
using CSharp_Assessment4FactoryMethodPattern.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Assessment4FactoryMethodPattern.Factory
{
    public class ReportFactory : IReportFactory
    {
        public IReport CreateReport(string type)
        {
            switch (type.ToLower())
            {
                case "chart": 
                    return new ChartReport();
                case "tabular": 
                    return new TabularReport();
                case "summary": 
                    return new SummaryReport();
                default: 
                    return null;
            }
        }
    }

}
