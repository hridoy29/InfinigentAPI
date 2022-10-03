
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class IssuesBLL //: IDisposible
    {
            public IssuesBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _IssuesDAO = new IssuesDAO();
            }

        public IssuesDAO _IssuesDAO { get; set; }





        public async Task<Auditor> GetAuditorInfo(string userEmail)
        {
            try
            {
                return await _IssuesDAO.GetAuditorInfo(userEmail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<LU_Issues>> GetIssues()
        {
            try
            {
                return await _IssuesDAO.GetIssues();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
