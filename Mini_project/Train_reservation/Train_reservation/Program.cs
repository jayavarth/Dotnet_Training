using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_reservation.BAL;
using Train_reservation.DAL;
using Train_reservation.Models;

namespace Train_reservation
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                UserDAL userDal = new UserDAL();
                UserBAL userBal = new UserBAL();

                Console.Clear();
                Console.WriteLine("===== TRAIN RESERVATION SYSTEM =====");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");

                Console.Write("Enter Choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 2)
                {
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();

                    userBal.Register(username, password);

                    Console.WriteLine("Registration Successful.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                if (choice == 3)
                    break;

                Console.WriteLine("\nLOGIN");
                Console.Write("Username: ");
                string usernameInput = Console.ReadLine();

                Console.Write("Password: ");
                string passwordInput = Console.ReadLine();

                string role = userDal.Login(usernameInput, passwordInput);

                if (role == null)
                {
                    Console.WriteLine("Invalid Login");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("Logged in as: " + role);

                if (role == "Admin")
                {
                    Admin.AdminMenu();
                }
                else
                {
                    User.UserMenu();
                }
            }
        }
    }
}
