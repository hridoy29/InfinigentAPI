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

        // GET: api/BBDs
        public IQueryable<BBD> GetBBDs()
        {
            return db.BBDs;
        }

        // GET: api/BBDs/5
        [ResponseType(typeof(BBD))]
        public async Task<IHttpActionResult> GetBBD(int id)
        {
            BBD bBD = await db.BBDs.FindAsync(id);
            if (bBD == null)
            {
                return NotFound();
            }

            return Ok(bBD);
        }

        // PUT: api/BBDs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBBD(int id, BBD bBD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bBD.Id)
            {
                return BadRequest();
            }

            db.Entry(bBD).State = EntityState.Modified;

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

        // POST: api/BBDs
        [ResponseType(typeof(BBD))]
        public async Task<IHttpActionResult> PostBBD(BBD bBD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BBDs.Add(bBD);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bBD.Id }, bBD);
        }

        // DELETE: api/BBDs/5
        [ResponseType(typeof(BBD))]
        public async Task<IHttpActionResult> DeleteBBD(int id)
        {
            BBD bBD = await db.BBDs.FindAsync(id);
            if (bBD == null)
            {
                return NotFound();
            }

            db.BBDs.Remove(bBD);
            await db.SaveChangesAsync();

            return Ok(bBD);
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
            return db.BBDs.Count(e => e.Id == id) > 0;
        }
    }
}