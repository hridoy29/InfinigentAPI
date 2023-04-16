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
using InfinigentBackend.SECURITY.SecurityEntity;
using SecurityBLL;

namespace InfinigentAPI.Controllers
{
    public class CoolerController : ApiController
    {
       

        // GET: api/ShortNote
        [ResponseType(typeof(LU_Cooler))]
        public async Task<IHttpActionResult> GetCoolerAsync()
        {

            try
            {

                var list = await Facade.CoolerBLL.GetCoolers();

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

     
       

       
    }
}