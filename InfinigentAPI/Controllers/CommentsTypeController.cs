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
    public class CommentsTypeController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/CommentsType
        public IQueryable<LU_CommentsType> GetLU_CommentsType()
        {
            return db.LU_CommentsType.Where(x => x.IsActive == true);
        }

        // GET: api/CommentsType/5
        [ResponseType(typeof(LU_CommentsType))]
        public IHttpActionResult GetLU_CommentsType(int id)
        {
            LU_CommentsType lU_CommentsType = db.LU_CommentsType.Find(id);
            if (lU_CommentsType == null)
            {
                return NotFound();
            }

            return Ok(lU_CommentsType);
        }

        // PUT: api/CommentsType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLU_CommentsType(int id, LU_CommentsType lU_CommentsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_CommentsType.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_CommentsType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_CommentsTypeExists(id))
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

        // POST: api/CommentsType
        [ResponseType(typeof(LU_CommentsType))]
        public IHttpActionResult PostLU_CommentsType(LU_CommentsType lU_CommentsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_CommentsType.Add(lU_CommentsType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lU_CommentsType.Id }, lU_CommentsType);
        }

        // DELETE: api/CommentsType/5
        [ResponseType(typeof(LU_CommentsType))]
        public IHttpActionResult DeleteLU_CommentsType(int id)
        {
            LU_CommentsType lU_CommentsType = db.LU_CommentsType.Find(id);
            if (lU_CommentsType == null)
            {
                return NotFound();
            }

            db.LU_CommentsType.Remove(lU_CommentsType);
            db.SaveChanges();

            return Ok(lU_CommentsType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_CommentsTypeExists(int id)
        {
            return db.LU_CommentsType.Count(e => e.Id == id) > 0;
        }
    }
}