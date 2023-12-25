using Model_Data.Dao;
using Model_Data.Framework;
using QLCuaHangNoiThat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QLCuaHangNoiThat.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        private const string UserSession = "UserSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }

        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;

                if (list.Exists(x => x.Product.ID == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //gan vao session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);

                //gan vao session
                Session[CartSession] = list;

            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;

            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;

            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;

            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult PayMen()
        {

                var cart = Session[CartSession];
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;
                }
                return View(list);
            
        }


        [HttpPost]
        public ActionResult PayMen(string shipName, string mobie, string address, string email)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.ShipAddress = address;
            order.ShipMobie = mobie;
            order.ShipName = shipName;
            order.ShipEmail = email;

            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OrderDetailDao();
                foreach (var item in cart)
                {
                    var oderDetail = new OrderDetail();
                    oderDetail.ProductID = item.Product.ID;
                    oderDetail.OrderID = id;
                    oderDetail.Price = item.Product.Price;
                    oderDetail.Quantity = item.Quantity;
                    detailDao.Insert(oderDetail);
                }
                Session[CartSession] = null;

            }
            catch (Exception)
            {
                //ghi log
                return Redirect("/loi-thanh-toan");
            }

            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {

            return View();
        }
    }
}