using Model_Data.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCuaHangNoiThat.Areas.Admin.Controllers
{
    public class StaticalController : BaseController
    {
        // GET: Admin/Statical
        BanNoiThatDbContext1 db = new BanNoiThatDbContext1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoiNhuan()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetStatical(string fromDate, string toDate)
        {
            var query = from o in db.Order
                        join od in db.OrderDetail
                        on o.ID equals od.OrderID
                        join p in db.Product
                        on od.ProductID equals p.ID
                        select new
                        {
                            CreateDate = o.CreateDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                            OrginPrice = p.OriginalPrice
                        };
            if(!string.IsNullOrEmpty(fromDate))
            {
                DateTime startDate = DateTime.ParseExact(fromDate, "DD/MM/yyyy", null);
                query = query.Where(x => x.CreateDate >= startDate);
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(fromDate, "DD/MM/yyyy", null);
                query = query.Where(x => x.CreateDate < endDate);
            }

            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreateDate)).Select(x => new
            {
                Date = x.Key.Value,
                TotalBuy = x.Sum(y => y.Quantity * y.OrginPrice),
                TotalSell = x.Sum(y => y.Quantity * y.Price),
            }).Select(x => new {
                Date = x.Date ,
                DoanhThu = x.TotalSell,
                LoiNhuan =x.TotalSell - x.TotalBuy
            });
            return Json(new {Date = result},JsonRequestBehavior.AllowGet);
        }
    }
}