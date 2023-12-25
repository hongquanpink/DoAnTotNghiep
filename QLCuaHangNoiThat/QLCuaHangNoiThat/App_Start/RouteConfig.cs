using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLCuaHangNoiThat
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{id}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: " Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: " PayMen",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "PayMen", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: " PayMen Success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: " Register",
                url: "dang-ki",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: "Gioithieu",
                url: "gioi-thieu",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: "Tintuc",
                url: "tin-tuc",
                defaults: new { controller = "Home", action = "News", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: "Sanpham",
                url: "san-pham",
                defaults: new { controller = "Home", action = "SanPham", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );

            routes.MapRoute(
                name: "Trangchu",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QLCuaHangNoiThat.Controllers" }
            );
        }
    }
}
