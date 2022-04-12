using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BTL_WebBanSach05.Models
{
    public class Cart
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        public int MASACH { get; set; }
        public string TENSACH { get; set; }

        public string TENANH { get; set; }

        public int GIABAN { get; set; }

        public int SOLUONG { get; set; }

        public int THANHTIEN { get { return SOLUONG * GIABAN; } }

        public Cart(int iMASACH)
        {
            MASACH = iMASACH;

            SACH sach = db.SACHes.Single(n => n.MASACH == MASACH);

            TENSACH = sach.TENSACH;
            TENANH = sach.TENANH;
            GIABAN = sach.GIABAN;
            SOLUONG = 1;

        }
    }
}