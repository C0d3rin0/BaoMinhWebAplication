using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BaoMinhWebApplication.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize] // Chỉ khi đăng nhập mới được vào
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "User", null);

            return View();
        }
    }
}