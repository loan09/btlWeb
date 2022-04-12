using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{

    public class SanPhamController : Controller
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addProduct()
        {
            return View();
        }

        public ActionResult CTSanPham(int? id)
        {
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            SACH items = (from sp in sach
                          join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                          join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                          join n in nxb on sp.MANXB equals n.MANXB where sp.MASACH == id select sp).FirstOrDefault();

            if (items != null)
            {
                ViewBag.MaSach = items.MASACH;
                ViewBag.TenSach = items.TENSACH;
                ViewBag.ngonngu = items.NGONNGU;
                ViewBag.TenSanPham = items.TENSACH;
                ViewBag.TacGia = items.TACGIA.TENTACGIA;
                ViewBag.TheLoai = items.THELOAI.TENTHELOAI;
                ViewBag.NXB = items.NXB.TENNXB;
                ViewBag.NguoiDich = items.NGUOIDICH;
                ViewBag.NgonNgu = items.NGONNGU;
                ViewBag.KichThuoc = items.KICHTHUOC;
                ViewBag.gianhap = items.GIANHAP;
                ViewBag.giaban = items.GIABAN;
                ViewBag.sotrang = items.SOTRANG;
                ViewBag.namXB = items.NAMXUATBAN;
                ViewBag.tenanh = items.TENANH;
            }
            return View();
        }

        public ActionResult UpdateSP(int? id)
        {
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            SACH items = (from sp in sach
                          join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                          join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                          join n in nxb on sp.MANXB equals n.MANXB
                          where sp.MASACH == id
                          select sp).FirstOrDefault();

            if (items != null)
            {
                ViewBag.MaSach = items.MASACH;
                ViewBag.TenSach = items.TENSACH;
                ViewBag.ngonngu = items.NGONNGU;
                ViewBag.Trongluong = items.TRONGLUONG;
                ViewBag.TacGia = items.TACGIA.TENTACGIA;
                ViewBag.MaTG = items.TACGIA.MATACGIA;
                ViewBag.TheLoai = items.THELOAI.TENTHELOAI;
                ViewBag.MaTL = items.THELOAI.MATHELOAI;
                ViewBag.NXB = items.NXB.TENNXB;
                ViewBag.MaNXB = items.NXB.MANXB;
                ViewBag.NguoiDich = items.NGUOIDICH;
                ViewBag.NgonNgu = items.NGONNGU;
                ViewBag.KichThuoc = items.KICHTHUOC;
                ViewBag.gianhap = items.GIANHAP;
                ViewBag.giaban = items.GIABAN;
                ViewBag.sotrang = items.SOTRANG;
                ViewBag.namXB = items.NAMXUATBAN;
                ViewBag.tenanh = items.TENANH;
            }
            return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }

    }
}