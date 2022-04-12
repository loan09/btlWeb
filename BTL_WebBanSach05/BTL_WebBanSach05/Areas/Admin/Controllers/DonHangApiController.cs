using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class DonHangApiController : ApiController
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: api/DonHangApi
        public Array Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<HOADONBAN> hdb = db.HOADONBANs.ToList();
            List<CT_HDBAN> ct_hdb = db.CT_HDBAN.ToList();
            List<SACH> sach = db.SACHes.ToList();
            List<TK_KHACHHANG> khachhang = db.TK_KHACHHANG.ToList();

            var list = (from hd in hdb
                        join kh in khachhang on hd.MAHDBAN equals kh.ID_KHACHHANG
                        join ct_hd in ct_hdb on hd.MAHDBAN equals ct_hd.MAHDBAN
                        join s in sach on ct_hd.MASACH equals s.MASACH

                        select new
                        {
                            MaDonHang = hd.MAHDBAN,
                            NgayLapHD = hd.NGAYLAPHDBAN,
                            MaKH = hd.ID_KHACHHANG,
                            TongTien = ct_hd.SLBAN * s.GIABAN,
                        });

            return list.ToArray();
        }

        // GET: api/DonHangApi/5
        /// Tìm kiếm theo id đơn hàng và id khachsh hàng
        public Array GetChiTietHoaDonKLists(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<HOADONBAN> hdb = db.HOADONBANs.ToList();
            List<CT_HDBAN> ct_hdb = db.CT_HDBAN.ToList();
            List<SACH> sach = db.SACHes.ToList();
            List<TK_KHACHHANG> khachhang = db.TK_KHACHHANG.ToList();

            var list = (from hd in hdb
                        join kh in khachhang on hd.MAHDBAN equals kh.ID_KHACHHANG
                        join ct_hd in ct_hdb on hd.MAHDBAN equals ct_hd.MAHDBAN
                        join s in sach on ct_hd.MASACH equals s.MASACH
                        where (hd.MAHDBAN == id || kh.ID_KHACHHANG == id)

                        select new
                        {
                            MaDonHang = hd.MAHDBAN,
                            NgayLapHD = hd.NGAYLAPHDBAN,
                            MaKH = hd.ID_KHACHHANG,
                            TongTien = ct_hd.SLBAN * s.GIABAN,
                        });

            return list.ToArray();
        }

        public Array GetCT_DH(int idDonHang)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<HOADONBAN> hdb = db.HOADONBANs.ToList();
            List<CT_HDBAN> ct_hdb = db.CT_HDBAN.ToList();
            List<SACH> sach = db.SACHes.ToList();
            List<TK_KHACHHANG> khachhang = db.TK_KHACHHANG.ToList();

            var list = (from hd in hdb
                        join kh in khachhang on hd.MAHDBAN equals kh.ID_KHACHHANG
                        join ct_hd in ct_hdb on hd.MAHDBAN equals ct_hd.MAHDBAN
                        join s in sach on ct_hd.MASACH equals s.MASACH
                        where hd.MAHDBAN == idDonHang

                        select new
                        {
                            MaHD = hd.MAHDBAN,
                            TenSP = s.TENSACH,
                            SL = ct_hd.SLBAN,
                            giaban = s.GIABAN
                        });

            return list.ToArray();
        }
        // POST: api/DonHangApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DonHangApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DonHangApi/5
        public void Delete(int id)
        {
        }
    }
}
