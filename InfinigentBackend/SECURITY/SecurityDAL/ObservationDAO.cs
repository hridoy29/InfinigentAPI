using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class ObservationDAO
    {
        private static volatile ObservationDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public ObservationDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static ObservationDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new ObservationDAO();
                    }

                return instance;
            }
        }

        public static ObservationDAO GetInstance()
        {
            if (instance == null) instance = new ObservationDAO();
            return instance;
        }

      
     

        public async Task<List<LU_Observation>> GetObservations()
        {
            try
            {

               
                var observationList = new List<LU_Observation>();

                observationList = dbExecutor.FetchData<LU_Observation>(CommandType.StoredProcedure, "get_observations");
                
                return observationList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


   

    }
}