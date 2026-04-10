using System;
using Travel;

namespace Assignment7
{

    class Ques4
    {
        const double TotalFare = 500;  

        static void Main(string[] args)
        {
            string name;
            int age;
            Console.Write("Enter Name:");
            name = Console.ReadLine();

            Console.Write("Enter Age:");
            age = Convert.ToInt32(Console.ReadLine());

            TravelConcession obj = new TravelConcession();

            string result = obj.CalculateConcession(age, TotalFare);

            Console.WriteLine("Passenger Name:" + name);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}