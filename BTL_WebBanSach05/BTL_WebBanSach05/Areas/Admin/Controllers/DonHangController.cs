using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CTDonHang()
        {
            return View();
        }
    }
}