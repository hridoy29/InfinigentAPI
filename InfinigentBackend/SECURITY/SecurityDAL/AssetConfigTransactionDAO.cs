using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class AssetConfigTransactionDAO
    {
        private static volatile AssetAuditTransactionDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public AssetConfigTransactionDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static AssetAuditTransactionDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new AssetAuditTransactionDAO();
                    }

                return instance;
            }
        }

        public static AssetAuditTransactionDAO GetInstance()
        {
            if (instance == null) instance = new AssetAuditTransactionDAO();
            return instance;
        }

        public async Task<int> Post(AssetConfigTransaction assetConfigTransaction)
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

                        SqlCommand sql_cmndQ = new SqlCommand("wsp_LU_Asset_Config_Post_For_Api", sqlCon, objTrans);
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
                        sql_cmndQ.Parameters.AddWithValue("@paramTransactionType", SqlDbType.NVarChar).Value = assetConfigTransaction.TransactionType;
                        var id = sql_cmndQ.ExecuteScalar();
                        var AssetConfigId = assetConfigTransaction.LU_Asset_Config_Photos.AssetConfigId;
                        if (assetConfigTransaction.TransactionType=="INSERT")
                        {
                            AssetConfigId = (int)id;
                        }

                        SqlCommand sql_cmndQD = new SqlCommand("wsp_LU_AssetConfigPhotos_Post", sqlCon, objTrans);
                        sql_cmndQD.CommandType = CommandType.StoredProcedure;
                        sql_cmndQD.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = assetConfigTransaction.LU_Asset_Config_Photos.Id;
                        sql_cmndQD.Parameters.AddWithValue("@paramAssetConfigId", SqlDbType.Int).Value = AssetConfigId;
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