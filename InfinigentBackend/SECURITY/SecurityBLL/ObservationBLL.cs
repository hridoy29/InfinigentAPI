
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class ObservationBLL //: IDisposible
    {
            public ObservationBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ObservationDAO = new ObservationDAO();
            }

        public ObservationDAO _ObservationDAO { get; set; }






        public async Task<List<LU_Observation>> GetObservations()
        {
            try
            {
                return await _ObservationDAO.GetObservations();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
