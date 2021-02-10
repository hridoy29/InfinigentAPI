using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InfinigentAPI.Models;

namespace InfinigentAPI.Controllers
{
    public class TestController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/Test
        public IQueryable<Test> GetTests()
        {

            var bytes = Convert.FromBase64String(db.Tests.Find(7).Photo);
            //var bytes = Convert.FromBase64String(Test.Photo);
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                image.Save(@"E:\QuadTheory\" + db.Tests.Find(7).Number + "_" + db.Tests.Find(7).Id + ".png", System.Drawing.Imaging.ImageFormat.Png);

            }


            return db.Tests;
        }
        
        // GET: api/Test/5
        [ResponseType(typeof(Test))]
        public IHttpActionResult GetTest(int id)
        {
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        // PUT: api/Test/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTest(int id, Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.Id)
            {
                return BadRequest();
            }

            db.Entry(test).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Test
        [ResponseType(typeof(Test))]
        public IHttpActionResult PostTest(Test Test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tests.Add(Test);
            db.SaveChanges();
            //var bytes = Convert.FromBase64String(db.Tests.Find(6).Photo);
            var bytes = Convert.FromBase64String(Test.Photo);
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                image.Save(@"E:\QuadTheory\"+ Test.Number+"_"+Test.Id+".png", System.Drawing.Imaging.ImageFormat.Png);

            }
            return CreatedAtRoute("DefaultApi", new { id = Test.Id }, Test);
        }

        // DELETE: api/Test/5
        [ResponseType(typeof(Test))]
        public IHttpActionResult DeleteTest(int id)
        {
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            db.Tests.Remove(test);
            db.SaveChanges();

            return Ok(test);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestExists(int id)
        {
            return db.Tests.Count(e => e.Id == id) > 0;
        }
    }
}