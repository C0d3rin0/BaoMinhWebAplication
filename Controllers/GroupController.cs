using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaoMinhWebApplication.Models;

namespace BaoMinhWebApplication.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Create()
        {
            if (!Session.isAdminSession())
                return RedirectToAction("Index", "Home", null);

            return View();
        }

        public ActionResult Search()
        {
            if (!Session.isAdminSession())
                return RedirectToAction("Index", "Home", null);

            return View();
        }

        [HttpPost]
        public void Undelete(int id)
        {
            if (!Session.isAdminSession())
                return;

            Entities entities = new Entities();
            var group = entities.Nhoms.Where(g => g.id == id).First();
            group.TrangThai = true;
            entities.SaveChanges();
        }
    }
}