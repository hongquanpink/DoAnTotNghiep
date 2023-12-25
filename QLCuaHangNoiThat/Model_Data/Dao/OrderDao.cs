using Model_Data.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Data.Dao
{
    public class OrderDao
    {
        BanNoiThatDbContext1 db = null;
        public OrderDao()
        {
            db = new BanNoiThatDbContext1();
        }

        public long Insert (Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
            return order.ID;
        }

        public IEnumerable<Order> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = db.Order;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString) || x.ShipName.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public Order ViewDetail(long id)
        {
            return db.Order.Find(id);

        }






    }
}
