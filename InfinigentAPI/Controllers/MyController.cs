using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace InfinigentAPI.Controllers
{
    public class User
    {
        public string UserName { get; set; }

    }
    public class MyController : ApiController
    {
        // GET: api/My
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET: api/My/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/my
        [ResponseType(typeof(string))]
        [HttpPost]      
        
        
        public IHttpActionResult Post([FromBody] string muser)
        {

            return Ok(muser);

        }

        // PUT: api/My/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/My/5
        public void Delete(int id)
        {
        }
    }
}
