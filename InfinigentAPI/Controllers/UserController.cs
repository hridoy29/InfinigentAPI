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
        public IQueryable<LU_User> GetLU_User()
        {
            return db.LU_User.Where(x=>x.IsActive==true);
        }

        // GET: api/User/5
        [ResponseType(typeof(LU_User))]
        public IQueryable<LU_User> GetLU_User(int id)
        {
            /* LU_User LU_User = db.LU_User.Find(id);
             if (LU_User == null)
             {
                 return NotFound();
             }

             return Ok(LU_User);*/
            return  db.LU_User;
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLU_User(int id, LU_User LU_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != LU_User.Id)
            {
                return BadRequest();
            }

            db.Entry(LU_User).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_UserExists(id))
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
        [ResponseType(typeof(LU_User))]
        public IHttpActionResult PostLU_User(LU_User LU_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_User.Add(LU_User);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = LU_User.Id }, LU_User);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(LU_User))]
        public IHttpActionResult DeleteLU_User(int id)
        {
            LU_User LU_User = db.LU_User.Find(id);
            if (LU_User == null)
            {
                return NotFound();
            }

            db.LU_User.Remove(LU_User);
            db.SaveChanges();

            return Ok(LU_User);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_UserExists(int id)
        {
            return db.LU_User.Count(e => e.Id == id) > 0;
        }
    }
}