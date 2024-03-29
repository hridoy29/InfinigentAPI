using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public async Task<List<LU_Asset_Config>> GetAssetConfigsByDistributorId(string DistributorId)
        {
            try
            {
                var ad_ItemLst = new List<LU_Asset_Config>();
                Parameters[] colparameters = new Parameters[1]{
                new Parameters("@DistributorId", DistributorId, DbType.String, ParameterDirection.Input)
                };

                ad_ItemLst = dbExecutor.FetchData<LU_Asset_Config>(CommandType.StoredProcedure, "get_assetconfigs_by_distributorId", colparameters);

                return ad_ItemLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<AssetConfigGetPagedView> GetPagedAssetConfigs(int startRow,int rowCount)
        {
            try
            {
                int row=0;
                AssetConfigGetPagedView assetConfigGetPagedViews = new AssetConfigGetPagedView();
                Parameters[] colparameters = new Parameters[2]{
                new Parameters("@StartRecordNo", startRow, DbType.Int32, ParameterDirection.Input),
                new Parameters("@RowPerPage", rowCount, DbType.Int32, ParameterDirection.Input)
                };
                var assetConfigs = dbExecutor.FetchDataRef<LU_Asset_Config>(CommandType.StoredProcedure, "LU_AsserConfigGetPaged", colparameters, ref row);

                assetConfigGetPagedViews.Asset_Configs = assetConfigs;
                assetConfigGetPagedViews.TotalCount = row;


                return assetConfigGetPagedViews;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> PostAssetConfigs(AssetConfigTransaction assetConfigTransaction)
        {
            try
            {
                var ret = 0;

                SqlTransaction objTrans = null;


                SqlConnection sqlCon = null;
                String SqlconString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;


                using (sqlCon = new SqlConnection(SqlconString))
                {
                    try
                    {
                        sqlCon.Open();
                        objTrans = sqlCon.BeginTransaction();

                        SqlCommand sql_cmndQ = new SqlCommand("wsp_LU_Asset_Config_Post", sqlCon, objTrans);
                        sql_cmndQ.CommandType = CommandType.StoredProcedure;



                        sql_cmndQ.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = assetConfigTransaction.LU_Asset_Config.Id;
                        sql_cmndQ.Parameters.AddWithValue("@paramAssetNumber", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.AssetNumber;
                        sql_cmndQ.Parameters.AddWithValue("@paramSerialNumber", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.SerialNumber;
                        sql_cmndQ.Parameters.AddWithValue("@paramDistributorId", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.DistributorId;
                        sql_cmndQ.Parameters.AddWithValue("@paramDistributorName", SqlDbType.VarChar).Value = assetConfigTransaction.LU_Asset_Config.DistributorName;
                        sql_cmndQ.Parameters.AddWithValue("@paramAICName", SqlDbType.VarChar).Value = assetConfigTransaction.LU_Asset_Config.AICName;
                        sql_cmndQ.Parameters.AddWithValue("@paramASMName", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.ASMName;
                        sql_cmndQ.Parameters.AddWithValue("@paramMDOId", SqlDbType.VarChar).Value = assetConfigTransaction.LU_Asset_Config.MDOId;
                        sql_cmndQ.Parameters.AddWithValue("@paramMDOName", SqlDbType.VarChar).Value = assetConfigTransaction.LU_Asset_Config.MDOName;
                        sql_cmndQ.Parameters.AddWithValue("@paramOutletId", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.OutletId;
                        sql_cmndQ.Parameters.AddWithValue("@paramOutletName", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.OutletName;
                        sql_cmndQ.Parameters.AddWithValue("@paramOutletAddress", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.OutletAddress;
                        sql_cmndQ.Parameters.AddWithValue("@paramContactNo", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.ContactNo;
                        sql_cmndQ.Parameters.AddWithValue("@paramCoolerModel", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.CoolerModel;
                        sql_cmndQ.Parameters.AddWithValue("@paramNightCover", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.NightCover;
                        sql_cmndQ.Parameters.AddWithValue("@paramIsRepeated", SqlDbType.Bit).Value = assetConfigTransaction.LU_Asset_Config.IsRepeated;
                        sql_cmndQ.Parameters.AddWithValue("@paramIsUpdated", SqlDbType.Bit).Value = assetConfigTransaction.LU_Asset_Config.IsUpdated;
                        sql_cmndQ.Parameters.AddWithValue("@paramDeviceNumber", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config.Device_Number;


                        sql_cmndQ.Parameters.AddWithValue("@paramIsCancelled", SqlDbType.Bit).Value = false;
                        sql_cmndQ.Parameters.AddWithValue("@paramCreatorId", SqlDbType.Int).Value = assetConfigTransaction.LU_Asset_Config.CreatorId;
                        sql_cmndQ.Parameters.AddWithValue("@paramCreationDate", SqlDbType.DateTime).Value = DateTime.Now;
                        sql_cmndQ.Parameters.AddWithValue("@paramModifierId", SqlDbType.Int).Value = assetConfigTransaction.LU_Asset_Config.CreatorId;
                        sql_cmndQ.Parameters.AddWithValue("@paramModificationDate", SqlDbType.DateTime).Value = DateTime.Now;
                        sql_cmndQ.Parameters.AddWithValue("@paramTransactionType", SqlDbType.NVarChar).Value = "UPDATE";
                        sql_cmndQ.ExecuteNonQuery();



                        SqlCommand sql_cmndQD = new SqlCommand("wsp_LU_AssetConfigPhotos_Post", sqlCon, objTrans);
                        sql_cmndQD.CommandType = CommandType.StoredProcedure;
                        sql_cmndQD.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = assetConfigTransaction.LU_Asset_Config_Photos.Id;
                        sql_cmndQD.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config_Photos.AssetNumber;
                        sql_cmndQD.Parameters.AddWithValue("@paramShopImage", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config_Photos.ShopImage;
                        sql_cmndQD.Parameters.AddWithValue("@paramAssetImage", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config_Photos.AssetImage;
                        sql_cmndQD.Parameters.AddWithValue("@paramSignImage", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config_Photos.SignImage;
                        sql_cmndQD.Parameters.AddWithValue("@paramCoolerImage", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config_Photos.CoolerImage;
                        sql_cmndQD.Parameters.AddWithValue("@paramShortNote", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config_Photos.ShortNote;
                        sql_cmndQD.Parameters.AddWithValue("@paramRemarks", SqlDbType.NVarChar).Value = assetConfigTransaction.LU_Asset_Config_Photos.Remarks;

                        sql_cmndQD.ExecuteNonQuery();



                        objTrans.Commit();


                        sqlCon.Close();
                        ret = 1;
                        
                    }

                    catch (Exception ex)
                    {

                        objTrans.Rollback();
                        sqlCon.Close();
                        ret = 0;
                        throw ex;
                    }
                    finally
                    {
                        sqlCon.Close();
                        
                    }
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
   
}