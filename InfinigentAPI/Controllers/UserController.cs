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
    public class UserController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/User
        public IQueryable<LU_User_t> GetLU_User_t()
        {
            return db.LU_User_t;
        }

        // GET: api/User/5
        [ResponseType(typeof(LU_User_t))]
        public IQueryable<LU_User_t> GetLU_User_t(int id)
        {
            /* LU_User_t lU_User_t = db.LU_User_t.Find(id);
             if (lU_User_t == null)
             {
                 return NotFound();
             }

             return Ok(lU_User_t);*/
            return  db.LU_User_t;
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLU_User_t(int id, LU_User_t lU_User_t)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_User_t.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_User_t).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_User_tExists(id))
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

        // POST: api/User
        [ResponseType(typeof(LU_User_t))]
        public IHttpActionResult PostLU_User_t(LU_User_t lU_User_t)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_User_t.Add(lU_User_t);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lU_User_t.Id }, lU_User_t);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(LU_User_t))]
        public IHttpActionResult DeleteLU_User_t(int id)
        {
            LU_User_t lU_User_t = db.LU_User_t.Find(id);
            if (lU_User_t == null)
            {
                return NotFound();
            }

            db.LU_User_t.Remove(lU_User_t);
            db.SaveChanges();

            return Ok(lU_User_t);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_User_tExists(int id)
        {
            return db.LU_User_t.Count(e => e.Id == id) > 0;
        }
    }
}