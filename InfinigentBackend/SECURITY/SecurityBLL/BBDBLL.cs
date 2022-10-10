
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class BBDBLL //: IDisposible
    {
            public BBDBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _BBDDAO = new BBDDAO();
            }

        public BBDDAO _BBDDAO { get; set; }





     


        public async Task<List<LU_BBD>> GetBBDs()
        {
            try
            {
                return await _BBDDAO.GetBBDs();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
