using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CTKhachHang()
        {
            return View();
        }
        public ActionResult CTHoaDon_KH()
        {
            return View();
        }
    }
}