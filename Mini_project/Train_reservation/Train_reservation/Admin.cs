using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_reservation.BAL;
using Train_reservation.Models;

namespace Train_reservation
{
    public class Admin
    {
        public static void AdminMenu()
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
    }
}
