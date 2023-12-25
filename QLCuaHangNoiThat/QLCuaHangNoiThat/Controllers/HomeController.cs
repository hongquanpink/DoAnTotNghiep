using Model_Data.Dao;
using QLCuaHangNoiThat.Common;
using QLCuaHangNoiThat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCuaHangNoiThat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(7);
            ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(7);
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);

            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Welcome()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            

            return PartialView(list);
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }
        public ActionResult SanPham()
        {
            var productDao = new ProductDao();
            ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(7);
            return View();
        }

    }
}