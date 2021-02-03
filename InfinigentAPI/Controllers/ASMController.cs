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
    public class ASMController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/ASM
        public IQueryable<LU_ASM> GetLU_ASM()
        {
            return db.LU_ASM;
        }

        // GET: api/ASM/5
        [ResponseType(typeof(LU_ASM))]
        public IHttpActionResult GetLU_ASM(int id)
        {
            LU_ASM lU_ASM = db.LU_ASM.Find(id);
            if (lU_ASM == null)
            {
                return NotFound();
            }

            return Ok(lU_ASM);
        }

        // PUT: api/ASM/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLU_ASM(int id, LU_ASM lU_ASM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_ASM.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_ASM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_ASMExists(id))
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

        // POST: api/ASM
        [ResponseType(typeof(LU_ASM))]
        public IHttpActionResult PostLU_ASM(LU_ASM lU_ASM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_ASM.Add(lU_ASM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lU_ASM.Id }, lU_ASM);
        }

        // DELETE: api/ASM/5
        [ResponseType(typeof(LU_ASM))]
        public IHttpActionResult DeleteLU_ASM(int id)
        {
            LU_ASM lU_ASM = db.LU_ASM.Find(id);
            if (lU_ASM == null)
            {
                return NotFound();
            }

            db.LU_ASM.Remove(lU_ASM);
            db.SaveChanges();

            return Ok(lU_ASM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_ASMExists(int id)
        {
            return db.LU_ASM.Count(e => e.Id == id) > 0;
        }
    }
}