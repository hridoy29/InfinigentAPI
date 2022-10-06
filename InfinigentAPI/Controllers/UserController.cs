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
    public class UserController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/User
        [ResponseType(typeof(LU_Issues))]
        public async Task<IHttpActionResult> GetLU_User()
        {
            //return db.LU_User.Where(x=>x.IsActive==true);


            try
            {

                var list = await Facade.UserBLL.GetUsers();
              
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


        //// GET: api/User/5
        //[ResponseType(typeof(LU_User))]
        //public IQueryable<LU_User> GetAuditorInfo(int id)
        //{
        //    try
        //    {
        //        //if (userName != null && password != null)
        //        //{
        //        //    password = EncryptPassword(password);
        //        //}
        //        var list = Facade.User.GetByUsernameAndPassword(id);
        //        if (list != null)
        //        {
        //            System.Web.HttpContext.Current.Session["UserId"] = list.UserId;
        //        }
        //        return list;

        //    }
        //    catch (Exception ex)
        //    {
        //    //    error_Log error = new error_Log();
        //    //    error.ErrorMessage = ex.Message;
        //    //    error.ErrorType = ex.GetType().ToString();
        //    //    error.FileName = "UserController";
        //    //    return Json(error.ErrorMessage, JsonRequestBehavior.AllowGet);
        //    //
        //    }
        //    //return db.LU_User;
        //}

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