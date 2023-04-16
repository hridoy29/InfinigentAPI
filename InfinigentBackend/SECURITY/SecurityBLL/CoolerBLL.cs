
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class CoolerBLL //: IDisposible
    {
            public CoolerBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _CoolerDAO = new CoolerDAO();
            }

        public CoolerDAO _CoolerDAO { get; set; }





      

        public async Task<List<LU_Cooler>> GetCoolers()
        {
            try
            {
                return await _CoolerDAO.GetCoolers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
