using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Assessment4
{
    public class Employee
    {
        public int EmployeeID;
        public string FirstName;
        public string LastName;
        public string Title;
        public string DOB;
        public string DOJ;
        public string City;
    }
    internal class Ques3
    {
        public static void Main()
        {
            List<Employee> empList = new List<Employee>();

            empList.Add(new Employee
            {
                EmployeeID = 1001,
                FirstName = "Malcolm",
                LastName = "Daruwalla",
                Title = "Manager",
                DOB = "16/11/1984",
                DOJ = "8/6/2011",
                City = "Mumbai"
            });

            empList.Add(new Employee
            {
                EmployeeID = 1002,
                FirstName = "Asdin",
                LastName = "Dhalla",
                Title = "AsstManager",
                DOB = "20/08/1984",
                DOJ = "7/7/2012",
                City = "Mumbai"
            });

            empList.Add(new Employee
            {
                EmployeeID = 1003,
                FirstName = "Madhavi",
                LastName = "Oza",
                Title = "Consultant",
                DOB = "14/11/1987",
                DOJ = "12/4/2015",
                City = "Pune"
            });

            empList.Add(new Employee
            {
                EmployeeID = 1004,
                FirstName = "Saba",
                LastName = "Shaikh",
                Title = "SE",
                DOB = "3/6/1990",
                DOJ = "2/2/2016",
                City = "Pune"
            });

            empList.Add(new Employee
            {
                EmployeeID = 1005,
                FirstName = "Nazia",
                LastName = "Shaikh",
                Title = "SE",
                DOB = "8/3/1991",
                DOJ = "2/2/2016",
                City = "Mumbai"
            });

            empList.Add(new Employee
            {
                EmployeeID = 1006,
                FirstName = "Amit",
                LastName = "Pathak",
                Title = "Consultant",
                DOB = "7/11/1989",
                DOJ = "8/8/2014",
                City = "Chennai"
            });

            empList.Add(new Employee
            {
                EmployeeID = 1007,
                FirstName = "Vijay",
                LastName = "Natrajan",
                Title = "Consultant",
                DOB = "2/12/1989",
                DOJ = "1/6/2015",
                City = "Mumbai"
            });

            empList.Add(new Employee
            {
                EmployeeID = 1008,
                FirstName = "Rahul",
                LastName = "Dubey",
                Title = "Associate",
                DOB = "11/11/1993",
                DOJ = "6/11/2014",
                City = "Chennai"
            });

            empList.Add(new Employee
            {
                EmployeeID = 1009,
                FirstName = "Suresh",
                LastName = "Mistry",
                Title = "Associate",
                DOB = "12/8/1992",
                DOJ = "3/12/2014",
                City = "Chennai"
            });

            empList.Add(new Employee
            {
                EmployeeID = 1010,
                FirstName = "Sumit",
                LastName = "Shah",
                Title = "Manager",
                DOB ="12/4/1991",
                DOJ = "2/1/2016",
                City = "Pune"
            });

            Console.WriteLine("Employee data added successfully!");
            var A = empList.ToList();
            var B = empList.Where(e => e.City != "Mumbai");
            var C = empList.Where(e => e.Title == "AsstManager");
            var D = empList.Where(e => e.LastName.StartsWith("S"));

            Console.WriteLine("a. Display detail of all the employee");
            //Console.WriteLine("b. Display details of all the employee whose location is not Mumbai"+B);
            //Console.WriteLine("c. Display details of all the employee whose title is AsstManager"+C);
            //Console.WriteLine("d. Display details of all the employee whose Last Name start with S"+D);
            //Console.WriteLine("a. Display detail of all the employees:");
            foreach (var emp in A)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.Title} {emp.City}");
            }

            Console.WriteLine("\nb. Employees whose location is NOT Mumbai:");
            foreach (var emp in B)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.Title} {emp.City}");
            }

            Console.WriteLine("\nc. Employees whose title is AsstManager:");
            foreach (var emp in C)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.Title} {emp.City}");
            }

            Console.WriteLine("\nd. Employees whose Last Name starts with S:");
            foreach (var emp in D)
            {
                Console.WriteLine($"{emp.EmployeeID} {emp.FirstName} {emp.LastName} {emp.Title} {emp.City}");
            }

        }
    }
}
