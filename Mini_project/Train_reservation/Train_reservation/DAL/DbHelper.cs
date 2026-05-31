using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_reservation.DAL
{
    public class DbHelper
    {
        private string connectionString =
            "Data Source=ICS-LT-1C73YS3;Initial Catalog=TrainReservationDB;Integrated Security=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
