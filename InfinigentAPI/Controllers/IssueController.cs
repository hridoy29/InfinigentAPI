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
    public class IssueController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/Auditors
        public IQueryable<Issue> GetAuditors()
        {
            return db.Issues;
        }

        // GET: api/Auditors/5
        [ResponseType(typeof(Auditor))]
        public async Task<IHttpActionResult> GetIssues(int id)
        {
            Issue auditor = await db.Issues.FindAsync(id);
            if (auditor == null)
            {
                return NotFound();
            }

            return Ok(auditor);
        }


        // GET: api/Auditors/GetAuditorInfo/userEmail
        [ResponseType(typeof(Auditor))]
        public async Task<IHttpActionResult> GetAuditorInfo(string userEmail)
        {

            try
            {

                var list = await Facade.AuditorBLL.GetAuditorInfo(userEmail);
               
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
               
            }
        }

        // PUT: api/Auditors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuditor(int id, Auditor auditor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auditor.Id)
            {
                return BadRequest();
            }

            db.Entry(auditor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssuesExists(id))
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

        // POST: api/Auditors
        [ResponseType(typeof(Auditor))]
        public async Task<IHttpActionResult> PostAuditor(Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Issues.Add(issue);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = issue.Id }, issue);
        }

        // DELETE: api/Auditors/5
        [ResponseType(typeof(Auditor))]
        public async Task<IHttpActionResult> DeleteAuditor(int id)
        {
            Issue issue = await db.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            db.Issues.Remove(issue);
            await db.SaveChangesAsync();

            return Ok(issue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IssuesExists(int id)
        {
            return db.Issues.Count(e => e.Id == id) > 0;
        }
    }
}