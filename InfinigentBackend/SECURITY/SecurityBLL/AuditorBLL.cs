
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class AuditorBLL //: IDisposible
    {
            public AuditorBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _AuditorDAO = new AuditorDAO();
            }

        public AuditorDAO _AuditorDAO { get; set; }





        public async Task<Auditor> GetAuditorInfo(string userEmail)
        {
            try
            {
                return await _AuditorDAO.GetAuditorInfo(userEmail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        }


      
        

    

}
