using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }
    internal class Ques3
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            Console.WriteLine("Enter no of employees:");
            int n=int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter details for Employee {i + 1}:");

                Employee emp = new Employee();

                Console.Write("Employee Id: ");
                emp.EmpId = int.Parse(Console.ReadLine());

                Console.Write("Employee Name: ");
                emp.EmpName = Console.ReadLine();

                Console.Write("Employee City: ");
                emp.EmpCity = Console.ReadLine();

                Console.Write("Employee Salary: ");
                emp.EmpSalary = double.Parse(Console.ReadLine());

                employees.Add(emp);
            }
            Console.WriteLine("\nAll Employees:");
            Display(employees);

            Console.WriteLine("Employees with Salary > 45000:");
            var highSalary = employees.Where(e => e.EmpSalary > 45000).ToList();

            Display(highSalary);

            Console.WriteLine("Employees from Bangalore:");
            var bangalore = employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase)).ToList();

            Display(bangalore);

            Console.WriteLine("Employees sorted by Name:");
            var sorted = employees.OrderBy(e => e.EmpName).ToList();

            Display(sorted);
        }
        static void Display(List<Employee> list)
        {
            foreach (var e in list)
            {
                Console.WriteLine($"{e.EmpId}-{e.EmpName}-{e.EmpCity}-{e.EmpSalary}");
            }
        }
    }
}
