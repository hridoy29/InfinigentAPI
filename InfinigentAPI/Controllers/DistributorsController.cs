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

        // GET: api/LU_Distributor
        public async Task<IHttpActionResult> GetDistributorsAsync()
        {
            try
            {

                var list = await Facade.DistributorBLL.GetDistributors();

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

        // GET: api/LU_Distributor/5
        [ResponseType(typeof(LU_Distributor))]
        public async Task<IHttpActionResult> GetDistributor(int id)
        {
            LU_Distributor LU_Distributor = await db.LU_Distributor.FindAsync(id);
            if (LU_Distributor == null)
            {
                return NotFound();
            }

            return Ok(LU_Distributor);
        }



        // GET: api/LU_Distributor/GetDistributorInfo/DbCode
        [ResponseType(typeof(LU_Distributor))]
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


        // PUT: api/LU_Distributor/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDistributor(int id, LU_Distributor LU_Distributor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != LU_Distributor.Id)
            {
                return BadRequest();
            }

            db.Entry(LU_Distributor).State = EntityState.Modified;

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

        // POST: api/LU_Distributor
        [ResponseType(typeof(LU_Distributor))]
        public async Task<IHttpActionResult> PostDistributor(LU_Distributor LU_Distributor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_Distributor.Add(LU_Distributor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = LU_Distributor.Id }, LU_Distributor);
        }

        // DELETE: api/LU_Distributor/5
        [ResponseType(typeof(LU_Distributor))]
        public async Task<IHttpActionResult> DeleteDistributor(int id)
        {
            LU_Distributor LU_Distributor = await db.LU_Distributor.FindAsync(id);
            if (LU_Distributor == null)
            {
                return NotFound();
            }

            db.LU_Distributor.Remove(LU_Distributor);
            await db.SaveChangesAsync();

            return Ok(LU_Distributor);
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
            return db.LU_Distributor.Count(e => e.Id == id) > 0;
        }
    }
}