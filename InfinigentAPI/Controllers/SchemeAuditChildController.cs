using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InfinigentAPI.Models;

namespace InfinigentAPI.Controllers
{
    public class SchemeAuditChildController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/SchemeAuditChild
        public IQueryable<TRN_SchemeAuditChild> GetTRN_SchemeAuditChild()
        {
            return db.TRN_SchemeAuditChild;
        }

        // GET: api/SchemeAuditChild/5
        [ResponseType(typeof(TRN_SchemeAuditChild))]
        public IHttpActionResult GetTRN_SchemeAuditChild(int id)
        {
            TRN_SchemeAuditChild tRN_SchemeAuditChild = db.TRN_SchemeAuditChild.Find(id);
            if (tRN_SchemeAuditChild == null)
            {
                return NotFound();
            }

            return Ok(tRN_SchemeAuditChild);
        }

        // PUT: api/SchemeAuditChild/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTRN_SchemeAuditChild(int id, TRN_SchemeAuditChild tRN_SchemeAuditChild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tRN_SchemeAuditChild.Id)
            {
                return BadRequest();
            }

            db.Entry(tRN_SchemeAuditChild).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRN_SchemeAuditChildExists(id))
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

        // POST: api/SchemeAuditChild
        [ResponseType(typeof(TRN_SchemeAuditChild))]
        public IHttpActionResult PostTRN_SchemeAuditChild(TRN_SchemeAuditChild tRN_SchemeAuditChild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TRN_SchemeAuditChild.Add(tRN_SchemeAuditChild);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tRN_SchemeAuditChild.Id }, tRN_SchemeAuditChild);
        }

        // DELETE: api/SchemeAuditChild/5
        [ResponseType(typeof(TRN_SchemeAuditChild))]
        public IHttpActionResult DeleteTRN_SchemeAuditChild(int id)
        {
            TRN_SchemeAuditChild tRN_SchemeAuditChild = db.TRN_SchemeAuditChild.Find(id);
            if (tRN_SchemeAuditChild == null)
            {
                return NotFound();
            }

            db.TRN_SchemeAuditChild.Remove(tRN_SchemeAuditChild);
            db.SaveChanges();

            return Ok(tRN_SchemeAuditChild);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TRN_SchemeAuditChildExists(int id)
        {
            return db.TRN_SchemeAuditChild.Count(e => e.Id == id) > 0;
        }
    }
}