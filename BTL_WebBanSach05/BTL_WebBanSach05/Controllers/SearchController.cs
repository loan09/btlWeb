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
    
    public class SearchController : Controller
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: Search
        [HttpPost]
        public ActionResult ResultSearch(int? page, FormCollection f)
        {
            string KeyWord = f["txtKeyWord"].ToString();
            List<SACH> lstSach = db.SACHes.Where(n => n.TENSACH.Contains(KeyWord)).ToList();
            int pageNum = (page ?? 1);
            int pageSize = 12;

            if (lstSach.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào ";
                return View(db.SACHes.OrderBy(n=>n.TENSACH).ToPagedList(pageNum,pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstSach.Count + " sản phẩm";
            return View(lstSach.OrderBy(n => n.TENSACH).ToPagedList(pageNum,pageSize));
        }

        [HttpGet]
        public ActionResult ResultSearch(int? page, string KeyWord)
        {
            ViewBag.KeyWord = KeyWord;

            List<SACH> lstSach = db.SACHes.Where(n => n.TENSACH.Contains(KeyWord)).ToList();
            int pageNum = (page ?? 1);
            int pageSize = 12;

            if (lstSach.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào ";
                return View(db.SACHes.OrderBy(n => n.TENSACH).ToPagedList(pageNum, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstSach.Count + " sản phẩm";
            return View(lstSach.OrderBy(n => n.TENSACH).ToPagedList(pageNum, pageSize));
        }
    }
}