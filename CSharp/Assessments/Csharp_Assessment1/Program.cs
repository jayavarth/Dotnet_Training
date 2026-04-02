using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Assessment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee e = new Employee();
            //int n = int.Parse(Console.ReadLine());
            //do
            //{
            //    switch (n)
            //    {
            //        case 1:
            //            e.Add();
            //            break;
            //        case 2:
            //            e.view();
            //            break;
            //        case 3:
            //            e.search();
            //            break;
            //        case 4:
            //            e.update();
            //            break;
            //        case 5:
            //            e.delete();
            //            break;
            //        case 6:
            //            n = -1;
            //    }
            //}
            //while (n > 0 && n < 7);
            EmployeeManagement.ems();
            Nested_struct.Emp_birth();
        }
    }
}
