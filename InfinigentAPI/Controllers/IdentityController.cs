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
using SecurityBLL;

namespace InfinigentAPI.Controllers
{
    public class IdentityController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/Identity
        [ResponseType(typeof(LU_Identity))]
        public async Task<IHttpActionResult> GetLU_IdentitiesAsync()
        {

            try
            {

                var list = await Facade.IdentityBLL.GetIdentities();

                if (list == null)
                {
                    return NotFound();
                }

                return Ok(list);


            }
            catch (Exception ex)
            {
                return NotFound();

            }

        }

        // GET: api/Identity/5
        [ResponseType(typeof(LU_Identity))]
        public async Task<IHttpActionResult> GetLU_Identity(int id)
        {
            LU_Identity lU_Identity = await db.LU_Identity.FindAsync(id);
            if (lU_Identity == null)
            {
                return NotFound();
            }

            return Ok(lU_Identity);
        }

        // PUT: api/Identity/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLU_Identity(int id, LU_Identity lU_Identity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_Identity.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_Identity).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_IdentityExists(id))
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

        // POST: api/Identity
        [ResponseType(typeof(LU_Identity))]
        public async Task<IHttpActionResult> PostLU_Identity(LU_Identity lU_Identity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_Identity.Add(lU_Identity);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lU_Identity.Id }, lU_Identity);
        }

        // DELETE: api/Identity/5
        [ResponseType(typeof(LU_Identity))]
        public async Task<IHttpActionResult> DeleteLU_Identity(int id)
        {
            LU_Identity lU_Identity = await db.LU_Identity.FindAsync(id);
            if (lU_Identity == null)
            {
                return NotFound();
            }

            db.LU_Identity.Remove(lU_Identity);
            await db.SaveChangesAsync();

            return Ok(lU_Identity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_IdentityExists(int id)
        {
            return db.LU_Identity.Count(e => e.Id == id) > 0;
        }
    }
}