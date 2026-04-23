using CSharp_Assessment4FactoryMethodPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Assessment4FactoryMethodPattern.Factory
{
    public interface IReportFactory
    {
        IReport CreateReport(string type);
    }

}
