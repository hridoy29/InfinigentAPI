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
    public class CommnetsController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/Commnets
        public IQueryable<LU_Commnets> GetLU_Commnets()
        {
            return db.LU_Commnets.Where(x => x.IsActive == true);
        }

        // GET: api/Commnets/5
        [ResponseType(typeof(LU_Commnets))]
        public IHttpActionResult GetLU_Commnets(int id)
        {
            LU_Commnets lU_Commnets = db.LU_Commnets.Find(id);
            if (lU_Commnets == null)
            {
                return NotFound();
            }

            return Ok(lU_Commnets);
        }

        // PUT: api/Commnets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLU_Commnets(int id, LU_Commnets lU_Commnets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_Commnets.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_Commnets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_CommnetsExists(id))
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

        // POST: api/Commnets
        [ResponseType(typeof(LU_Commnets))]
        public IHttpActionResult PostLU_Commnets(LU_Commnets lU_Commnets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_Commnets.Add(lU_Commnets);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lU_Commnets.Id }, lU_Commnets);
        }

        // DELETE: api/Commnets/5
        [ResponseType(typeof(LU_Commnets))]
        public IHttpActionResult DeleteLU_Commnets(int id)
        {
            LU_Commnets lU_Commnets = db.LU_Commnets.Find(id);
            if (lU_Commnets == null)
            {
                return NotFound();
            }

            db.LU_Commnets.Remove(lU_Commnets);
            db.SaveChanges();

            return Ok(lU_Commnets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_CommnetsExists(int id)
        {
            return db.LU_Commnets.Count(e => e.Id == id) > 0;
        }
    }
}