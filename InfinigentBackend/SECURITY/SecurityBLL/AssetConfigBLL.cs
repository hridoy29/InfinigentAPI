
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class AssetConfigBLL //: IDisposible
    {
            public AssetConfigBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _AssetConfigDAO = new AssetConfigDAO();
            }

        public AssetConfigDAO _AssetConfigDAO { get; set; }





      

        public async Task<List<LU_Asset_Config>> GetAssetConfigs()
        {
            try
            {
                return await _AssetConfigDAO.GetAssetConfigs();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
