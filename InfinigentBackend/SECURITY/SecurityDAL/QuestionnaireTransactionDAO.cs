using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DbExecutor;
using InfinigentBackend.SECURITY.SecurityEntity;

namespace SecurityDAL
{
    public class QuestionnaireTransactionDAO
    {
        private static volatile QuestionnaireTransactionDAO instance;
        private static readonly object lockObj = new object();

        private readonly DBExecutor dbExecutor;

        public QuestionnaireTransactionDAO()
        {
            //dbExecutor = DBExecutor.GetInstanceThreadSafe;
            dbExecutor = new DBExecutor();
        }

        public static QuestionnaireTransactionDAO GetInstanceThreadSafe
        {
            get
            {
                if (instance == null)
                    lock (lockObj)
                    {
                        if (instance == null) instance = new QuestionnaireTransactionDAO();
                    }

                return instance;
            }
        }

        public static QuestionnaireTransactionDAO GetInstance()
        {
            if (instance == null) instance = new QuestionnaireTransactionDAO();
            return instance;
        }

        public async Task<int> Post(QuestionnaireTransaction _Transaction)
        {
            var ret = 0;
            try
            {
                var questionnaireparameters = new Parameters[3]
                {
                       
                     new Parameters("@paramNumber", _Transaction.TRN_Questionnaire.Number, DbType.String,
                        ParameterDirection.Input),
                     new Parameters("@paramUserId",  _Transaction.TRN_Questionnaire.UserId, DbType.Int32,
                        ParameterDirection.Input),
                     new Parameters("@paramDistributorId", _Transaction.TRN_Questionnaire.DistributorId, DbType.Int32,
                        ParameterDirection.Input)

                };
                dbExecutor.ManageTransaction(TransactionType.Open);
                ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_Questionnaire_Post",
                    questionnaireparameters, true);


                var questionnaireDetailsParameters = new Parameters[13]
               {


                     new Parameters("@paramNumber", _Transaction.TRN_Questionnaire.Number, DbType.String,
                        ParameterDirection.Input),
                     new Parameters("@paramLogoOfTheTCC",  _Transaction.TRN_QuestionnaireDetails.LogoOfTheTCC, DbType.Boolean,
                        ParameterDirection.Input),
                     new Parameters("@paramLogoImage",_Transaction.TRN_QuestionnaireDetails.LogoImage, DbType.String,
                        ParameterDirection.Input),
                       new Parameters("@paramStorageOfMemoForLastYear",_Transaction.TRN_QuestionnaireDetails.StorageOfMemoForLastYear, DbType.Boolean,
                        ParameterDirection.Input),
                     new Parameters("@paramMemoImage",  _Transaction.TRN_QuestionnaireDetails.MemoImage, DbType.String,
                        ParameterDirection.Input),
                     new Parameters("@paramGitInIdasAvailable", _Transaction.TRN_QuestionnaireDetails.GitInIdasAvailable, DbType.Boolean,
                        ParameterDirection.Input),
                       new Parameters("@paramGitImage", _Transaction.TRN_QuestionnaireDetails.GitImage, DbType.String,
                        ParameterDirection.Input),
                     new Parameters("@paramDayClosePending",   _Transaction.TRN_QuestionnaireDetails.DayClosePending, DbType.Boolean,
                        ParameterDirection.Input),
                     new Parameters("@paramDayCloseImage",  _Transaction.TRN_QuestionnaireDetails.DayCloseImage, DbType.String,
                        ParameterDirection.Input),
                       new Parameters("@paramStorageCondition", _Transaction.TRN_QuestionnaireDetails.StorageCondition, DbType.Boolean,
                        ParameterDirection.Input),
                     new Parameters("@paramMarketReturnedProductAdjusted",  _Transaction.TRN_QuestionnaireDetails.MarketReturnedProductAdjusted, DbType.Boolean,
                        ParameterDirection.Input),
                     new Parameters("@paramFreeSchemeProductAvailable",_Transaction.TRN_QuestionnaireDetails.FreeSchemeProductAvailable, DbType.Boolean,
                        ParameterDirection.Input),
                     new Parameters("@paramMaintainingMandateTime", _Transaction.TRN_QuestionnaireDetails.MaintainingMandateTime, DbType.Int32,
                        ParameterDirection.Input)

               };
                //dbExecutor.ManageTransaction(TransactionType.Open);
                var questionnaireDetailsId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireDetails_Post",
                    questionnaireDetailsParameters, true);
             
                //

                foreach (TRN_QuestionnairePhysicalStock stock in _Transaction.TRN_QuestionnairePhysicalStocks)
                {

                    var questionnaireStockParameters = new Parameters[7]
                  {



                     new Parameters("@paramNumber", stock.Number, DbType.String,
                        ParameterDirection.Input),
                     new Parameters("@paramItemId",  stock.ItemId, DbType.Int32,
                        ParameterDirection.Input),
                     new Parameters("@paramSystemStock",stock.SystemStock, DbType.Decimal,
                        ParameterDirection.Input),
                       new Parameters("@paramPhysicalStock",stock.PhysicalStock, DbType.Decimal,
                        ParameterDirection.Input),
                     new Parameters("@paramDifference",  stock.Difference, DbType.Decimal,
                        ParameterDirection.Input),
                     new Parameters("@paramBBDDamage", stock.BBDDamage, DbType.Decimal,
                        ParameterDirection.Input),
                       new Parameters("@paramIssueId", stock.IssueId, DbType.Int32,
                        ParameterDirection.Input)

                  };
                    //dbExecutor.ManageTransaction(TransactionType.Open);
                    var questionnaireStockId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnairePhysicalStock_Post",
                        questionnaireStockParameters, true);

                }

