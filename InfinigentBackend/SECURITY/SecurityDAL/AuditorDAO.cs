using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class AuditorDAO
    {
        private static volatile AuditorDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public AuditorDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static AuditorDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new AuditorDAO();
                    }

                return instance;
            }
        }

        public static AuditorDAO GetInstance()
        {
            if (instance == null) instance = new AuditorDAO();
            return instance;
        }


        public async Task<List<Auditor>> GetAuditors()
        {
            try
            {

                var auditorList = new List<Auditor>();

                auditorList = dbExecutor.FetchData<Auditor>(CommandType.StoredProcedure, "get_auditors");

                return auditorList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


  
        public async Task<Auditor> GetAuditorInfo(string userEmail)
        {
            try
            {

                var colparameters = new Parameters[1]
                {
                     new Parameters("@UserEmail", userEmail, DbType.String,
                        ParameterDirection.Input)

                        };
                var ad_ItemLst = new List <Auditor>();
                var auditor = new Auditor();
                ad_ItemLst =   dbExecutor.FetchData<Auditor>(CommandType.StoredProcedure, "GetAuditorInfo",colparameters);
                if (ad_ItemLst.Count > 0)
                {
                    
                    auditor = ad_ItemLst[0];
                }
                return auditor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public List<ad_Item> GetDynamic(string whereCondition, string orderByExpression)
        //{
        //    try
        //    {
        //        var ad_PaymentGroupLst = new List<ad_Item>();
        //        var colparameters = new Parameters[2]
        //        {
        //            new Parameters("@WhereCondition", whereCondition, DbType.String, ParameterDirection.Input),
        //            new Parameters("@OrderByExpression", orderByExpression, DbType.String, ParameterDirection.Input)
        //        };
        //        ad_PaymentGroupLst = dbExecutor.FetchData<ad_Item>(CommandType.StoredProcedure,
        //            "ad_Item_GetDynamic", colparameters);
        //        return ad_PaymentGroupLst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<ad_Item> GetPaged(int startRecordNo, int rowPerPage, string whereClause, string sortColumn,
        //   string sortOrder, ref int rows)
        //{
        //    try
        //    {
        //        var ad_BankLst = new List<ad_Item>();
        //        var colparameters = new Parameters[5]
        //        {
        //            new Parameters("@StartRecordNo", startRecordNo, DbType.Int32, ParameterDirection.Input),
        //            new Parameters("@RowPerPage", rowPerPage, DbType.Int32, ParameterDirection.Input),
        //            new Parameters("@WhereClause", whereClause, DbType.String, ParameterDirection.Input),
        //            new Parameters("@SortColumn", sortColumn, DbType.String, ParameterDirection.Input),
        //            new Parameters("@SortOrder", sortOrder, DbType.String, ParameterDirection.Input)
        //        };
        //        ad_BankLst = dbExecutor.FetchDataRef<ad_Item>(CommandType.StoredProcedure, "ad_Item_GetPaged",
        //            colparameters, ref rows);
        //        return ad_BankLst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}