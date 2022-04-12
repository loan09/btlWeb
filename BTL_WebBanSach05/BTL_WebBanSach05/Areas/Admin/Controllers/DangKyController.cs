using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class DangKyController : ApiController
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: api/DangKy
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DangKy/5 : dang nhap
        public bool Get(string sdt, string mk)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<TAIKHOANADMIN> taikhoan = db.TAIKHOANADMINs.ToList();

            var list = (from sp in taikhoan where sp.SDT_ADMIN == sdt && sp.MATKHAU == mk select sp);
            if(list.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // POST: api/DangKy
        [HttpPost]
        public bool DangKyTK(string sdt, string matkhau)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                TAIKHOANADMIN taikhoan = new TAIKHOANADMIN();

                taikhoan.SDT_ADMIN = sdt;
                taikhoan.MATKHAU = matkhau;

                db.TAIKHOANADMINs.Add(taikhoan);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        // PUT: api/DangKy/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DangKy/5
        public void Delete(int id)
        {
        }
    }
}
