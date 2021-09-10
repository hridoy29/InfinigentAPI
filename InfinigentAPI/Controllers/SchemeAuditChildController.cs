using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
 
using InfinigentAPI.Models;
 

namespace InfinigentAPI.Controllers
{
    public class SchemeAuditChildController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/SchemeAuditChild
        public IQueryable<TRN_SchemeAuditChild> GetTRN_SchemeAuditChild()
        {
            return db.TRN_SchemeAuditChild;
        }

        // GET: api/SchemeAuditChild/5
        [ResponseType(typeof(TRN_SchemeAuditChild))]
        public IHttpActionResult GetTRN_SchemeAuditChild(int id)
        {
            TRN_SchemeAuditChild tRN_SchemeAuditChild = db.TRN_SchemeAuditChild.Find(id);
            if (tRN_SchemeAuditChild == null)
            {
                return NotFound();
            }

            return Ok(tRN_SchemeAuditChild);
        }

        // PUT: api/SchemeAuditChild/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTRN_SchemeAuditChild(int id, TRN_SchemeAuditChild tRN_SchemeAuditChild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tRN_SchemeAuditChild.Id)
            {
                return BadRequest();
            }

            db.Entry(tRN_SchemeAuditChild).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRN_SchemeAuditChildExists(id))
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

        // POST: api/SchemeAuditChild
        [ResponseType(typeof(TRN_SchemeAuditChild))]
        public async Task<IHttpActionResult> PostTRN_SchemeAuditChild(TRN_SchemeAuditChild tRN_SchemeAuditChild)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                string _imagePath = string.Empty;
                SaveImages saveImages = new SaveImages();
                
                 _imagePath = saveImages.isImageSaved(tRN_SchemeAuditChild);
                var ImageLocation = db.TRN_SchemeAuditChild.Where(x => x.ImageLocation == _imagePath).Select(x => x.ImageLocation);                
                if (ImageLocation.Count() > 0)
                {
                    return BadRequest("Data Allready added");
                }
                else
                {
                    if (_imagePath.Length != 0)
                    {
                        tRN_SchemeAuditChild.ImageLocation = string.Empty;
                        tRN_SchemeAuditChild.ImageLocation = _imagePath;
                        db.TRN_SchemeAuditChild.Add(tRN_SchemeAuditChild);
                        await db.SaveChangesAsync();
                    }
                }
                 
                return CreatedAtRoute("DefaultApi", new { id = tRN_SchemeAuditChild.Id }, tRN_SchemeAuditChild);
            }
        }

        // DELETE: api/SchemeAuditChild/5
        [ResponseType(typeof(TRN_SchemeAuditChild))]
        public IHttpActionResult DeleteTRN_SchemeAuditChild(int id)
        {
            TRN_SchemeAuditChild tRN_SchemeAuditChild = db.TRN_SchemeAuditChild.Find(id);
            if (tRN_SchemeAuditChild == null)
            {
                return NotFound();
            }

            db.TRN_SchemeAuditChild.Remove(tRN_SchemeAuditChild);
            db.SaveChanges();

            return Ok(tRN_SchemeAuditChild);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TRN_SchemeAuditChildExists(int id)
        {
            return db.TRN_SchemeAuditChild.Count(e => e.Id == id) > 0;
        }
    }
}