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
    public class SchemeAuditParentController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/SchemeAuditParent
        public IQueryable<TRN_SchemeAuditParent> GetTRN_SchemeAuditParent()
        {
            return db.TRN_SchemeAuditParent;
        }

        // GET: api/SchemeAuditParent/5
        [ResponseType(typeof(TRN_SchemeAuditParent))]
        public IHttpActionResult GetTRN_SchemeAuditParent(int id)
        {
            TRN_SchemeAuditParent tRN_SchemeAuditParent = db.TRN_SchemeAuditParent.Find(id);
            if (tRN_SchemeAuditParent == null)
            {
                return NotFound();
            }

            return Ok(tRN_SchemeAuditParent);
        }

        // PUT: api/SchemeAuditParent/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTRN_SchemeAuditParent(int id, TRN_SchemeAuditParent tRN_SchemeAuditParent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tRN_SchemeAuditParent.Id)
            {
                return BadRequest();
            }

            db.Entry(tRN_SchemeAuditParent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRN_SchemeAuditParentExists(id))
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

        // POST: api/SchemeAuditParent
        [ResponseType(typeof(TRN_SchemeAuditParent))]
        public IHttpActionResult PostTRN_SchemeAuditParent(TRN_SchemeAuditParent tRN_SchemeAuditParent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TRN_SchemeAuditParent.Add(tRN_SchemeAuditParent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tRN_SchemeAuditParent.Id }, tRN_SchemeAuditParent);
        }

        // DELETE: api/SchemeAuditParent/5
        [ResponseType(typeof(TRN_SchemeAuditParent))]
        public IHttpActionResult DeleteTRN_SchemeAuditParent(int id)
        {
            TRN_SchemeAuditParent tRN_SchemeAuditParent = db.TRN_SchemeAuditParent.Find(id);
            if (tRN_SchemeAuditParent == null)
            {
                return NotFound();
            }

            db.TRN_SchemeAuditParent.Remove(tRN_SchemeAuditParent);
            db.SaveChanges();

            return Ok(tRN_SchemeAuditParent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TRN_SchemeAuditParentExists(int id)
        {
            return db.TRN_SchemeAuditParent.Count(e => e.Id == id) > 0;
        }
    }
}