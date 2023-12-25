using QLCuaHangNoiThat.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model_Data.Dao;
using QLCuaHangNoiThat.Common;

namespace QLCuaHangNoiThat.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.PassWord,true);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);

                    var userSession = new UserLogin();

                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.GroupID = user.GroupID;
                    var listCredentals = dao.GetListCredential(model.UserName);

                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentals);

                    Session.Add(CommonConstants.USER_SESSION, userSession);

                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tai khoan khong ton tai");
                }

                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mat khau khong dung");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Tai khoan cua ban khong co quyen dang nhap");
                }
                else
                {
                    ModelState.AddModelError("", "Dang nhap khong dung");
                }
            }
            return View("Index");

        }
    }
}