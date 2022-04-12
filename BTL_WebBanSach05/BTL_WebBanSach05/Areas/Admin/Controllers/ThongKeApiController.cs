using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class ThongKeApiController : ApiController
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: api/ThongKeApi
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
                            TenSach = s.TENSACH,
                        });

            return list.ToArray();
        }

        // GET: api/ThongKeApi/5
        public Array Get(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<HOADONBAN> HDB = db.HOADONBANs.ToList();
            List<CT_HDBAN> CT_HDB = db.CT_HDBAN.ToList();
            List<SACH> Sach = db.SACHes.ToList();

            var lists = (from dh in HDB
                         where dh.NGAYLAPHDBAN.Value.Year == id
                         group dh by dh.NGAYLAPHDBAN.Value.Month into MaHDGroup

                         select new
                         {
                             Thang = MaHDGroup.Key,
                             TongDH = MaHDGroup.Count()

                         });
            int[] DH = new int[100];
            foreach (var item in lists)
            {
                DH[item.Thang] = item.TongDH;
            }
            var list = (from dh in HDB
                        join CTHDB in CT_HDB on dh.MAHDBAN equals CTHDB.MAHDBAN
                        join s in Sach on CTHDB.MASACH equals s.MASACH
                        where dh.NGAYLAPHDBAN.Value.Year == id
                        group new { CTHDB, s } by dh.NGAYLAPHDBAN.Value.Month into MaHDGroup
                        orderby MaHDGroup.Key
                        select new
                        {
                            Thang = MaHDGroup.Key,
                            TongHD = DH[MaHDGroup.Key],
                            TongSP = MaHDGroup.Sum(x => x.CTHDB.SLBAN),
                            TongTien = MaHDGroup.Sum(x => x.CTHDB.SLBAN * x.s.GIABAN)

                        });
            return list.ToArray();
        }

        // POST: api/ThongKeApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ThongKeApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ThongKeApi/5
        public void Delete(int id)
        {
        }
    }
}
