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
    public class TrainBAL
    {
        TrainDAL dal = new TrainDAL();

        public void AddTrain(Train t)
        {
            if (t.TrainNo <= 0)
                throw new Exception("Invalid Train No");

            dal.AddTrain(t);
        }

        public DataTable GetTrains()
        {
            return dal.GetTrains();
        }

        public DataTable SearchTrains(string from, string to)
        {
            return dal.SearchTrains(from, to);
        }

        public void EditTrain(Train t)
        {
            dal.EditTrain(t);
        }

        public void SoftDeleteTrain(int trainNo)
        {
            dal.SoftDeleteTrain(trainNo);
        }

        public bool TrainExists(int trainNo)
        {
            return dal.TrainExists(trainNo);
        }
    }
}
