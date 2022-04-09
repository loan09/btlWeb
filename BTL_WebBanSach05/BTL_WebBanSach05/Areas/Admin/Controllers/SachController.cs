using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class SachController : ApiController
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: api/Sach
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sach/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sach
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sach/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sach/5
        public void Delete(int id)
        {
        }
    }
}
