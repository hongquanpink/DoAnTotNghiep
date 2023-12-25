using Model_Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Data.Dao
{
    public class OrderDetailDao
    {
        BanNoiThatDbContext1 db = null;
        public OrderDetailDao()
        {
            db = new BanNoiThatDbContext1();
        }

        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetail.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        








    }
}
