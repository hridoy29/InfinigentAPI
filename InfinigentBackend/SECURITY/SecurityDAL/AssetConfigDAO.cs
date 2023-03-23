using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class AssetConfigDAO
    {
        private static volatile AssetConfigDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public AssetConfigDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static AssetConfigDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new AssetConfigDAO();
                    }

                return instance;
            }
        }

        public static AssetConfigDAO GetInstance()
        {
            if (instance == null) instance = new AssetConfigDAO();
            return instance;
        }

      
        public async Task<List<LU_Asset_Config>> GetAssetConfigs()
        {
            try
            {

               
                var ad_ItemLst = new List<LU_Asset_Config>();
             
                ad_ItemLst =  dbExecutor.FetchData<LU_Asset_Config>(CommandType.StoredProcedure, "get_assetconfigs");
                
                return ad_ItemLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


     
    }
}