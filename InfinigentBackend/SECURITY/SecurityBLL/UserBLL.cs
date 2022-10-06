
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class UserBLL //: IDisposible
    {
            public UserBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _UserDAO = new UserDAO();
            }

        public UserDAO _UserDAO { get; set; }





      


        public async Task<List<LU_User>> GetUsers()
        {
            try
            {
                return await _UserDAO.GetUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
