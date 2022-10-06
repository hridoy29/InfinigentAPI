using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class UserDAO
    {
        private static volatile UserDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public UserDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static UserDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new UserDAO();
                    }

                return instance;
            }
        }

        public static UserDAO GetInstance()
        {
            if (instance == null) instance = new UserDAO();
            return instance;
        }

        //public int Add(LU_User _Item)
        //{
        //    var ret = 0;
        //    try
        //    {
        //        var colparameters = new Parameters[13]
        //        {
        //             new Parameters("@Id", _Item.Id, DbType.Int32,
        //                ParameterDirection.Input),
        //             new Parameters("@ItemCode", _Item.ItemCode, DbType.String,
        //                ParameterDirection.Input),
        //             new Parameters("@ProductName", _Item.ProductName, DbType.String,
        //                ParameterDirection.Input),
        //             new Parameters("@ModelId", _Item.ModelId, DbType.Int32,
        //                ParameterDirection.Input),
        //             new Parameters("@ItemGroupId", _Item.ItemGroupId, DbType.Int32,
        //                ParameterDirection.Input),
        //             new Parameters("@MeasureUnitId", _Item.MeasureUnitId, DbType.Int32,
        //                ParameterDirection.Input),
        //             new Parameters("@PurchaseVatId", _Item.PurchaseVatId, DbType.Int32,
        //                ParameterDirection.Input),
        //             new Parameters("@SupplimentaryDutyId", _Item.SupplimentaryDutyId, DbType.Int32,
        //                ParameterDirection.Input),
        //             new Parameters("@HasExpiry", _Item.HasExpiry, DbType.Boolean, ParameterDirection.Input),
        //             new Parameters("@ROL", _Item.ROL, DbType.Decimal, ParameterDirection.Input),
        //             new Parameters("@IsActive", _Item.IsActive, DbType.Decimal, ParameterDirection.Input),
        //             new Parameters("@CreatorId", _Item.CreatorId, DbType.Int32, ParameterDirection.Input),
        //             new Parameters("@UpdatorId", _Item.UpdatorId, DbType.Int32, ParameterDirection.Input)

        //        };
        //        dbExecutor.ManageTransaction(TransactionType.Open);
        //        ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "ad_Item_Post",
        //            colparameters, true);
        //        dbExecutor.ManageTransaction(TransactionType.Commit);
        //    }
        //    catch (DBConcurrencyException except)
        //    {
        //        dbExecutor.ManageTransaction(TransactionType.Rollback);
        //        throw except;
        //    }
        //    catch (Exception ex)
        //    {
        //        dbExecutor.ManageTransaction(TransactionType.Rollback);
        //        throw ex;
        //    }

        //    return ret;
        //}
        //public List<ad_Item> GetAll()
        //{
        //    try
        //    {
        //        var ad_ItemLst = new List<ad_Item>();
        //        ad_ItemLst =
        //            dbExecutor.FetchData<ad_Item>(CommandType.StoredProcedure, "ad_Item_GetAllActive");
        //        return ad_ItemLst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
      

        public async Task<List<LU_User>> GetUsers()
        {
            try
            {

               
                var ad_ItemLst = new List<LU_User>();
             
                ad_ItemLst = dbExecutor.FetchData<LU_User>(CommandType.StoredProcedure, "wsp_UserList_Get");
                
                return ad_ItemLst;
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