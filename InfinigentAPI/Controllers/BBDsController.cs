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
    public class BBDsController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/LU_BBD
        public IQueryable<LU_BBD> GetBBDs()
        {
            return db.LU_BBD;
        }

        // GET: api/LU_BBD/5
        [ResponseType(typeof(LU_BBD))]
        public async Task<IHttpActionResult> GetBBD(int id)
        {
            LU_BBD LU_BBD = await db.LU_BBD.FindAsync(id);
            if (LU_BBD == null)
            {
                return NotFound();
            }

            return Ok(LU_BBD);
        }

        // PUT: api/LU_BBD/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBBD(int id, LU_BBD LU_BBD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != LU_BBD.Id)
            {
                return BadRequest();
            }

            db.Entry(LU_BBD).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BBDExists(id))
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

        // POST: api/LU_BBD
        [ResponseType(typeof(LU_BBD))]
        public async Task<IHttpActionResult> PostBBD(LU_BBD LU_BBD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_BBD.Add(LU_BBD);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = LU_BBD.Id }, LU_BBD);
        }

        // DELETE: api/LU_BBD/5
        [ResponseType(typeof(LU_BBD))]
        public async Task<IHttpActionResult> DeleteBBD(int id)
        {
            LU_BBD LU_BBD = await db.LU_BBD.FindAsync(id);
            if (LU_BBD == null)
            {
                return NotFound();
            }

            db.LU_BBD.Remove(LU_BBD);
            await db.SaveChangesAsync();

            return Ok(LU_BBD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BBDExists(int id)
        {
            return db.LU_BBD.Count(e => e.Id == id) > 0;
        }
    }
}