using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class TheLoaiController : ApiController
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: api/TheLoai
        public IEnumerable<THELOAI> Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.THELOAIs;
        }

        // GET: api/TheLoai/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TheLoai
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TheLoai/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TheLoai/5
        public void Delete(int id)
        {
        }
    }
}
