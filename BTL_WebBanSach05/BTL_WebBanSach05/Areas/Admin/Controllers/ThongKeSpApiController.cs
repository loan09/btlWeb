using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class ThongKeSpApiController : ApiController
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: api/ThongKeSpApi
        public Array Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<HOADONBAN> HDB = db.HOADONBANs.ToList();
            List<CT_HDBAN> CT_HDB = db.CT_HDBAN.ToList();
            List<SACH> Sach = db.SACHes.ToList();

            var list = (from CTHDB in CT_HDB
                        join s in Sach on CTHDB.MASACH equals s.MASACH
                        group CTHDB by new { s, CTHDB.SLBAN } into MaHDGroup
                        orderby MaHDGroup.Sum(x => x.SLBAN) descending
                        select new
                        {
                            TenSach = MaHDGroup.Key.s.TENSACH,
                            GiaSach = MaHDGroup.Key.s.GIABAN,
                            DoanhThu = MaHDGroup.Sum(x => x.SLBAN * MaHDGroup.Key.s.GIABAN)


                        }).Take(4);

            return list.ToArray();
        }

        // GET: api/ThongKeSpApi/5
        public string Get(int id)
        {
            return "Value";
        }

        // POST: api/ThongKeSpApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ThongKeSpApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ThongKeSpApi/5
        public void Delete(int id)
        {
        }
    }
}
