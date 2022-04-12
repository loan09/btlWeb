using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_WebBanSach05.Models;
using PagedList.Mvc;
using PagedList;

namespace BTL_WebBanSach05.Controllers
{
    public class ProductController : Controller
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: Product
        public ActionResult FilterProduct()
        {
            
            ViewBag.NXB = db.NXBs.ToList();
            return View();
        }
        public PartialViewResult GetCategory()
        {
            ViewBag.Category = db.THELOAIs.ToList();

            return PartialView();
        }

        public PartialViewResult GetNXB()
        {
            ViewBag.NXB = db.NXBs.ToList();
            
            return PartialView();
        }
        public ActionResult DetailProduct(int MASACH = 1)
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.MASACH == MASACH);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }

        public PartialViewResult PreProduc(int MASACH = 1)
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.MASACH == MASACH);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView(sach);
        }

        public ActionResult ProductByCategory(int? page, int MATHELOAI = 1)
        {
            int pagesize = 12; //số sản phẩm trên một trang
            int pagenumber = (page ?? 1); //số trang
            THELOAI theloai = db.THELOAIs.SingleOrDefault(n => n.MATHELOAI == MATHELOAI);
            if (theloai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<SACH> lstSach = db.SACHes.Where(n => n.MATHELOAI == MATHELOAI).OrderBy(n => n.TENSACH).ToList();
            
            ViewBag.MATHELOAI = MATHELOAI;
            ViewBag.Sach =lstSach.Count() + " kết quả tìm kiếm. " + theloai.TENTHELOAI;
            return View(lstSach.ToPagedList(pagenumber, pagesize));
        }

        public ActionResult ProductByNXB(int? page, int MANXB = 1)
        {
            int pagesize = 12; //số sản phẩm trên một trang
            int pagenumber = (page ?? 1); //số trang
            NXB nxb = db.NXBs.SingleOrDefault(n => n.MANXB == MANXB);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<SACH> lstSach = db.SACHes.Where(n => n.MANXB == MANXB).OrderBy(n => n.TENSACH).ToList();

            ViewBag.MANXB = MANXB;
            ViewBag.Sach = lstSach.Count() + " kết quả tìm kiếm." + nxb.TENNXB;
            return View(lstSach.ToPagedList(pagenumber, pagesize));
        }

    }
}