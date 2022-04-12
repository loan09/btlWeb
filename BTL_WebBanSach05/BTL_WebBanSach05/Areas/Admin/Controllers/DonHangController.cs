using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: Admin/DonHang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CTDonHang(int idDhang)
        {
            List<HOADONBAN> hdb = db.HOADONBANs.ToList();
            List<TK_KHACHHANG> khachhang = db.TK_KHACHHANG.ToList();

            HOADONBAN items = (from hd in hdb
                          join kh in khachhang on hd.ID_KHACHHANG equals kh.ID_KHACHHANG
                          where hd.MAHDBAN == idDhang select hd).FirstOrDefault();

            if(items != null)
            {
                ViewBag.ngayban = items.NGAYLAPHDBAN;
                ViewBag.MaKH = items.ID_KHACHHANG;
                ViewBag.TenKH = items.TK_KHACHHANG.HOTENKH;
                ViewBag.SDTKh = items.TK_KHACHHANG.SDT_KH;
                ViewBag.DiaChi = items.TK_KHACHHANG.DIACHI;
            }
            ViewBag.MaDH = idDhang;

            return View();
        }
    }
}