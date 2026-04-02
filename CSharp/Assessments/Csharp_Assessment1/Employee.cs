using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Assessment1
{
    public class Employee
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Department {get;set;}
        public double Salary {get;set;}
    }
    public static class EmployeeManagement
    {
        public static void ems()
        {
            List<Employee> employees= new List<Employee>();
            int n;
            do
            {
                Console.WriteLine("1.Add New Employee");
                Console.WriteLine("2.View All Employees");
                Console.WriteLine("3.Search Employee by ID");
                Console.WriteLine("4.Update Employee Details");
                Console.WriteLine("5.Delete Employee");
                Console.WriteLine("6.Exit");
                Console.Write("Enter your choice: ");
                n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Employee emp = new Employee();
                        Console.Write("Enter ID:");
                        emp.Id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name:");
                        emp.Name = Console.ReadLine();
                        Console.Write("Enter Department:");
                        emp.Department = Console.ReadLine();
                        Console.Write("Enter Salary:");
                        emp.Salary = double.Parse(Console.ReadLine());
                        employees.Add(emp);
                        Console.WriteLine("Employee detail added");
                        break;

                    case 2:
                        if (employees.Count == 0)
                            Console.WriteLine("No employees found");
                        else
                        {
                            Console.WriteLine("Employee details:");
                            foreach (var e in employees)
                            {
                                Console.WriteLine($"ID:{e.Id}\nName:{e.Name}\nDept:{e.Department}\nSalary:{e.Salary}\n------------");
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Enter EmpID to search:");
                        int searchid = int.Parse(Console.ReadLine());
                        var search = employees.FirstOrDefault(e => e.Id == searchid);

                        if (search!=null)
                            Console.WriteLine($"ID: {search.Id}\nName:{search.Name}\nDept:{search.Department}\nSalary:{search.Salary}\n---------");
                        else
                            Console.WriteLine("Employee not found");
                        break;

                    case 4:
                        Console.Write("Enter Employee ID to update:");
                        int updateid = Convert.ToInt32(Console.ReadLine());
                        var update = employees.FirstOrDefault(e => e.Id == updateid);

                        if (update != null)
                        {
                            Console.Write("Enter Name to be updated:");
                            update.Name = Console.ReadLine();
                            Console.Write("Enter Department to be updated:");
                            update.Department = Console.ReadLine();
                            Console.Write("Enter Salary to be updated:");
                            update.Salary = double.Parse(Console.ReadLine());
                            Console.WriteLine("Employee detail updated");
                        }
                        else
                            Console.WriteLine("Employee not found");
                        break;

                    case 5:
                        Console.Write("Enter EmpID to delete:");
                        int delid = int.Parse(Console.ReadLine());
                        var delemp=employees.FirstOrDefault(e => e.Id == delid);

                        if (delemp!=null)
                        {
                            employees.Remove(delemp);
                            Console.WriteLine("Employee detail deleted");
                        }
                        else
                            Console.WriteLine("Employee not found");
                        break;

                    case 6:
                        Console.WriteLine("Exited");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (n!= 6);
        }
    }

    }
