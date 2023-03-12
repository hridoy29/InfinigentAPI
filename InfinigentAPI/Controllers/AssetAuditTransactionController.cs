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
using InfinigentBackend.SECURITY.SecurityEntity;
using SecurityBLL;

namespace InfinigentAPI.Controllers
{
    public class AssetAuditTransactionController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/SchemeAuditChild
        //public IQueryable<TRN_SchemeAuditChild> GetTRN_SchemeAuditChild()
        //{
        //    return db.TRN_SchemeAuditChild;
        //}

      
        // POST: api/QuestionnaireTransaction
        [ResponseType(typeof(AssetAuditTransaction))]

        [HttpPost]

        public async Task<IHttpActionResult> PostAssetAuditTransaction(AssetAuditTransaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
               

                var result = Facade.AssetAuditTransactionBLL.Post(transaction);
                int ret = await result;
                if(ret != 0)
                {
                  return  Ok(transaction);
                }
                else
                {
                    return BadRequest(ModelState);
                }
               // return CreatedAtRoute("DefaultApi", new { id = questionnaireTransaction.TRN_Questionnaire.Id }, questionnaireTransaction);
            }
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