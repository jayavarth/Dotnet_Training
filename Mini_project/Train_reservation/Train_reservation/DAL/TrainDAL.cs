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
    public class TrainDAL
    {
        DbHelper db = new DbHelper();
        public void AddTrain(Train t)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_AddTrain", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TrainNo", t.TrainNo);
                cmd.Parameters.AddWithValue("@TrainName", t.TrainName);
                cmd.Parameters.AddWithValue("@Source", t.SourceStation);
                cmd.Parameters.AddWithValue("@Destination", t.DestinationStation);
                cmd.Parameters.AddWithValue("@Seats2AC", t.Seats_2AC);
                cmd.Parameters.AddWithValue("@Seats3AC", t.Seats_3AC);
                cmd.Parameters.AddWithValue("@SeatsSleeper", t.Seats_Sleeper);
                cmd.Parameters.AddWithValue("@Charges2AC", t.Charges_2AC);
                cmd.Parameters.AddWithValue("@Charges3AC", t.Charges_3AC);
                cmd.Parameters.AddWithValue("@ChargesSleeper", t.Charges_Sleeper);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetTrains()
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_GetTrains", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable SearchTrains(string from, string to)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_SearchTrains", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Source", from);
                cmd.Parameters.AddWithValue("@Destination", to);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void EditTrain(Train t)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateTrain", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TrainNo", t.TrainNo);
                cmd.Parameters.AddWithValue("@TrainName", t.TrainName);
                cmd.Parameters.AddWithValue("@Source", t.SourceStation);
                cmd.Parameters.AddWithValue("@Destination", t.DestinationStation);

                cmd.Parameters.AddWithValue("@Seats2AC", t.Seats_2AC);
                cmd.Parameters.AddWithValue("@Seats3AC", t.Seats_3AC);
                cmd.Parameters.AddWithValue("@SeatsSleeper", t.Seats_Sleeper);

                cmd.Parameters.AddWithValue("@Charges2AC", t.Charges_2AC);
                cmd.Parameters.AddWithValue("@Charges3AC", t.Charges_3AC);
                cmd.Parameters.AddWithValue("@ChargesSleeper", t.Charges_Sleeper);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SoftDeleteTrain(int trainNo)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Train SET IsDeleted = 1 WHERE TrainNo = @TrainNo", con);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool TrainExists(int trainNo)
        {
            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Train WHERE TrainNo = @TrainNo AND IsDeleted = 0",
                con);

            cmd.Parameters.AddWithValue("@TrainNo", trainNo);

            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            return count > 0;
        }
    }
}