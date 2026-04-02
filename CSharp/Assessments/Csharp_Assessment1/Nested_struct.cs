using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Assessment1
{
    internal class Nested_struct
    {
        public struct DOB
        {
            public int day;
            public int month;
            public int year;
        }
        public struct Employee
        {
            public string Name;
            public DOB d;
        }
        public static void Emp_birth()

        {
            Employee[] emp = new Employee[2];

            for (int i = 0; i < emp.Length; i++)
            {
                Console.Write("Name of the employee:");
                emp[i].Name = Console.ReadLine();
                Console.Write("Input day of the birth :");
                emp[i].d.day = int.Parse(Console.ReadLine());
                Console.Write("Input month of the birth :");
                emp[i].d.month = int.Parse(Console.ReadLine());
                Console.Write("Input year for the birth:");
                emp[i].d.year = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\nEmployee Details:\n");

            for (int i =0;i<emp.Length; i++)
            {
                Console.WriteLine($"Name: {emp[i].Name}\nDOB: {emp[i].d.day}/{emp[i].d.month}/{emp[i].d.year}\n-----------");
            }
        }
    }
}
