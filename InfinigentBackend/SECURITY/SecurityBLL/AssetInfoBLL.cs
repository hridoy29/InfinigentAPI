
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class AssetInfoBLL //: IDisposible
    {
            public AssetInfoBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _AssetInfoDAO = new AssetInfoDAO();
            }

        public AssetInfoDAO _AssetInfoDAO { get; set; }





      

        public async Task<List<AssetInfo>> GetAssetInfos()
        {
            try
            {
                return await _AssetInfoDAO.GetAssetInfos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
