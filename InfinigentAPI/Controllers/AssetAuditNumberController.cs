﻿using System;
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
    public class AssetAuditNumberController : ApiController
    {
        private qt_infinigentdbEntities db = new qt_infinigentdbEntities();

        // GET: api/Identity
        [ResponseType(typeof(InfinigentBackend.SECURITY.SecurityEntity.TRN_AssetAuditNumber))]
        public async Task<IHttpActionResult> GetQuestionnaireNumbersAsync()
        {

            try
            {

                var list = await Facade.AssetAuditNumberBLL.GetAssetAuditNumbers();

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

        // POST: api/QuestionnaireTransaction
        [ResponseType(typeof(InfinigentBackend.SECURITY.SecurityEntity.TRN_AssetAuditNumber))]

        [HttpPost]

        public async Task<IHttpActionResult> PostAssetAuditNumber(InfinigentBackend.SECURITY.SecurityEntity.TRN_AssetAuditNumber number)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var result = Facade.AssetAuditNumberBLL.Post(number);
                int ret = await result;
                if (ret != 0)
                {
                    return Ok(number);
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

      
    }
}