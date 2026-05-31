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
            UserDAL userDal = new UserDAL();
            UserBAL userBal = new UserBAL();

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
                return;
            }

            if (choice == 3)
            {
                return;
            }

            Console.WriteLine("\nLOGIN");
            Console.Write("Username: ");
            string u = Console.ReadLine();

            Console.Write("Password: ");
            string p = Console.ReadLine();

            string role = userDal.Login(u, p);

            if (role == null)
            {
                Console.WriteLine("Invalid Login");
                return;
            }

            Console.WriteLine("Logged in as: " + role);

            if (role == "Admin")
                AdminMenu();
            else
                UserMenu();
        }

        static void AdminMenu()
        {
            TrainBAL train = new TrainBAL();
            BookingBAL booking = new BookingBAL(); 
            CancellationBAL cancelBal = new CancellationBAL();

            while (true)
            {
                Console.WriteLine("\n--- ADMIN MENU ---");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Edit Train");
                Console.WriteLine("3. Delete Train");
                Console.WriteLine("4. View Bookings");
                Console.WriteLine("5. View All Trains");
                Console.WriteLine("6. View Cancellations");
                Console.WriteLine("7. Exit");

                Console.Write("\nEnter your choice (1-7): ");
                int ch = int.Parse(Console.ReadLine());

                if (ch == 1)
                {
                    Train t = new Train();

                    Console.Write("Train No: ");
                    t.TrainNo = int.Parse(Console.ReadLine());

                    Console.Write("Name: ");
                    t.TrainName = Console.ReadLine();

                    Console.Write("From: ");
                    t.SourceStation = Console.ReadLine();

                    Console.Write("To: ");
                    t.DestinationStation = Console.ReadLine();

                    Console.Write("2AC Seats: ");
                    t.Seats_2AC = int.Parse(Console.ReadLine());

                    Console.Write("3AC Seats: ");
                    t.Seats_3AC = int.Parse(Console.ReadLine());

                    Console.Write("Sleeper Seats: ");
                    t.Seats_Sleeper = int.Parse(Console.ReadLine());

                    Console.Write("2AC Charge: ");
                    t.Charges_2AC = decimal.Parse(Console.ReadLine());

                    Console.Write("3AC Charge: ");
                    t.Charges_3AC = decimal.Parse(Console.ReadLine());

                    Console.Write("Sleeper Charge: ");
                    t.Charges_Sleeper = decimal.Parse(Console.ReadLine());

                    train.AddTrain(t);

                    Console.WriteLine("Train Added Successfully");
                }
                else if (ch == 2)
                {
                    Train t = new Train();

                    Console.Write("Enter Train No to Edit: ");
                    t.TrainNo = int.Parse(Console.ReadLine());

                    Console.Write("New Name: ");
                    t.TrainName = Console.ReadLine();

                    Console.Write("New From: ");
                    t.SourceStation = Console.ReadLine();

                    Console.Write("New To: ");
                    t.DestinationStation = Console.ReadLine();

                    Console.Write("2AC Seats: ");
                    t.Seats_2AC = int.Parse(Console.ReadLine());

                    Console.Write("3AC Seats: ");
                    t.Seats_3AC = int.Parse(Console.ReadLine());

                    Console.Write("Sleeper Seats: ");
                    t.Seats_Sleeper = int.Parse(Console.ReadLine());

                    Console.Write("2AC Charge: ");
                    t.Charges_2AC = decimal.Parse(Console.ReadLine());

                    Console.Write("3AC Charge: ");
                    t.Charges_3AC = decimal.Parse(Console.ReadLine());

                    Console.Write("Sleeper Charge: ");
                    t.Charges_Sleeper = decimal.Parse(Console.ReadLine());

                    train.EditTrain(t);

                    Console.WriteLine("Train Updated Successfully");
                }
                else if (ch == 3)
                {
                    Console.Write("Enter Train No to Delete: ");
                    int trainNo = int.Parse(Console.ReadLine());

                    train.DeleteTrain(trainNo);

                    Console.WriteLine("Train Deleted");
                }
                else if (ch == 4)
                {
                    var dt = booking.GetBookings();

                    Console.WriteLine("\n--- ALL BOOKINGS ---");

                    if (dt.Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            Console.WriteLine(
                                $"BookingID: {row["BookingId"]} | " +
                                $"TrainNo: {row["TrainNo"]} | " +
                                $"Class: {row["TravelClass"]} | " +
                                $"Passengers: {row["Passengers"]} | " +
                                $"Amount: {row["Amount"]} | " +
                                $"Date: {row["TravelDate"]}"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("No bookings found.");
                    }
                }
                else if (ch == 5)
                {
                    var dt = train.GetTrains();

                    Console.WriteLine("\n--- ALL TRAIN DETAILS ---\n");

                    if (dt.Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            Console.WriteLine(
                                $"TrainNo: {row["TrainNo"]} | " +
                                $"Name: {row["TrainName"]} | " +
                                $"From: {row["SourceStation"]} | " +
                                $"To: {row["DestinationStation"]} | " +
                                $"2AC: {row["Seats_2AC"]} | " +
                                $"3AC: {row["Seats_3AC"]} | " +
                                $"Sleeper: {row["Seats_Sleeper"]}"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("No trains available.");
                    }
                }
                else if (ch == 6)
                {
                    var dt = cancelBal.GetCancellations();

                    Console.WriteLine("\n--- CANCELLATION DETAILS ---");

                    if (dt.Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            Console.WriteLine(
                                $"Cancellation ID: {row["CId"]} | " +
                                $"Booking ID: {row["BookingId"]} | " +
                                $"Tickets Cancelled: {row["NoTickets"]} | " +
                                $"Refund Amount: {row["RefundAmount"]} | " +
                                $"Cancel Date: {Convert.ToDateTime(row["CancelDate"]).ToShortDateString()}"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("No cancellations found.");
                    }
                }

                else break;
            }
        }

        static void UserMenu()
        {
            TrainBAL trainBal = new TrainBAL();
            BookingBAL bookingBal = new BookingBAL();
            CancellationBAL cancelBal = new CancellationBAL();

            while (true)
            {
                Console.WriteLine("\n--- USER MENU ---");
                Console.WriteLine("1. View All Trains");
                Console.WriteLine("2. Search Trains");
                Console.WriteLine("3. Book Ticket");
                Console.WriteLine("4. View My Bookings");
                Console.WriteLine("5. Cancel Ticket");
                Console.WriteLine("6. Exit");

                Console.Write("\nEnter your choice (1-6): ");
                int ch = int.Parse(Console.ReadLine());

                if (ch == 1)
                {
                    var dt = trainBal.GetTrains();
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        Console.WriteLine(
                        $"\nTrain No      : {row["TrainNo"]}" +
                        $"\nTrain Name    : {row["TrainName"]}" +
                        $"\nRoute         : {row["SourceStation"]} -> {row["DestinationStation"]}" +
                        $"\n2AC Seats     : {row["Seats_2AC"]} | Fare: ${row["Charges_2AC"]}" +
                        $"\n3AC Seats     : {row["Seats_3AC"]} | Fare: ${row["Charges_3AC"]}" +
                        $"\nSleeper Seats : {row["Seats_Sleeper"]} | Fare: ${row["Charges_Sleeper"]}" +
                        $"\n--------------------------------------------------"
    );
                    }
                }

                else if (ch == 2)
                {
                    Console.Write("From: ");
                    string from = Console.ReadLine();

                    Console.Write("To: ");
                    string to = Console.ReadLine();

                    var dt = trainBal.SearchTrains(from, to);

                    if (dt.Rows.Count > 0)
                    {
                        Console.WriteLine("\nAvailable Trains:\n");

                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            Console.WriteLine(
                            $"\nTrain No      : {row["TrainNo"]}" +
                            $"\nTrain Name    : {row["TrainName"]}" +
                            $"\nRoute         : {row["SourceStation"]} -> {row["DestinationStation"]}" +
                            $"\n2AC Seats     : {row["Seats_2AC"]} | Fare: ₹{row["Charges_2AC"]}" +
                            $"\n3AC Seats     : {row["Seats_3AC"]} | Fare: ₹{row["Charges_3AC"]}" +
                            $"\nSleeper Seats : {row["Seats_Sleeper"]} | Fare: ₹{row["Charges_Sleeper"]}" +
                            $"\n--------------------------------------------------"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo trains found for the selected route.");
                    }
                }

                else if (ch == 3)
                {
                    Booking b = new Booking();

                    b.BookDate = DateTime.Now;

                    Console.Write("Travel Date: ");
                    b.TravelDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("Train No: ");
                    b.TrainNo = int.Parse(Console.ReadLine());

                    Console.Write("Class: ");
                    b.TravelClass = Console.ReadLine();

                    Console.Write("Passengers: ");
                    b.Passengers = int.Parse(Console.ReadLine());

                    bookingBal.BookTicket(b);

                    Console.WriteLine("\nBooking Successful");

                    var dt = bookingBal.GetLastBooking();
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        Console.WriteLine("\n--- BOOKING RECEIPT ---");
                        Console.WriteLine("Booking ID: " + row["BookingId"]);
                        Console.WriteLine("Train No: " + row["TrainNo"]);
                        Console.WriteLine("Class: " + row["TravelClass"]);
                        Console.WriteLine("Passengers: " + row["Passengers"]);
                        Console.WriteLine("Amount: " + row["Amount"]);
                    }
                }

                else if (ch == 4)
                {
                    var dt = bookingBal.GetBookings();

                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        Console.WriteLine(
                        $"Booking ID: {row["BookingId"]} | " +
                        $"Train: {row["TrainNo"]} | " +
                        $"Class: {row["TravelClass"]} | " +
                        $"Passengers: {row["Passengers"]} | " +
                        $"Amount: {row["Amount"]} | " +
                        $"Status: {row["Status"]}"
                        );
                    }
                }

                else if (ch == 5)
                {
                    Cancellation c = new Cancellation();

                    Console.Write("Booking ID: ");
                    c.BookingId = int.Parse(Console.ReadLine());

                    Console.Write("Tickets: ");
                    c.NoTickets = int.Parse(Console.ReadLine());

                    cancelBal.Cancel(c);

                    Console.WriteLine(" Cancelled Successfully");
                }

                else break;
            }
        }
    }
}
