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
    public class CancellationDAL
    {
        DbHelper db = new DbHelper();

        public void Cancel(Cancellation c)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_CancelTicket", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookingId", c.BookingId);
                cmd.Parameters.AddWithValue("@NoTickets", c.NoTickets);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetCancellations()
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_GetCancellations", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}
