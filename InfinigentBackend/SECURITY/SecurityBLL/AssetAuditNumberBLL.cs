
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class AssetAuditNumberBLL //: IDisposible
    {
            public AssetAuditNumberBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _AssetAuditNumberDAO = new AssetAuditNumberDAO();
            }

        public AssetAuditNumberDAO _AssetAuditNumberDAO { get; set; }





     


        public async Task<List<TRN_AssetAuditNumber>> GetAssetAuditNumbers()
        {
            try
            {
                return await _AssetAuditNumberDAO.GetAssetAuditNumbers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> Post(TRN_AssetAuditNumber _Number)
        {
            try
            {
                return await _AssetAuditNumberDAO.Post(_Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
