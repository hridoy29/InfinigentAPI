using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class AssetInfoDAO
    {
        private static volatile AssetInfoDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public AssetInfoDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static AssetInfoDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new AssetInfoDAO();
                    }

                return instance;
            }
        }

        public static AssetInfoDAO GetInstance()
        {
            if (instance == null) instance = new AssetInfoDAO();
            return instance;
        }

      
        public async Task<List<AssetInfo>> GetAssetInfos()
        {
            try
            {

               
                var ad_ItemLst = new List<AssetInfo>();
             
                ad_ItemLst =  dbExecutor.FetchData<AssetInfo>(CommandType.StoredProcedure, "get_assetinfos");
                
                return ad_ItemLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


     
    }
}