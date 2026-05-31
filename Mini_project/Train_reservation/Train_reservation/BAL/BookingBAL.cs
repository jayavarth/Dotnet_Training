using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_reservation.DAL;
using Train_reservation.Models;

namespace Train_reservation.BAL
{
    public class BookingBAL
    {
        BookingDAL dal = new BookingDAL();

        public void BookTicket(Booking b)
        {
            if (b.Passengers > 3)
                throw new Exception("Max 3 passengers allowed");

            if (b.TravelDate < b.BookDate)
                throw new Exception("Invalid Travel Date");

            dal.BookTicket(b);
        }

        public DataTable GetBookings(int id)
        {
            return dal.GetBookings(id);
        }

        public DataTable GetBookings()
        {
            return dal.GetBookings();
        }


        public DataTable GetLastBooking()
        {
            return dal.GetLastBooking();
        }
    }
}
