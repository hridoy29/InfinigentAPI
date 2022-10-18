using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class IdentityDAO
    {
        private static volatile IdentityDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public IdentityDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static IdentityDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new IdentityDAO();
                    }

                return instance;
            }
        }

        public static IdentityDAO GetInstance()
        {
            if (instance == null) instance = new IdentityDAO();
            return instance;
        }

   
     
        public async Task<List<LU_Identity>> GetIdentities()
        {
            try
            {

                var identityList = new List<LU_Identity>();

                identityList = dbExecutor.FetchData<LU_Identity>(CommandType.StoredProcedure, "get_identities");
                
                return identityList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}