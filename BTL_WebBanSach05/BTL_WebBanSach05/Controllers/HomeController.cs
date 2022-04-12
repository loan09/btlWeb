using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Controllers
{
    public class HomeController : Controller
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult getCategory()
        {
            return PartialView(db.THELOAIs.ToList());
        }
        public PartialViewResult getSpecialCategory()
        {
            return PartialView(db.THELOAIs.ToList());
        }

        public PartialViewResult SpecialBook(int matheloai = 1)
        {   
            return PartialView(db.SACHes.Where(n => n.MATHELOAI == matheloai).OrderBy(n => n.TENSACH).Take(4).ToList());
        }

    }
}