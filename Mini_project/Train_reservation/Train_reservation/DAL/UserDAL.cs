using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_reservation.DAL;

namespace Train_reservation.DAL
{
    internal class UserDAL
    {
        DbHelper db = new DbHelper();

        public string Login(string user, string pass)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Role FROM Users WHERE Username=@u AND Password=@p", con);

                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@p", pass);

                con.Open();
                var role = cmd.ExecuteScalar();

                return role?.ToString();
            }
        }

        public void Register(string username, string password)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_RegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}