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
    public class ObservationController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/Observation
        [ResponseType(typeof(LU_Observation))]
        public async Task<IHttpActionResult> GetLU_IssuesAsync()
        {



            try
            {

                var list = await Facade.ObservationBLL.GetObservations();
               
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

        // GET: api/Observation/5
        [ResponseType(typeof(LU_Observation))]
        public async Task<IHttpActionResult> GetLU_Observation(int id)
        {
            LU_Observation lU_Observation = await db.LU_Observation.FindAsync(id);
            if (lU_Observation == null)
            {
                return NotFound();
            }

            return Ok(lU_Observation);
        }

        // PUT: api/Observation/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLU_Observation(int id, LU_Observation lU_Observation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_Observation.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_Observation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_ObservationExists(id))
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

        // POST: api/Observation
        [ResponseType(typeof(LU_Observation))]
        public async Task<IHttpActionResult> PostLU_Observation(LU_Observation lU_Observation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_Observation.Add(lU_Observation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lU_Observation.Id }, lU_Observation);
        }

        // DELETE: api/Observation/5
        [ResponseType(typeof(LU_Observation))]
        public async Task<IHttpActionResult> DeleteLU_Observation(int id)
        {
            LU_Observation lU_Observation = await db.LU_Observation.FindAsync(id);
            if (lU_Observation == null)
            {
                return NotFound();
            }

            db.LU_Observation.Remove(lU_Observation);
            await db.SaveChangesAsync();

            return Ok(lU_Observation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_ObservationExists(int id)
        {
            return db.LU_Observation.Count(e => e.Id == id) > 0;
        }
    }
}