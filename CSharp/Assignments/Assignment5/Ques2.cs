using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class InvalidMarkException : Exception
    {
        public InvalidMarkException(string msg):base(msg) { }
    }
    public class Scholarship
    {
        public double merit(int marks,double fees)
        {
            /*If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
            If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
            If the given mark is >90, then calculate scholarship amount as 50% of the fees.*/
            if(marks >=70&&marks<=80)
            {
                return fees * 0.20;
            }
            else if(marks > 80 && marks <= 90)
            {
                return fees * 0.30;
            }
            else if (marks > 90)
            {
                return fees * 0.50;
            }
            else
            {
                throw new InvalidMarkException("Mark did not qualify for scholarship");
            }
        }
    }
    internal class Ques2
    {
        public static void Qualify()
        {
            try
            {
                Scholarship s = new Scholarship();

                Console.WriteLine("Enter Marks:");
                int marks = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Fees:");
                double fees = double.Parse(Console.ReadLine());

                double amount = s.merit(marks, fees);
                Console.WriteLine($"Scholarship Amount: {amount}");
            }
            catch (InvalidMarkException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format!");
            }
        }
    }
}
