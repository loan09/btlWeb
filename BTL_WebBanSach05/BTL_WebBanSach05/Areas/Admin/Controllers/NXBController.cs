using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class NXBController : ApiController
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: api/NXB
        public IEnumerable<NXB> Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.NXBs;
        }

        // GET: api/NXB/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NXB
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/NXB/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NXB/5
        public void Delete(int id)
        {
        }
    }
}
