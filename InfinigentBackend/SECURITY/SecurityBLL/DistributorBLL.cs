
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class DistributorBLL //: IDisposible
    {
            public DistributorBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _DistributorDAO = new DistributorDAO();
            }

        public DistributorDAO _DistributorDAO { get; set; }


        public async Task<List<Distributor>> GetDistributors()
        {
            try
            {
                return await _DistributorDAO.GetDistributors();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<Distributor> GetDistributorInfo(string DbCode)
        {
            try
            {
                return await _DistributorDAO.GetDistributorInfo(DbCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        }


      
        

    

}
