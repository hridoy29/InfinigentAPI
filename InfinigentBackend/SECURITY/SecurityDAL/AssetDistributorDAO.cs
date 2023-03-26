using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class AssetDistributorDAO
    {
        private static volatile AssetDistributorDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public AssetDistributorDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static AssetDistributorDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new AssetDistributorDAO();
                    }

                return instance;
            }
        }

        public static AssetDistributorDAO GetInstance()
        {
            if (instance == null) instance = new AssetDistributorDAO();
            return instance;
        }

        public async Task<List<AssetDistributor>> GetAssetDistributors()
        {
            try
            {

                var distributorList = new List<AssetDistributor>();

                distributorList = dbExecutor.FetchData<AssetDistributor>(CommandType.StoredProcedure, "get_asset_distributors");

                return distributorList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
      

    }
}