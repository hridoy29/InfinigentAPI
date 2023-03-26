
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
    public class AssetDistributorBLL //: IDisposible
    {
        public AssetDistributorBLL()
        {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _AssetDistributorDAO = new AssetDistributorDAO();
        }

        public AssetDistributorDAO _AssetDistributorDAO { get; set; }


        public async Task<List<AssetDistributor>> GetAssetDistributors()
        {
            try
            {
                return await _AssetDistributorDAO.GetAssetDistributors();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
      
        

    

}
