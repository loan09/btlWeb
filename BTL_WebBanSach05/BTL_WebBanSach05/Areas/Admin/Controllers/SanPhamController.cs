using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addProduct()
        {
            return View();
        }

        public ActionResult CTSanPham()
        {
            return View();
        }
    }
}