using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_reservation.DAL;

namespace Train_reservation.BAL
{
    internal class UserBAL
    {
        UserDAL dal = new UserDAL();
        public void Register(string username, string password)
        {
            dal.Register(username, password);
        }
    }
}
