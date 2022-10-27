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
    public class DistributorsController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/Distributors
        public IQueryable<Distributor> GetDistributors()
        {
            return db.Distributors;
        }

        // GET: api/Distributors/5
        [ResponseType(typeof(Distributor))]
        public async Task<IHttpActionResult> GetDistributor(int id)
        {
            Distributor distributor = await db.Distributors.FindAsync(id);
            if (distributor == null)
            {
                return NotFound();
            }

            return Ok(distributor);
        }



        // GET: api/Distributor/GetDistributorInfo/DbCode
        [ResponseType(typeof(Distributor))]
        public async Task<IHttpActionResult> GetDistributorInfo(string DbCode)
        {

            try
            {

                var list = await Facade.DistributorBLL.GetDistributorInfo(DbCode);
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


        // PUT: api/Distributors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDistributor(int id, Distributor distributor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != distributor.Id)
            {
                return BadRequest();
            }

            db.Entry(distributor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistributorExists(id))
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

        // POST: api/Distributors
        [ResponseType(typeof(Distributor))]
        public async Task<IHttpActionResult> PostDistributor(Distributor distributor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Distributors.Add(distributor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = distributor.Id }, distributor);
        }

        // DELETE: api/Distributors/5
        [ResponseType(typeof(Distributor))]
        public async Task<IHttpActionResult> DeleteDistributor(int id)
        {
            Distributor distributor = await db.Distributors.FindAsync(id);
            if (distributor == null)
            {
                return NotFound();
            }

            db.Distributors.Remove(distributor);
            await db.SaveChangesAsync();

            return Ok(distributor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistributorExists(int id)
        {
            return db.Distributors.Count(e => e.Id == id) > 0;
        }
    }
}