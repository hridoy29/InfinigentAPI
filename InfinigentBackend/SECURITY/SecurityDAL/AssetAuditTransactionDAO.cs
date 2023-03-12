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
    public class AssetAuditTransactionDAO
    {
        private static volatile AssetAuditTransactionDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public AssetAuditTransactionDAO()
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

        public async Task<int> Post(AssetAuditTransaction _Transaction)
        {
            var ret = 0;

            //string folder = @"C:\Temp\";
            //// Filename  
            //string fileName = "Log.txt";
            //// Fullpath. You can direct hardcode it if you like.  
            //string fullPath = folder + fileName;

            SqlTransaction objTrans = null;
         
               
                SqlConnection sqlCon = null;
                String SqlconString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
              

                using (sqlCon = new SqlConnection(SqlconString))
                {
                    try
                    {
                    sqlCon.Open();
                    objTrans = sqlCon.BeginTransaction();

                    SqlCommand sql_cmndQ = new SqlCommand("wsp_TRN_AssetAudit_Post", sqlCon,objTrans);
                    sql_cmndQ.CommandType = CommandType.StoredProcedure;


 

                    sql_cmndQ.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Transaction.TRN_AssetAudit.Number;
                    sql_cmndQ.Parameters.AddWithValue("@paramAssetInfoId", SqlDbType.Int).Value = _Transaction.TRN_AssetAudit.AssetInfoId;
                    sql_cmndQ.Parameters.AddWithValue("@paramIsMDONameCorrect", SqlDbType.Bit).Value = _Transaction.TRN_AssetAudit.IsMDONameCorrect;
                    sql_cmndQ.Parameters.AddWithValue("@paramMDONameShortNote", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.MDONameShortNote;
                    sql_cmndQ.Parameters.AddWithValue("@paramMDONameRemarks", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.MDONameRemarks;
                    sql_cmndQ.Parameters.AddWithValue("@paramIsMDOIdCorrect", SqlDbType.Bit).Value = _Transaction.TRN_AssetAudit.IsMDOIdCorrect;
                    sql_cmndQ.Parameters.AddWithValue("@paramMDOIdShortNote", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.MDOIdShortNote;
                    sql_cmndQ.Parameters.AddWithValue("@paramMDOIdRemarks", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.MDOIdRemarks;
                    sql_cmndQ.Parameters.AddWithValue("@paramIsOutletIdCorrect", SqlDbType.Bit).Value = _Transaction.TRN_AssetAudit.IsOutletIdCorrect;
                    sql_cmndQ.Parameters.AddWithValue("@paramOutletIdShortNote", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.OutletIdShortNote;
                    sql_cmndQ.Parameters.AddWithValue("@paramOutletIdRemarks", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.OutletIdRemarks;
                    sql_cmndQ.Parameters.AddWithValue("@paramIsOutletNameCorrect", SqlDbType.Bit).Value = _Transaction.TRN_AssetAudit.IsOutletNameCorrect;
                    sql_cmndQ.Parameters.AddWithValue("@paramOutletNameShortNote", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.OutletNameShortNote;
                    sql_cmndQ.Parameters.AddWithValue("@paramOutletNameRemarks", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.OutletNameRemarks;
                    sql_cmndQ.Parameters.AddWithValue("@paramIsOutletAddressCorrect", SqlDbType.Bit).Value = _Transaction.TRN_AssetAudit.IsOutletAddressCorrect;
                    sql_cmndQ.Parameters.AddWithValue("@paramOutletAddressShortNote", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.OutletAddressShortNote;
                    sql_cmndQ.Parameters.AddWithValue("@paramOutletAddressRemarks", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.OutletAddressRemarks;
                    sql_cmndQ.Parameters.AddWithValue("@paramIsContactNumberCorrect", SqlDbType.Bit).Value = _Transaction.TRN_AssetAudit.IsContactNumberCorrect;
                    sql_cmndQ.Parameters.AddWithValue("@paramContactNumberShortNote", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.ContactNumberShortNote;
                    sql_cmndQ.Parameters.AddWithValue("@paramContactNumberRemarks", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.ContactNumberRemarks;
                    sql_cmndQ.Parameters.AddWithValue("@paramIsCoolerModelCorrect", SqlDbType.Bit).Value = _Transaction.TRN_AssetAudit.IsCoolerModelCorrect;
                    sql_cmndQ.Parameters.AddWithValue("@paramCoolerModelShortNote", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.CoolerModelShortNote;
                    sql_cmndQ.Parameters.AddWithValue("@paramCoolerModelRemarks", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.CoolerModelRemarks;
                    sql_cmndQ.Parameters.AddWithValue("@paramIsAssetNumberCorrect", SqlDbType.Bit).Value = _Transaction.TRN_AssetAudit.IsAssetNumberCorrect;
                    sql_cmndQ.Parameters.AddWithValue("@paramAssetNumberShortNote", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.AssetNumberShortNote;
                    sql_cmndQ.Parameters.AddWithValue("@paramAssetNumberRemarks", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.AssetNumberRemarks;
                    sql_cmndQ.Parameters.AddWithValue("@paramIsSerialNumberCorrect", SqlDbType.Bit).Value = _Transaction.TRN_AssetAudit.IsSerialNumberCorrect;
                    sql_cmndQ.Parameters.AddWithValue("@paramSerialNumberShortNote", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.SerialNumberShortNote;
                    sql_cmndQ.Parameters.AddWithValue("@paramSerialNumberNumberRemarks", SqlDbType.VarChar).Value = _Transaction.TRN_AssetAudit.SerialNumberRemarks;
                    sql_cmndQ.Parameters.AddWithValue("@paramUserId", SqlDbType.Int).Value = _Transaction.TRN_AssetAudit.CreatorId;


                    sql_cmndQ.ExecuteNonQuery();



                    SqlCommand sql_cmndQD = new SqlCommand("wsp_TRN_AssetAuditPhotos_Post", sqlCon, objTrans);
                    sql_cmndQD.CommandType = CommandType.StoredProcedure;
                    sql_cmndQD.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Transaction.TRN_AssetAuditPhotos.Number;
                    sql_cmndQD.Parameters.AddWithValue("@paramShopImage", SqlDbType.NVarChar).Value = _Transaction.TRN_AssetAuditPhotos.ShopImage;
                    sql_cmndQD.Parameters.AddWithValue("@paramAssetImage", SqlDbType.NVarChar).Value = _Transaction.TRN_AssetAuditPhotos.AssetImage;
                    sql_cmndQD.Parameters.AddWithValue("@paramSignImage", SqlDbType.NVarChar).Value = _Transaction.TRN_AssetAuditPhotos.SignImage;

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
            }


            // }

            // An array of strings  
            //string[] text = { "Test Log  ", ret+"" };
            //// Write array of strings to a file using WriteAllLines.  
            //// If the file does not exists, it will create a new file.  
            //// This method automatically opens the file, writes to it, and closes file  
            //File.WriteAllLines(fullPath, text);

            return ret;
        }



     

    }
}