using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_reservation.BAL;
using Train_reservation.Models;

namespace Train_reservation
{
    public class User
    {
        public static void UserMenu()
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
                Console.WriteLine("6. View Cancellations");
                Console.WriteLine("7. Exit");

                Console.Write("\nEnter your choice (1-7): ");
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
                            $"\n2AC Seats     : {row["Seats_2AC"]} | Fare: ${row["Charges_2AC"]}" +
                            $"\n3AC Seats     : {row["Seats_3AC"]} | Fare: ${row["Charges_3AC"]}" +
                            $"\nSleeper Seats : {row["Seats_Sleeper"]} | Fare: ${row["Charges_Sleeper"]}" +
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
                    b.UserId = Session.UserId;

                    b.BookDate = DateTime.Now;

                    Console.Write("Travel Date (yyyy-MM-dd): ");

                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime travelDate))
                    {
                        Console.WriteLine("Invalid date format.");
                        continue;
                    }

                    if (travelDate.Date < DateTime.Today)
                    {
                        Console.WriteLine("Travel date cannot be in the past.");
                        continue;
                    }

                    b.TravelDate = travelDate;

                    Console.Write("Train No: ");
                    b.TrainNo = int.Parse(Console.ReadLine());

                    if (!trainBal.TrainExists(b.TrainNo))
                    {
                        Console.WriteLine("Train number does not exist.");
                        continue;
                    }

                    Console.Write("Class (2AC/3AC/Sleeper): ");
                    b.TravelClass = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(b.TravelClass))
                    {
                        Console.WriteLine("Travel class is required.");
                        continue;
                    }

                    if (b.TravelClass != "2AC" &&
                        b.TravelClass != "3AC" &&
                        b.TravelClass != "Sleeper")
                    {
                        Console.WriteLine("Invalid travel class.");
                        continue;
                    }

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
                    var dt = bookingBal.GetBookings(Session.UserId);

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

                    c.UserId = Session.UserId;

                    cancelBal.Cancel(c);

                    Console.WriteLine("Cancelled Successfully");
                }
                else if (ch == 6)
                {
                    var dt = cancelBal.GetCancellations(Session.UserId);

                    if (dt.Rows.Count > 0)
                    {
                        Console.WriteLine("\n--- MY CANCELLATIONS ---");

                        foreach (System.Data.DataRow row in dt.Rows)
                        {
                            Console.WriteLine(
                                $"\nCancellation ID : {row["CId"]}" +
                                $"\nBooking ID      : {row["BookingId"]}" +
                                $"\nTickets         : {row["NoTickets"]}" +
                                $"\nRefund Amount   : {row["RefundAmount"]}" +
                                $"\nDate            : {row["CancelDate"]}" +
                                $"\n----------------------------"
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
    }
}
