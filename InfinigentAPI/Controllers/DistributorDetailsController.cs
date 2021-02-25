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
    public class DistributorDetailsController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/DistributorDetails
        public IQueryable<LU_DistributorDetails> GetLU_DistributorDetails()
        {

          /* // IQueryable<LU_DistributorDetails> _LU_DistributorDetails;
         //  var  _LU_DistributorDetails= db.LU_DistributorDetails.Where(store => store.IsActive == true)
          // .Select(store => new LU_DistributorDetails { Id = store.Id,Name = store.Name +"("+store.Id.ToString() +")", CreatorId=store.CreatorId,CreationDate=store.CreationDate,ModifierId=store.ModifierId,ModificationDate=store.ModificationDate,IsActive =store.IsActive });
            var books = from store in db.LU_DistributorDetails
                        select new LU_DistributorDetails()
                        {
                            Id = store.Id,
                            Name = store.Name + "(" + store.Id.ToString() + ")",
                            CreatorId = store.CreatorId,
                            CreationDate = store.CreationDate,
                            ModifierId = store.ModifierId,
                            ModificationDate = store.ModificationDate,
                            IsActive = store.IsActive
                        };*/

            return db.LU_DistributorDetails.Where(x => x.IsActive == true); 
        }

        // GET: api/DistributorDetails/5
        [ResponseType(typeof(LU_DistributorDetails))]
        public IHttpActionResult GetLU_DistributorDetails(int id)
        {
            LU_DistributorDetails lU_DistributorDetails = db.LU_DistributorDetails.Find(id);
            if (lU_DistributorDetails == null)
            {
                return NotFound();
            }

            return Ok(lU_DistributorDetails);
        }

        // PUT: api/DistributorDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLU_DistributorDetails(int id, LU_DistributorDetails lU_DistributorDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lU_DistributorDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(lU_DistributorDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LU_DistributorDetailsExists(id))
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

        // POST: api/DistributorDetails
        [ResponseType(typeof(LU_DistributorDetails))]
        public IHttpActionResult PostLU_DistributorDetails(LU_DistributorDetails lU_DistributorDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LU_DistributorDetails.Add(lU_DistributorDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lU_DistributorDetails.Id }, lU_DistributorDetails);
        }

        // DELETE: api/DistributorDetails/5
        [ResponseType(typeof(LU_DistributorDetails))]
        public IHttpActionResult DeleteLU_DistributorDetails(int id)
        {
            LU_DistributorDetails lU_DistributorDetails = db.LU_DistributorDetails.Find(id);
            if (lU_DistributorDetails == null)
            {
                return NotFound();
            }

            db.LU_DistributorDetails.Remove(lU_DistributorDetails);
            db.SaveChanges();

            return Ok(lU_DistributorDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LU_DistributorDetailsExists(int id)
        {
            return db.LU_DistributorDetails.Count(e => e.Id == id) > 0;
        }
    }
}