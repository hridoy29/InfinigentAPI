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
    public class AssetConfigController : ApiController
    {
        private qt_infinigentdbEntities1 db = new qt_infinigentdbEntities1();

        // GET: api/ShortNote
        [ResponseType(typeof(InfinigentBackend.SECURITY.SecurityEntity.LU_Asset_Config))]
        public async Task<IHttpActionResult> GetAssetConfigsAsync()
        {

            try
            {

                var list = await Facade.AssetConfigBLL.GetAssetConfigs();

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
        public async Task<IHttpActionResult> GetPagedAssetConfigs(int startRow, int rowCount)
        {

            try
            {

                var list = await Facade.AssetConfigBLL.GetPagedAssetConfigs(startRow, rowCount);

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

        public async Task<IHttpActionResult> GetAssetConfigsByDistributorId(string DistributorId)
        {

            try
            {

                var list = await Facade.AssetConfigBLL.GetAssetConfigsByDistributorId(DistributorId);

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


        [ResponseType(typeof(AssetConfigTransaction))]
        public async Task<IHttpActionResult> PostAssetConfigsAsync(AssetConfigTransaction assetConfigTransaction)
        {

            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var list = await Facade.AssetConfigBLL.PostAssetConfigs(assetConfigTransaction);

                return Ok(list);

            }
            catch (Exception ex)
            {
                return NotFound();

            }

        }
    }
}