using Model_Data.Dao;
using Model_Data.Framework;
using QLCuaHangNoiThat.Common;
using QLCuaHangNoiThat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCuaHangNoiThat.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Ten dang nhap da ton tai");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email da ton tai");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.PassWord = model.Password;
                    user.Name = model.Name;
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.CreatedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    
                    long id = dao.Insert(user);
                    if (id > 0)
                    {
                        ViewBag.Success = "Dang Ki Thanh Cong";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Dang ki khong thanh cong");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.PassWord);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);

                    var userSession = new UserLogin();

                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tai khoan khong ton tai");
                }

                else if (result == -1)
                {
                    ModelState.AddModelError("", "Mat khau khong dung");
                }
                else
                {
                    ModelState.AddModelError("", "Dang nhap khong dung");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

    }
}