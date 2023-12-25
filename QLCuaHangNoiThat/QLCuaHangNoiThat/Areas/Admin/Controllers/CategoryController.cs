using Model_Data.Dao;
using Model_Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCuaHangNoiThat.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(string searchString, int page = 1, int pageSize = 2)
        {
            var dao = new CategoryDao();
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
        public ActionResult Create(ProductCategory cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                cate.CreatedDate = DateTime.Now;
                cate.ModifiedDate = DateTime.Now;
                
                long id = dao.Insert(cate);
                if (id > 0)
                {
                    TempData["success"] = "Them danh muc thanh cong";
                    return RedirectToAction("Create", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Them san pham khong thanh cong");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edits(long id)
        {
            var cate = new CategoryDao().ViewDetail(id);
            return View(cate);
        }

        [HttpPost]
        public ActionResult Edits(ProductCategory cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(cate);
                if (result)
                {
                    return RedirectToAction("Index", "Category");
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
            new CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}