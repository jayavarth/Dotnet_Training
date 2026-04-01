using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3
{
    internal class Ques2_Student
    {
        internal class Student
        {
            protected int rollNo;
            protected string name, className, branch;
            protected int sem;
            protected int[] marks = new int[5];

            public Student(int rollNo, string name, string className, int sem, string branch)
            {
                this.rollNo = rollNo;
                this.name = name;
                this.className = className;
                this.sem = sem;
                this.branch = branch;
            }

            public void DisplayData()
            {
                Console.WriteLine($"RollNo: {rollNo}, Name: {name}, Class: {className}, Sem: {sem}, Branch: {branch}");
            }
        }

        internal class Result : Student
        {
            public Result(int rollNo, string name, string className, int sem, string branch)
                : base(rollNo, name, className, sem, branch)
            {
            }

            public void GetMarks()
            {
                Console.WriteLine("Enter marks for 5 subjects:");
                for (int i = 0; i < 5; i++)
                {
                    marks[i] = int.Parse(Console.ReadLine());
                }
            }

            public void DisplayResult()
            {
                int sum = 0;
                bool fail = false;

                for (int i = 0; i < 5; i++)
                {
                    if (marks[i] < 35)
                        fail = true;

                    sum += marks[i];
                }

                double avg = sum / 5.0;

                if (fail || avg < 50)
                    Console.WriteLine("Result: Failed");
                else
                    Console.WriteLine("Result: Passed");

                Console.WriteLine($"Average: {avg}");
            }
        }
        public static void Student_detail()
        {
            Result s = new Result(1, "Alice", "BSc", 3, "CS");

            s.GetMarks();
            s.DisplayData();
            s.DisplayResult();
        }
    }
    
}