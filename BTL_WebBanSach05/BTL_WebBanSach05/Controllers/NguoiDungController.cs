using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Controllers
{
    public class NguoiDungController : Controller
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(TK_KHACHHANG tk)
        {
            
            if (ModelState.IsValid)
            {
                db.TK_KHACHHANG.Add(tk);
                //luu vao csdl
                db.SaveChanges();
                
            }
            ViewBag.dangky = "Đăng ký thành công !!!";
            return View();
        }


        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)

        {
            String sTaiKhoan = f.Get("name").ToString();
            String sMatKhau = f.Get("password").ToString();
            TK_KHACHHANG kh = db.TK_KHACHHANG.SingleOrDefault(n => n.SDT_KH == sTaiKhoan && n.MATKHAU_KH == sMatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu ko đúng";
            return View();

        }
        [HttpGet]
        public ActionResult SuaThongTin()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            TK_KHACHHANG kh = (TK_KHACHHANG)Session["TaiKhoan"];
            return View(kh);
        }
        [HttpPost]
        public ActionResult SuaThongTin([Bind(Include = "ID_KHACHHANG , HOTENKH , SDT_KH , DIACHI , MATKHAU_KH")] TK_KHACHHANG kh)
        {
            db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public ActionResult KiemTraDangNhap()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}