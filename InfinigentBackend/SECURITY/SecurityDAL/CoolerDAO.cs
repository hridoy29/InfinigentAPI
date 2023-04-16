using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class CoolerDAO
    {
        private static volatile CoolerDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public CoolerDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static CoolerDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new CoolerDAO();
                    }

                return instance;
            }
        }

        public static CoolerDAO GetInstance()
        {
            if (instance == null) instance = new CoolerDAO();
            return instance;
        }

      
      
        public async Task<List<LU_Cooler>> GetCoolers()
        {
            try
            {

               
                var ad_ItemLst = new List<LU_Cooler>();
             
                ad_ItemLst =  dbExecutor.FetchData<LU_Cooler>(CommandType.StoredProcedure, "get_coolers");
                
                return ad_ItemLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


     
    }
}