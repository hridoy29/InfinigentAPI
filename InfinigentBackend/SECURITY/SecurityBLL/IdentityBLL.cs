
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class IdentityBLL //: IDisposible
    {
            public IdentityBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _IdentityDAO = new IdentityDAO();
            }

        public IdentityDAO _IdentityDAO { get; set; }





     


        public async Task<List<LU_Identity>> GetIdentities()
        {
            try
            {
                return await _IdentityDAO.GetIdentities();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
