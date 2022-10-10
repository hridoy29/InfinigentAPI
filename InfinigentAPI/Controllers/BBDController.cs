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
    public class BBDController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/BBD
        [ResponseType(typeof(LU_BBD))]
        public async Task<IHttpActionResult> GetLU_BBDsAsync()
        {

            try
            {

                var list = await Facade.BBDBLL.GetBBDs();
              
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

        // GET: api/BBD/5
        [ResponseType(typeof(LU_BBD))]
        public async Task<IHttpActionResult> GetLU_BBD(int id)
        {
            LU_BBD lU_BBD = await db.LU_BBD.FindAsync(id);
            if (lU_BBD == null)
            {
                return NotFound();
            }

            return Ok(lU_BBD);
        }

        // PUT: api/BBD/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLU_BBD(int id, LU_BBD lU_BBD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_BBD.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_BBD).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_BBDExists(id))
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

        // POST: api/BBD
        [ResponseType(typeof(LU_BBD))]
        public async Task<IHttpActionResult> PostLU_BBD(LU_BBD lU_BBD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_BBD.Add(lU_BBD);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lU_BBD.Id }, lU_BBD);
        }

        // DELETE: api/BBD/5
        [ResponseType(typeof(LU_BBD))]
        public async Task<IHttpActionResult> DeleteLU_BBD(int id)
        {
            LU_BBD lU_BBD = await db.LU_BBD.FindAsync(id);
            if (lU_BBD == null)
            {
                return NotFound();
            }

            db.LU_BBD.Remove(lU_BBD);
            await db.SaveChangesAsync();

            return Ok(lU_BBD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_BBDExists(int id)
        {
            return db.LU_BBD.Count(e => e.Id == id) > 0;
        }
    }
}