using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class AssetAuditNumberDAO
    {
        private static volatile AssetAuditNumberDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public AssetAuditNumberDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static AssetAuditNumberDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new AssetAuditNumberDAO();
                    }

                return instance;
            }
        }

        public static AssetAuditNumberDAO GetInstance()
        {
            if (instance == null) instance = new AssetAuditNumberDAO();
            return instance;
        }

        public async Task<List<TRN_AssetAuditNumber>> GetAssetAuditNumbers()
        {
            try
            {

                var numberList = new List<TRN_AssetAuditNumber>();

                numberList = dbExecutor.FetchData<TRN_AssetAuditNumber>(CommandType.StoredProcedure, "get_asset_audit_numbers");

                return numberList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<int> Post(TRN_AssetAuditNumber _Number)
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

                    SqlCommand sql_cmndQ = new SqlCommand("wsp_TRN_AssetAuditNumber_Post", sqlCon, objTrans);
                    sql_cmndQ.CommandType = CommandType.StoredProcedure;
                    sql_cmndQ.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = _Number.Id;
                    sql_cmndQ.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Number.Number;
                  
                    ret =  sql_cmndQ.ExecuteNonQuery();



                 

                    objTrans.Commit();


                    sqlCon.Close();
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



            return ret;
        }



    }
}