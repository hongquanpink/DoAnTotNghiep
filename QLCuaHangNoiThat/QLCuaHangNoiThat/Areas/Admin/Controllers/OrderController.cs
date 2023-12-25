using Model_Data.Dao;
using Model_Data.Framework;
using QLCuaHangNoiThat.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCuaHangNoiThat.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        private BanNoiThatDbContext1 db = new BanNoiThatDbContext1();
        //GET: Admin/Order
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new OrderDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var dao = new OrderDao().ViewDetail(id);
            return View(dao);
        }

        public ActionResult Partial_SanPham(long id)
        {
            var item = db.OrderDetail.Where(x => x.OrderID == id);
            return PartialView(item);

        }
    }

}




