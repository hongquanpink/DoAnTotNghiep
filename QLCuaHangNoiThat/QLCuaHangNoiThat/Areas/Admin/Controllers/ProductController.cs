using Model_Data.Dao;
using Model_Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCuaHangNoiThat.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                var dao = new ProductDao();
                product.CreatedDate = DateTime.Now;
                product.ModifiedDate=DateTime.Now;
                product.TopHot=DateTime.Now;
                long id = dao.Insert(product);
                if (id > 0)
                {
                    TempData["success"] = "Them product thanh cong";
                    return RedirectToAction("Create","Product");
                }
                else
                {
                    ModelState.AddModelError("", "Them san pham khong thanh cong");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Sua san pham khong thanh cong");
                }
            }
            return View("Index");
        }

        public ActionResult Delete(long id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}