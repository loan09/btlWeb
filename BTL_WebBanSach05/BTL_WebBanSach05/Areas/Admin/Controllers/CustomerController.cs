using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CTKhachHang(int? id)
        {
            TK_KHACHHANG item = db.TK_KHACHHANG.Where(n => n.ID_KHACHHANG == id).FirstOrDefault();
            ViewBag.ID = item.ID_KHACHHANG;
            ViewBag.Ten = item.HOTENKH;
            ViewBag.SDT = item.SDT_KH;
            ViewBag.DiaChi = item.DIACHI;

            return View();
        }
        public ActionResult CTHoaDon_KH(int? idDH)
        {
            ViewBag.idDH = idDH;
            return View();
        }
    }
}