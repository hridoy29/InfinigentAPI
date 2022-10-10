using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class BBDDAO
    {
        private static volatile BBDDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public BBDDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static BBDDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new BBDDAO();
                    }

                return instance;
            }
        }

        public static BBDDAO GetInstance()
        {
            if (instance == null) instance = new BBDDAO();
            return instance;
        }

   
     
        public async Task<List<LU_BBD>> GetBBDs()
        {
            try
            {

                var bBDList = new List<LU_BBD>();

                bBDList = dbExecutor.FetchData<LU_BBD>(CommandType.StoredProcedure, "get_bbds");
                
                return bBDList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}