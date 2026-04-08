using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Assessment2
{
    abstract class Student
    {
        public string Name{get;set;}
        public int StudentId{get;set;}
        public double Grade{get;set;}
        public Student(string name, int id, double grade)
        {
            Name = name;
            StudentId = id;
            Grade = grade;
        }
        public abstract bool Ispassed(double grade);
    }

    class Undergraduate : Student
    {
        public Undergraduate(string name, int id, double grade):base(name, id, grade) { }
        public override bool Ispassed(double grade)
        {
            return grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public Graduate(string name, int id, double grade):base(name, id, grade) { }
        public override bool Ispassed(double grade)
        {
            return grade > 80.0;
        }
    }
    internal class Student_detail
    {
        public static void Main()
        {
            string uname;
            int uid, ugrade;
            Console.WriteLine("Under Graduate details:\nEnter the name:");
            uname=Console.ReadLine();
            Console.WriteLine("Enter the id:");
            uid =int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the grade:");
            ugrade =int.Parse(Console.ReadLine());

            Console.WriteLine("------------------");

            Student u = new Undergraduate(uname, uid, ugrade);
            string gname;
            int gid, ggrade;
            Console.WriteLine("Graduate details:\nEnter the name");
            gname = Console.ReadLine();
            Console.WriteLine("Enter the id:");
            gid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the grade:");
            ggrade = int.Parse(Console.ReadLine());
            Student g = new Graduate(gname, gid, ggrade);

            Console.WriteLine($"Undergraduate Passed: {u.Ispassed(u.Grade)}");
            Console.WriteLine($"Graduate Passed: {g.Ispassed(g.Grade)}");
        }
    }
}
