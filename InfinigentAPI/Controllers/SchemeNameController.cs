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
    public class SchemeNameController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/SchemeName
        public IQueryable<LU_SchemeName> GetLU_SchemeName()
        {
            return db.LU_SchemeName;
        }

        // GET: api/SchemeName/5
        [ResponseType(typeof(LU_SchemeName))]
        public IHttpActionResult GetLU_SchemeName(int id)
        {
            LU_SchemeName lU_SchemeName = db.LU_SchemeName.Find(id);
            if (lU_SchemeName == null)
            {
                return NotFound();
            }

            return Ok(lU_SchemeName);
        }

        // PUT: api/SchemeName/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLU_SchemeName(int id, LU_SchemeName lU_SchemeName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_SchemeName.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_SchemeName).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_SchemeNameExists(id))
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

        // POST: api/SchemeName
        [ResponseType(typeof(LU_SchemeName))]
        public IHttpActionResult PostLU_SchemeName(LU_SchemeName lU_SchemeName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_SchemeName.Add(lU_SchemeName);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lU_SchemeName.Id }, lU_SchemeName);
        }

        // DELETE: api/SchemeName/5
        [ResponseType(typeof(LU_SchemeName))]
        public IHttpActionResult DeleteLU_SchemeName(int id)
        {
            LU_SchemeName lU_SchemeName = db.LU_SchemeName.Find(id);
            if (lU_SchemeName == null)
            {
                return NotFound();
            }

            db.LU_SchemeName.Remove(lU_SchemeName);
            db.SaveChanges();

            return Ok(lU_SchemeName);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_SchemeNameExists(int id)
        {
            return db.LU_SchemeName.Count(e => e.Id == id) > 0;
        }
    }
}