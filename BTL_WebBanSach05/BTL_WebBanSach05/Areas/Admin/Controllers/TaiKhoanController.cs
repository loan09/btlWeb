using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        public ActionResult DangKyAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKyAdmin(TAIKHOANADMIN tk)
        {
            if (ModelState.IsValid)
            {
                db.TAIKHOANADMINs.Add(tk);
                //luu vao csdl
                db.SaveChanges();
            }
            ViewBag.dangky = "Đăng ký thành công !!!";
            return View("DangNhapAdmin");
        }

        [HttpGet]
        public ActionResult DangNhapAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapAdmin(FormCollection f)
        {
            string phoneUser = f["name"].ToString();
            string passWord = f["password"].ToString();

            List<TAIKHOANADMIN> phone = db.TAIKHOANADMINs.Where(n => n.SDT_ADMIN.Contains(phoneUser)).ToList();
            List<TAIKHOANADMIN> pass = db.TAIKHOANADMINs.Where(n => n.MATKHAU.Contains(passWord)).ToList();

            if (phone.Count == 0 || pass.Count == 0)
            {
                ViewBag.ThongBao = "Số điện thoại hoặc mật khẩu sai!";
                return View("DangNhapAdmin");
            }
            else
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                return View("DangKyAdmin");
            }
        }
    }
}