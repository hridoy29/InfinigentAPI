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
    public class SchemeAuditShopDetailsController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/SchemeAuditShopDetails
        public IQueryable<TRN_SchemeAuditShopDetails> GetTRN_SchemeAuditShopDetails()
        {
            return db.TRN_SchemeAuditShopDetails;
        }

        // GET: api/SchemeAuditShopDetails/5
        [ResponseType(typeof(TRN_SchemeAuditShopDetails))]
        public IHttpActionResult GetTRN_SchemeAuditShopDetails(int id)
        {
            TRN_SchemeAuditShopDetails tRN_SchemeAuditShopDetails = db.TRN_SchemeAuditShopDetails.Find(id);
            if (tRN_SchemeAuditShopDetails == null)
            {
                return NotFound();
            }

            return Ok(tRN_SchemeAuditShopDetails);
        }

        // PUT: api/SchemeAuditShopDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTRN_SchemeAuditShopDetails(int id, TRN_SchemeAuditShopDetails tRN_SchemeAuditShopDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tRN_SchemeAuditShopDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(tRN_SchemeAuditShopDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRN_SchemeAuditShopDetailsExists(id))
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

        // POST: api/SchemeAuditShopDetails
        [ResponseType(typeof(TRN_SchemeAuditShopDetails))]
        public IHttpActionResult PostTRN_SchemeAuditShopDetails(TRN_SchemeAuditShopDetails TRN_SchemeAuditShopDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Number = db.TRN_SchemeAuditShopDetails.Where(x => x.Number == TRN_SchemeAuditShopDetails.Number).Select(x => x.Number);

            if (Number.Count() > 0)
            {
                return BadRequest("Data Allready added");
            }
            else
            {
                db.TRN_SchemeAuditShopDetails.Add(TRN_SchemeAuditShopDetails);
                db.SaveChanges();
            }
            return CreatedAtRoute("DefaultApi", new { id = TRN_SchemeAuditShopDetails.Id }, TRN_SchemeAuditShopDetails);
            // return BadRequest("Data Added Successfuly");
        }
        // POST: api/SchemeAuditShopDetails
        //[ResponseType(typeof(TRN_SchemeAuditShopDetails_Test))]
        //public IHttpActionResult PostTRN_SchemeAuditShopDetails(TRN_SchemeAuditShopDetails_Test TRN_SchemeAuditShopDetails)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //   // var Number = db.TRN_SchemeAuditShopDetails.Where(x => x.Number == TRN_SchemeAuditShopDetails.Number).Select(x => x.Number);
        //   // if (TRN_SchemeAuditShopDetails.Number.Substring(0, 3) == "205" || TRN_SchemeAuditShopDetails.Number.Substring(0, 3) == "209" || TRN_SchemeAuditShopDetails.Number.Substring(0, 3) == "212")
        //    {
        //        db.TRN_SchemeAuditShopDetails_Test.Add(TRN_SchemeAuditShopDetails);
        //        db.SaveChanges();
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = TRN_SchemeAuditShopDetails.Id }, TRN_SchemeAuditShopDetails);
        //    // return BadRequest("Data Added Successfuly");
        //}
        // DELETE: api/SchemeAuditShopDetails/5
        [ResponseType(typeof(TRN_SchemeAuditShopDetails))]
        public IHttpActionResult DeleteTRN_SchemeAuditShopDetails(int id)
        {
            TRN_SchemeAuditShopDetails tRN_SchemeAuditShopDetails = db.TRN_SchemeAuditShopDetails.Find(id);
            if (tRN_SchemeAuditShopDetails == null)
            {
                return NotFound();
            }

            db.TRN_SchemeAuditShopDetails.Remove(tRN_SchemeAuditShopDetails);
            db.SaveChanges();

            return Ok(tRN_SchemeAuditShopDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TRN_SchemeAuditShopDetailsExists(int id)
        {
            return db.TRN_SchemeAuditShopDetails.Count(e => e.Id == id) > 0;
        }
    }
}