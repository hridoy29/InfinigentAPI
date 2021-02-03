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
    public class AICController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/AIC
        public IQueryable<LU_AIC> GetLU_AIC()
        {
            return db.LU_AIC;
        }

        // GET: api/AIC/5
        [ResponseType(typeof(LU_AIC))]
        public IHttpActionResult GetLU_AIC(int id)
        {
            LU_AIC lU_AIC = db.LU_AIC.Find(id);
            if (lU_AIC == null)
            {
                return NotFound();
            }

            return Ok(lU_AIC);
        }

        // PUT: api/AIC/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLU_AIC(int id, LU_AIC lU_AIC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_AIC.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_AIC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_AICExists(id))
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

        // POST: api/AIC
        [ResponseType(typeof(LU_AIC))]
        public IHttpActionResult PostLU_AIC(LU_AIC lU_AIC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_AIC.Add(lU_AIC);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lU_AIC.Id }, lU_AIC);
        }

        // DELETE: api/AIC/5
        [ResponseType(typeof(LU_AIC))]
        public IHttpActionResult DeleteLU_AIC(int id)
        {
            LU_AIC lU_AIC = db.LU_AIC.Find(id);
            if (lU_AIC == null)
            {
                return NotFound();
            }

            db.LU_AIC.Remove(lU_AIC);
            db.SaveChanges();

            return Ok(lU_AIC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_AICExists(int id)
        {
            return db.LU_AIC.Count(e => e.Id == id) > 0;
        }
    }
}