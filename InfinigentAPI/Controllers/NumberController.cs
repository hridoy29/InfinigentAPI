using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using InfinigentAPI.Models;

namespace InfinigentAPI.Controllers
{
    public class NumberController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/Number
        public IQueryable<TRN_Number> GetTRN_Number()
        {
            return db.TRN_Number;
        }

        // GET: api/Number/5
        [ResponseType(typeof(TRN_Number))]
        public IHttpActionResult GetTRN_Number(int id)
        {
            TRN_Number tRN_Number = db.TRN_Number.Find(id);
            if (tRN_Number == null)
            {
                return NotFound();
            }

            return Ok(tRN_Number);
        }

        // PUT: api/Number/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTRN_Number(int id, TRN_Number tRN_Number)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tRN_Number.Id)
            {
                return BadRequest();
            }

            db.Entry(tRN_Number).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
                return Ok(tRN_Number);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRN_NumberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Number
        [ResponseType(typeof(TRN_Number))]
        public async Task<IHttpActionResult> PostTRN_Number(TRN_Number tRN_Number)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(tRN_Number).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
                return CreatedAtRoute("DefaultApi", new { id = tRN_Number.Id }, tRN_Number);

            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest(ModelState);

            }

     
        }

        // DELETE: api/Number/5
        [ResponseType(typeof(TRN_Number))]
        public IHttpActionResult DeleteTRN_Number(int id)
        {
            TRN_Number tRN_Number = db.TRN_Number.Find(id);
            if (tRN_Number == null)
            {
                return NotFound();
            }

            db.TRN_Number.Remove(tRN_Number);
            db.SaveChanges();

            return Ok(tRN_Number);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TRN_NumberExists(int id)
        {
            return db.TRN_Number.Count(e => e.Id == id) > 0;
        }
    }
}
