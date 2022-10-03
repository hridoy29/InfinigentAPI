using InfinigentAPI.Models;
using SecurityBLL;
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

namespace InfinigentAPI.Controllers
{
    public class LU_IssuesController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/LU_Issues
        [ResponseType(typeof(LU_Issues))]
        public async Task<IHttpActionResult> GetLU_IssuesAsync()
        {



            try
            {

                var list = await Facade.IssuesBLL.GetIssues();
                //if (list != null)
                //{
                //    System.Web.HttpContext.Current.Session["Id"] = list.Id;
                //}
                if (list == null)
                {
                    return NotFound();
                }

                return Ok(list);
                //return (IHttpActionResult)list;

            }
            catch (Exception ex)
            {
                return NotFound();
                //    error_Log error = new error_Log();
                //    error.ErrorMessage = ex.Message;
                //    error.ErrorType = ex.GetType().ToString();
                //    error.FileName = "UserController";
                //    return Json(error.ErrorMessage, JsonRequestBehavior.AllowGet);
                //
            }
          
        }

        // GET: api/LU_Issues/5
        [ResponseType(typeof(LU_Issues))]
        public async Task<IHttpActionResult> GetLU_Issues(int id)
        {
            LU_Issues lU_Issues = await db.LU_Issues.FindAsync(id);
            if (lU_Issues == null)
            {
                return NotFound();
            }

            return Ok(lU_Issues);
        }

        // PUT: api/LU_Issues/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLU_Issues(int id, LU_Issues lU_Issues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_Issues.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_Issues).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_IssuesExists(id))
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

        // POST: api/LU_Issues
        [ResponseType(typeof(LU_Issues))]
        public async Task<IHttpActionResult> PostLU_Issues(LU_Issues lU_Issues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_Issues.Add(lU_Issues);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lU_Issues.Id }, lU_Issues);
        }

        // DELETE: api/LU_Issues/5
        [ResponseType(typeof(LU_Issues))]
        public async Task<IHttpActionResult> DeleteLU_Issues(int id)
        {
            LU_Issues lU_Issues = await db.LU_Issues.FindAsync(id);
            if (lU_Issues == null)
            {
                return NotFound();
            }

            db.LU_Issues.Remove(lU_Issues);
            await db.SaveChangesAsync();

            return Ok(lU_Issues);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_IssuesExists(int id)
        {
            return db.LU_Issues.Count(e => e.Id == id) > 0;
        }
    }
}