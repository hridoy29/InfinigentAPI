
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;

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