                //

                foreach (TRN_QuestionnaireStockIssueFreeHandwriting stockFreeHandWriting in _Transaction.TRN_QuestionnaireStockIssueFreeHandwritings)
                {

                        var questionnaireStockFreeHandWritingParameters = new Parameters[4]
                    {



                         new Parameters("@paramNumber", stockFreeHandWriting.Number, DbType.String,
                            ParameterDirection.Input),
                         new Parameters("@paramPhysicalStockId",  stockFreeHandWriting.PhysicalStockId, DbType.Int32,
                            ParameterDirection.Input),
                         new Parameters("@paramIssueId",stockFreeHandWriting.IssueId, DbType.Int32,
                            ParameterDirection.Input),
                           new Parameters("@paramIssue",stockFreeHandWriting.Issue, DbType.String,
                            ParameterDirection.Input)

                    };
                    //dbExecutor.ManageTransaction(TransactionType.Open);
                    var questionnaireStockFreeHandWritingId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireStockIssueFreeHandwriting_Post",
                        questionnaireStockFreeHandWritingParameters, true);
                }



                //

                foreach (TRN_QuestionnaireObservation observation in _Transaction.TRN_QuestionnaireObservations)
                {

                    var questionnaireObservationParameters = new Parameters[3]
                  {

                  

                     new Parameters("@paramNumber", observation.Number, DbType.String,
                        ParameterDirection.Input),
                     new Parameters("@paramObservationId",  observation.ObservationId, DbType.Int32,
                        ParameterDirection.Input),
                     new Parameters(" @paramisChekced",observation.isChekced, DbType.Boolean,
                        ParameterDirection.Input)

                  };
                    //dbExecutor.ManageTransaction(TransactionType.Open);
                    var questionnaireObservationId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireObservation_Post",
                        questionnaireObservationParameters, true);

                }

              
                //

                    var questionnaireObservationFreeHandWritingParameters = new Parameters[4]
                {


                         new Parameters("@paramNumber", _Transaction.TRN_QuestionnaireObservationFreeHandWritings.Number, DbType.String,
                            ParameterDirection.Input),
                         new Parameters("@paramQuestionnaireObservationId",  _Transaction.TRN_QuestionnaireObservationFreeHandWritings.QuestionnaireObservationId, DbType.Int32,
                            ParameterDirection.Input),
                         new Parameters("@paramObservationId",_Transaction.TRN_QuestionnaireObservationFreeHandWritings.ObservationId, DbType.Int32,
                            ParameterDirection.Input),
                           new Parameters("@paramFreeHandWriting",_Transaction.TRN_QuestionnaireObservationFreeHandWritings.FreeHandWriting, DbType.String,
                            ParameterDirection.Input)

                };
                    //dbExecutor.ManageTransaction(TransactionType.Open);
                    var questionnaireObservationFreeHandWritingId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireObservationFreeHandWriting_Post",
                        questionnaireObservationFreeHandWritingParameters, true);




                foreach (TRN_QuestionnaireHyginePhotos photo in _Transaction.TRN_QuestionnaireHyginePhotoss)
                {

                    var questionnairePhotosParameters = new Parameters[2]
                  {

           

                     new Parameters("@paramNumber", photo.Number, DbType.String,
                        ParameterDirection.Input),
                     new Parameters("@paramHyginePhoto",  photo.HyginePhoto, DbType.String,
                        ParameterDirection.Input)

                  };
                    //dbExecutor.ManageTransaction(TransactionType.Open);
                    var questionnairePhotosId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireHyginePhotos_Post",
                        questionnairePhotosParameters, true);

                }


                //
           
                var questionnaireSignatureParameters = new Parameters[4]
            {


                         new Parameters("@paramNumber", _Transaction.TRN_QuestionnaireObservationFreeHandWritings.Number, DbType.String,
                            ParameterDirection.Input),
                         new Parameters("@@paramName",  _Transaction.TRN_QuestionnaireObservationFreeHandWritings.QuestionnaireObservationId, DbType.String,
                            ParameterDirection.Input),
                         new Parameters("@paramIdentityId",_Transaction.TRN_QuestionnaireObservationFreeHandWritings.ObservationId, DbType.Int32,
                            ParameterDirection.Input),
                           new Parameters("@@paramSignaturePhoto",_Transaction.TRN_QuestionnaireObservationFreeHandWritings.FreeHandWriting, DbType.String,
                            ParameterDirection.Input)

            };
                //dbExecutor.ManageTransaction(TransactionType.Open);
                var questionnaireSignatureId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireHygineSignature_Post",
                    questionnaireSignatureParameters, true);


                dbExecutor.ManageTransaction(TransactionType.Commit);

                ////TEst

                //var colparameters = new Parameters[2]
                //{
                //     new Parameters("@Id", _Transaction.TRN_Questionnaire.DistributorId, DbType.Int32,
                //        ParameterDirection.Input),
                //     new Parameters("@Image", _Transaction.TRN_QuestionnaireDetails.LogoImage, DbType.String,
                //        ParameterDirection.Input)


                //};
                //dbExecutor.ManageTransaction(TransactionType.Open);
                //ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "create_test_t",
                //    colparameters, true);
                //dbExecutor.ManageTransaction(TransactionType.Commit);
            }
            catch (DBConcurrencyException except)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw except;
            }
            catch (Exception ex)
            {
                dbExecutor.ManageTransaction(TransactionType.Rollback);
                throw ex;
            }

            return ret;
        }

    }
}