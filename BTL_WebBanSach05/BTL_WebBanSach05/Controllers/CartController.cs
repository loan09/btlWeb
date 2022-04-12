using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Controllers
{
    public class CartController : Controller
    {
        WebBanSach9Entities db = new WebBanSach9Entities();

        #region Cart
        public List<Cart> getCart()
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;

            if(lstCart == null)
            {
                lstCart = new List<Cart>();
                Session["Cart"] = lstCart;
            }

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();

            return lstCart;
        }

        public ActionResult addCart(int MASACH , string url ,int? SoLuong, FormCollection f)
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.MASACH == MASACH);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Cart> lstCart = getCart();
            Cart book = lstCart.Find(n => n.MASACH == MASACH);
            if(book == null)
            {
                book = new Cart(MASACH);
                if (SoLuong.HasValue)
                {
                    book.SOLUONG = SoLuong.Value;
                }
                else {
                    book.SOLUONG = int.Parse(f["txtSoLuong"].ToString());
                }
                lstCart.Add(book);
                return Redirect(url);
            }
            else
            {
                if (SoLuong.HasValue)
                {
                    book.SOLUONG += SoLuong.Value;
                }
                else
                    book.SOLUONG+= int.Parse(f["txtSoLuong"].ToString()); 
                return Redirect(url);
            }
        }
        [HttpPost]
        public ActionResult updateCart(int MASACH , FormCollection f)
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.MASACH == MASACH);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<Cart> lstCart = getCart();
            Cart book = lstCart.SingleOrDefault(n => n.MASACH == MASACH);

            if(book != null)
            {
                book.SOLUONG =  int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("Cart");
        }
        public ActionResult DeleteCar(int MASACH)
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.MASACH == MASACH);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Cart> lstCart = getCart();
            Cart book = lstCart.SingleOrDefault(n => n.MASACH == MASACH);
            if (book != null)
            {
                lstCart.RemoveAll(n => n.MASACH == MASACH);

            }
            if (lstCart.Count == 0)
            {
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cart> lstCart = getCart();

            if (Session["KhachHang"] != null)
            {
                ViewBag.kh = (TK_KHACHHANG)Session["KhachHang"];
            }

            return View(lstCart);
        }
        private int TongSoLuong()
        {
            int TongSoLuong = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                TongSoLuong = lstCart.Sum(n => n.SOLUONG);
            }
            return TongSoLuong;
        }

        private int TongTien()
        {
            int TongTien = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                TongTien= lstCart.Sum(n => n.THANHTIEN);
            }
            return TongTien;

        }

        public ActionResult CartPartial()
        {
            if(TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        #endregion

        #region Payment
        [HttpPost]
        public ActionResult Payment()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }

            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            HOADONBAN hdb = new HOADONBAN();

            List<Cart> cart = getCart();
            TK_KHACHHANG kh = (TK_KHACHHANG)(Session["TaiKhoan"]);

            hdb.ID_KHACHHANG = kh.ID_KHACHHANG;
            hdb.NGAYLAPHDBAN = DateTime.Now;
            db.HOADONBANs.Add(hdb);
            db.SaveChanges();
            foreach(var item in cart)
            {
                CT_HDBAN ctHDB = new CT_HDBAN();
                ctHDB.MAHDBAN = hdb.MAHDBAN;
                ctHDB.MASACH = item.MASACH;
                ctHDB.SLBAN = item.SOLUONG;
                db.CT_HDBAN.Add(ctHDB);
               
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        #endregion

    }
}