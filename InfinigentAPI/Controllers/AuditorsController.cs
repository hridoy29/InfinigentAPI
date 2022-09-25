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
using InfinigentBackend.SECURITY.SecurityEntity;
using SecurityBLL;

namespace InfinigentAPI.Controllers
{
    public class AuditorsController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/Auditors
        //public IQueryable<Auditor> GetAuditors()
        //{
        //    return db.Auditors;
        //}

        //// GET: api/Auditors/5
        //[ResponseType(typeof(Auditor))]
        //public async Task<IHttpActionResult> GetAuditor(int id)
        //{
        //    Auditor auditor = await db.Auditors.FindAsync(id);
        //    if (auditor == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(auditor);
        //}


        // GET: api/Auditors/GetAuditorInfo/userEmail
        [ResponseType(typeof(Auditor))]
        public async Task<IHttpActionResult> GetAuditorInfo(string userEmail)
        {

            try
            {

                var list = await Facade.AuditorBLL.GetAuditorInfo(userEmail);
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

        //// PUT: api/Auditors/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutAuditor(int id, Auditor auditor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != auditor.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(auditor).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AuditorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Auditors
        //[ResponseType(typeof(Auditor))]
        //public async Task<IHttpActionResult> PostAuditor(Auditor auditor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Auditors.Add(auditor);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = auditor.Id }, auditor);
        //}

        //// DELETE: api/Auditors/5
        //[ResponseType(typeof(Auditor))]
        //public async Task<IHttpActionResult> DeleteAuditor(int id)
        //{
        //    Auditor auditor = await db.Auditors.FindAsync(id);
        //    if (auditor == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Auditors.Remove(auditor);
        //    await db.SaveChangesAsync();

        //    return Ok(auditor);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool AuditorExists(int id)
        //{
        //    return db.Auditors.Count(e => e.Id == id) > 0;
        //}
    }
}