using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_reservation.DAL;
using Train_reservation.Models;

namespace Train_reservation.BAL
{
    public class CancellationBAL
    {
        CancellationDAL dal = new CancellationDAL();

        public void Cancel(Cancellation c)
        {
            if (c.NoTickets <= 0)
                throw new Exception("Invalid tickets");

            dal.Cancel(c);
        }

        public DataTable GetCancellations(int id)
        {
            return dal.GetCancellations(id);
        }

        public DataTable GetCancellations()
        {
            return dal.GetCancellations();
        }
    }
}
