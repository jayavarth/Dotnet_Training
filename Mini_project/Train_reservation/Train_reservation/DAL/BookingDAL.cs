using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_reservation.DAL;
using Train_reservation.Models;

namespace Train_reservation.DAL
{
    public class BookingDAL
    {
        DbHelper db = new DbHelper();

        public void BookTicket(Booking b)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_BookTicket", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookDate", b.BookDate);
                cmd.Parameters.AddWithValue("@TravelDate", b.TravelDate);
                cmd.Parameters.AddWithValue("@TrainNo", b.TrainNo);
                cmd.Parameters.AddWithValue("@TravelClass", b.TravelClass);
                cmd.Parameters.AddWithValue("@Passengers", b.Passengers);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetBookings()
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_GetBookings", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetLastBooking()
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_GetLastBooking", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}