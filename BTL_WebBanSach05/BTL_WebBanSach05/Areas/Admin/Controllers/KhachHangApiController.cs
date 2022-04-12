using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class KhachHangApiController : ApiController
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: api/Sach
        public IEnumerable<TK_KHACHHANG> GetAllKH()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TK_KHACHHANG;
        }

        // GET: api/KhachHangApi/5
        public Array Get(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<TK_KHACHHANG> KH = db.TK_KHACHHANG.ToList();

            var list = (from sp in KH
                        where (sp.ID_KHACHHANG == id || int.Parse(sp.SDT_KH) == id)

                        select new
                        {
                           ID_KHACHHANG = sp.ID_KHACHHANG,
                           HOTENKH = sp.HOTENKH,
                           SDT_KH = sp.SDT_KH,
                           DIACHI = sp.DIACHI
                        });

            return list.ToArray();
        }
        public Array GetListDH(int idKH)
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
                        where (hd.MAHDBAN == idKH)

                        select new
                        {
                            MaDonHang = hd.MAHDBAN,
                            NgayLapHD = hd.NGAYLAPHDBAN,
                            TongTien = ct_hd.SLBAN * s.GIABAN,
                        });

            return list.ToArray();
        }
        public Array GetCT_DH_KH(int idDH)
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
                        where hd.MAHDBAN == idDH

                        select new
                        {
                            MaHD = hd.MAHDBAN,
                            MaSP = s.MASACH,
                            TenSP = s.TENSACH,
                            SL = ct_hd.SLBAN,
                            giaban = s.GIABAN
                        });

            return list.ToArray();
        }

        // POST: api/KhachHangApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/KhachHangApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/KhachHangApi/5
        public void Delete(int id)
        {
        }
    }
}
