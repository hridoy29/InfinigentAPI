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
           
            
            
            SqlTransaction objTrans = null;
         
               
                SqlConnection sqlCon = null;
                String SqlconString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
              

                using (sqlCon = new SqlConnection(SqlconString))
                {
                    try
                    {
                    sqlCon.Open();
                    objTrans = sqlCon.BeginTransaction();

                    SqlCommand sql_cmndQ = new SqlCommand("wsp_TRN_Questionnaire_Post", sqlCon,objTrans);
                    sql_cmndQ.CommandType = CommandType.StoredProcedure;
                    sql_cmndQ.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = _Transaction.TRN_Questionnaire.Id;
                    sql_cmndQ.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Transaction.TRN_Questionnaire.Number;
                    sql_cmndQ.Parameters.AddWithValue("@paramUserId", SqlDbType.Int).Value = _Transaction.TRN_Questionnaire.UserId;
                    sql_cmndQ.Parameters.AddWithValue("@paramDistributorId", SqlDbType.Int).Value = _Transaction.TRN_Questionnaire.DistributorId;
                    sql_cmndQ.ExecuteNonQuery();


                  

                    SqlCommand sql_cmndQD = new SqlCommand("wsp_TRN_QuestionnaireDetails_Post", sqlCon, objTrans);
                    sql_cmndQD.CommandType = CommandType.StoredProcedure;
                    sql_cmndQD.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireDetails.Id;
                    sql_cmndQD.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireDetails.Number;
                    sql_cmndQD.Parameters.AddWithValue("@paramLogoOfTheTCC", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.LogoOfTheTCC;
                    sql_cmndQD.Parameters.AddWithValue("@paramLogoImage", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireDetails.LogoImage;

                    sql_cmndQD.Parameters.AddWithValue("@paramStorageOfMemoForLastYear", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.StorageOfMemoForLastYear;
                    sql_cmndQD.Parameters.AddWithValue("@paramMemoImage", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireDetails.MemoImage;

                    sql_cmndQD.Parameters.AddWithValue("@paramGitInIdasAvailable", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.GitInIdasAvailable;
                    sql_cmndQD.Parameters.AddWithValue("@paramGitImage", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireDetails.GitImage;

                    sql_cmndQD.Parameters.AddWithValue("@paramDayClosePending", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.DayClosePending;
                    sql_cmndQD.Parameters.AddWithValue("@paramDayCloseImage", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireDetails.DayCloseImage;

                    sql_cmndQD.Parameters.AddWithValue("@paramStorageCondition", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.StorageCondition;
                    sql_cmndQD.Parameters.AddWithValue("@paramMarketReturnedProductAdjusted", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.MarketReturnedProductAdjusted;
                    sql_cmndQD.Parameters.AddWithValue("@paramFreeSchemeProductAvailable", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.FreeSchemeProductAvailable;
                    sql_cmndQD.Parameters.AddWithValue("@paramMaintainingMandateTime", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireDetails.MaintainingMandateTime;
                    sql_cmndQD.ExecuteNonQuery();


                



                    foreach (TRN_QuestionnairePhysicalStock stock in _Transaction.TRN_QuestionnairePhysicalStocks)
                    {

                        SqlCommand sql_cmndQStock = new SqlCommand("wsp_TRN_QuestionnairePhysicalStock_Post", sqlCon, objTrans);
                        sql_cmndQStock.CommandType = CommandType.StoredProcedure;
                        sql_cmndQStock.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = stock.Id;
                        sql_cmndQStock.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = stock.Number;
                        sql_cmndQStock.Parameters.AddWithValue("@paramItemId", SqlDbType.Int).Value = stock.ItemId;
                        sql_cmndQStock.Parameters.AddWithValue("@paramSystemStock", SqlDbType.Decimal).Value = stock.SystemStock;

                        sql_cmndQStock.Parameters.AddWithValue("@paramPhysicalStock", SqlDbType.Decimal).Value = stock.PhysicalStock;
                        sql_cmndQStock.Parameters.AddWithValue("@paramDifference", SqlDbType.Decimal).Value = stock.Difference;

                        sql_cmndQStock.Parameters.AddWithValue("@paramBBDDamage", SqlDbType.Decimal).Value = stock.BBDDamage;
                        sql_cmndQStock.Parameters.AddWithValue("@paramIssueId", SqlDbType.Int).Value = stock.IssueId;
                        sql_cmndQStock.ExecuteNonQuery();


                    }
                    foreach (TRN_QuestionnaireStockIssueFreeHandwriting stockFreeHandWriting in _Transaction.TRN_QuestionnaireStockIssueFreeHandwritings)
                    {

                        SqlCommand sql_cmndQStockFH = new SqlCommand("wsp_TRN_QuestionnaireStockIssueFreeHandwriting_Post", sqlCon, objTrans);
                        sql_cmndQStockFH.CommandType = CommandType.StoredProcedure;
                        sql_cmndQStockFH.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = stockFreeHandWriting.Id;
                        sql_cmndQStockFH.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = stockFreeHandWriting.Number;
                        sql_cmndQStockFH.Parameters.AddWithValue("@paramPhysicalStockId", SqlDbType.Int).Value = stockFreeHandWriting.PhysicalStockId;
                        sql_cmndQStockFH.Parameters.AddWithValue("@paramIssueId", SqlDbType.Int).Value = stockFreeHandWriting.IssueId;
                        sql_cmndQStockFH.Parameters.AddWithValue("@paramIssue", SqlDbType.VarChar).Value = stockFreeHandWriting.Issue;

                        sql_cmndQStockFH.ExecuteNonQuery();


                    }





                    foreach (TRN_QuestionnaireObservation observation in _Transaction.TRN_QuestionnaireObservations)
                    {




                        SqlCommand sql_cmndQObs = new SqlCommand("wsp_TRN_QuestionnaireObservation_Post", sqlCon, objTrans);
                        sql_cmndQObs.CommandType = CommandType.StoredProcedure;
                        sql_cmndQObs.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = observation.Id;
                        sql_cmndQObs.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = observation.Number;
                        sql_cmndQObs.Parameters.AddWithValue("@paramObservationId", SqlDbType.Int).Value = observation.ObservationId;
                        sql_cmndQObs.Parameters.AddWithValue("@paramisChekced", SqlDbType.Int).Value = observation.isChecked;

                        sql_cmndQObs.ExecuteNonQuery();

                        if(observation.Id == 15)
                        {
                            if (observation.isChecked)
                            {
                                SqlCommand sql_cmndQObsFH = new SqlCommand("wsp_TRN_QuestionnaireObservationFreeHandWriting_Post", sqlCon, objTrans);
                                sql_cmndQObsFH.CommandType = CommandType.StoredProcedure;
                                sql_cmndQObsFH.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireObservationFreeHandWritings.Id;
                                sql_cmndQObsFH.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireObservationFreeHandWritings.Number;
                                sql_cmndQObsFH.Parameters.AddWithValue("@paramQuestionnaireObservationId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireObservationFreeHandWritings.QuestionnaireObservationId;
                                sql_cmndQObsFH.Parameters.AddWithValue("@paramObservationId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireObservationFreeHandWritings.ObservationId;
                                sql_cmndQObsFH.Parameters.AddWithValue("@paramFreeHandWriting", SqlDbType.VarChar).Value = _Transaction.TRN_QuestionnaireObservationFreeHandWritings.FreeHandWriting;

                                sql_cmndQObsFH.ExecuteNonQuery();
                            }
                        }

                    }





                   




                    foreach (TRN_QuestionnaireHyginePhotos photo in _Transaction.TRN_QuestionnaireHyginePhotoss)
                    {


                        if (photo != null)
                        {



                            SqlCommand sql_cmndQPhoto = new SqlCommand("wsp_TRN_QuestionnaireHyginePhotos_Post", sqlCon, objTrans);
                            sql_cmndQPhoto.CommandType = CommandType.StoredProcedure;
                            sql_cmndQPhoto.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = photo.Id;
                            sql_cmndQPhoto.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = photo.Number;
                            sql_cmndQPhoto.Parameters.AddWithValue("@paramHyginePhoto", SqlDbType.NVarChar).Value = photo.HyginePhoto;

                            sql_cmndQPhoto.ExecuteNonQuery();





                        }


                    }


                    SqlCommand sql_cmndQSP = new SqlCommand("wsp_TRN_QuestionnaireHygineSignature_Post", sqlCon, objTrans);
                    sql_cmndQSP.CommandType = CommandType.StoredProcedure;
                    sql_cmndQSP.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireHygineSignature.Id;
                    sql_cmndQSP.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireHygineSignature.Number;
                    sql_cmndQSP.Parameters.AddWithValue("@paramName", SqlDbType.VarChar).Value = _Transaction.TRN_QuestionnaireHygineSignature.Name;
                    sql_cmndQSP.Parameters.AddWithValue("@paramIdentityId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireHygineSignature.IdentityId;
                    sql_cmndQSP.Parameters.AddWithValue("@paramSignaturePhoto", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireHygineSignature.SignaturePhoto;

                    ret =  sql_cmndQSP.ExecuteNonQuery();


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
           

            // }

            return ret;
        }
        //public async Task<int> Post(QuestionnaireTransaction _Transaction)
        //{
        //    var ret = 0;
        //    string folder = @"C:\Temp\";
        //    // Filename  
        //    string fileName = "Log.txt";
        //    // Fullpath. You can direct hardcode it if you like.  
        //    string fullPath = folder + fileName;
        //    //try
        //    //{
        //    //    var questionnaireparameters = new Parameters[3]
        //    //    {

        //    //         new Parameters("@paramNumber", _Transaction.TRN_Questionnaire.Number, DbType.String,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramUserId",  _Transaction.TRN_Questionnaire.UserId, DbType.Int32,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramDistributorId", _Transaction.TRN_Questionnaire.DistributorId, DbType.Int32,
        //    //            ParameterDirection.Input)

        //    //    };
        //    //    dbExecutor.ManageTransaction(TransactionType.Open);
        //    //    ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_Questionnaire_Post",
        //    //        questionnaireparameters, true);


        //    //    // An array of strings  
        //    //    string[] text = {"Test Log 1st Step ",_Transaction.TRN_Questionnaire.Number};
        //    //    // Write array of strings to a file using WriteAllLines.  
        //    //    // If the file does not exists, it will create a new file.  
        //    //    // This method automatically opens the file, writes to it, and closes file  
        //    //    File.WriteAllLines(fullPath, text);


        //    //    var questionnaireDetailsParameters = new Parameters[13]
        //    //   {


        //    //         new Parameters("@paramNumber", _Transaction.TRN_Questionnaire.Number, DbType.String,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramLogoOfTheTCC",  _Transaction.TRN_QuestionnaireDetails.LogoOfTheTCC, DbType.Boolean,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramLogoImage",_Transaction.TRN_QuestionnaireDetails.LogoImage, DbType.String,
        //    //            ParameterDirection.Input),
        //    //           new Parameters("@paramStorageOfMemoForLastYear",_Transaction.TRN_QuestionnaireDetails.StorageOfMemoForLastYear, DbType.Boolean,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramMemoImage",  _Transaction.TRN_QuestionnaireDetails.MemoImage, DbType.String,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramGitInIdasAvailable", _Transaction.TRN_QuestionnaireDetails.GitInIdasAvailable, DbType.Boolean,
        //    //            ParameterDirection.Input),
        //    //           new Parameters("@paramGitImage", _Transaction.TRN_QuestionnaireDetails.GitImage, DbType.String,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramDayClosePending",   _Transaction.TRN_QuestionnaireDetails.DayClosePending, DbType.Boolean,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramDayCloseImage",  _Transaction.TRN_QuestionnaireDetails.DayCloseImage, DbType.String,
        //    //            ParameterDirection.Input),
        //    //           new Parameters("@paramStorageCondition", _Transaction.TRN_QuestionnaireDetails.StorageCondition, DbType.Boolean,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramMarketReturnedProductAdjusted",  _Transaction.TRN_QuestionnaireDetails.MarketReturnedProductAdjusted, DbType.Boolean,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramFreeSchemeProductAvailable",_Transaction.TRN_QuestionnaireDetails.FreeSchemeProductAvailable, DbType.Boolean,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramMaintainingMandateTime", _Transaction.TRN_QuestionnaireDetails.MaintainingMandateTime, DbType.Int32,
        //    //            ParameterDirection.Input)

        //    //   };
        //    //    //dbExecutor.ManageTransaction(TransactionType.Open);
        //    //    var questionnaireDetailsId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireDetails_Post",
        //    //        questionnaireDetailsParameters, true);

        //    //    //
        //    //    string[] text2 = { "Test Log 2nd Step ", _Transaction.TRN_QuestionnaireDetails.MemoImage};
        //    //    // Write array of strings to a file using WriteAllLines.  
        //    //    // If the file does not exists, it will create a new file.  
        //    //    // This method automatically opens the file, writes to it, and closes file  
        //    //    File.WriteAllLines(fullPath, text2);

        //    //    foreach (TRN_QuestionnairePhysicalStock stock in _Transaction.TRN_QuestionnairePhysicalStocks)
        //    //    {

        //    //        var questionnaireStockParameters = new Parameters[7]
        //    //      {



        //    //         new Parameters("@paramNumber", stock.Number, DbType.String,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramItemId",  stock.ItemId, DbType.Int32,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramSystemStock",stock.SystemStock, DbType.Decimal,
        //    //            ParameterDirection.Input),
        //    //           new Parameters("@paramPhysicalStock",stock.PhysicalStock, DbType.Decimal,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramDifference",  stock.Difference, DbType.Decimal,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramBBDDamage", stock.BBDDamage, DbType.Decimal,
        //    //            ParameterDirection.Input),
        //    //           new Parameters("@paramIssueId", stock.IssueId, DbType.Int32,
        //    //            ParameterDirection.Input)

        //    //      };
        //    //        //dbExecutor.ManageTransaction(TransactionType.Open);
        //    //        var questionnaireStockId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnairePhysicalStock_Post",
        //    //            questionnaireStockParameters, true);

        //    //    }

        //    //    //

        //    //    string[] text3 = { "Test Log 3rd Step ", _Transaction.TRN_QuestionnairePhysicalStocks.Count()+""};
        //    //    // Write array of strings to a file using WriteAllLines.  
        //    //    // If the file does not exists, it will create a new file.  
        //    //    // This method automatically opens the file, writes to it, and closes file  
        //    //    File.WriteAllLines(fullPath, text3);

        //    //    foreach (TRN_QuestionnaireStockIssueFreeHandwriting stockFreeHandWriting in _Transaction.TRN_QuestionnaireStockIssueFreeHandwritings)
        //    //    {

        //    //            var questionnaireStockFreeHandWritingParameters = new Parameters[4]
        //    //        {

        //    //             new Parameters("@paramNumber", stockFreeHandWriting.Number, DbType.String,
        //    //                ParameterDirection.Input),
        //    //             new Parameters("@paramPhysicalStockId",  stockFreeHandWriting.PhysicalStockId, DbType.Int32,
        //    //                ParameterDirection.Input),
        //    //             new Parameters("@paramIssueId",stockFreeHandWriting.IssueId, DbType.Int32,
        //    //                ParameterDirection.Input),
        //    //               new Parameters("@paramIssue",stockFreeHandWriting.Issue, DbType.String,
        //    //                ParameterDirection.Input)

        //    //        };
        //    //        //dbExecutor.ManageTransaction(TransactionType.Open);
        //    //        var questionnaireStockFreeHandWritingId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireStockIssueFreeHandwriting_Post",
        //    //            questionnaireStockFreeHandWritingParameters, true);
        //    //    }


        //    //    //

        //    //    foreach (TRN_QuestionnaireObservation observation in _Transaction.TRN_QuestionnaireObservations)
        //    //    {

        //    //        var questionnaireObservationParameters = new Parameters[3]
        //    //      {
        //    //         new Parameters("@paramNumber", observation.Number, DbType.String,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramObservationId",  observation.ObservationId, DbType.Int32,
        //    //            ParameterDirection.Input),
        //    //         new Parameters("@paramisChekced",observation.isChecked, DbType.Boolean,
        //    //            ParameterDirection.Input)

        //    //      };
        //    //        //dbExecutor.ManageTransaction(TransactionType.Open);
        //    //        var questionnaireObservationId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireObservation_Post",
        //    //            questionnaireObservationParameters, true);

        //    //    }


        //    //    //

        //    //        var questionnaireObservationFreeHandWritingParameters = new Parameters[4]
        //    //    {


        //    //             new Parameters("@paramNumber", _Transaction.TRN_QuestionnaireObservationFreeHandWritings.Number, DbType.String,
        //    //                ParameterDirection.Input),
        //    //             new Parameters("@paramQuestionnaireObservationId",  _Transaction.TRN_QuestionnaireObservationFreeHandWritings.QuestionnaireObservationId, DbType.Int32,
        //    //                ParameterDirection.Input),
        //    //             new Parameters("@paramObservationId",_Transaction.TRN_QuestionnaireObservationFreeHandWritings.ObservationId, DbType.Int32,
        //    //                ParameterDirection.Input),
        //    //               new Parameters("@paramFreeHandWriting",_Transaction.TRN_QuestionnaireObservationFreeHandWritings.FreeHandWriting, DbType.String,
        //    //                ParameterDirection.Input)

        //    //    };
        //    //        //dbExecutor.ManageTransaction(TransactionType.Open);
        //    //        var questionnaireObservationFreeHandWritingId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireObservationFreeHandWriting_Post",
        //    //            questionnaireObservationFreeHandWritingParameters, true);




        //    //    foreach (TRN_QuestionnaireHyginePhotos photo in _Transaction.TRN_QuestionnaireHyginePhotoss)
        //    //    {


        //    //        if(photo != null)
        //    //        {
        //    //                    var questionnairePhotosParameters = new Parameters[2]
        //    //           {



        //    //                 new Parameters("@paramNumber", photo.Number, DbType.String,
        //    //                    ParameterDirection.Input),
        //    //                 new Parameters("@paramHyginePhoto",  photo.HyginePhoto, DbType.String,
        //    //                    ParameterDirection.Input)

        //    //           };
        //    //                    //dbExecutor.ManageTransaction(TransactionType.Open);
        //    //                    var questionnairePhotosId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireHyginePhotos_Post",
        //    //                        questionnairePhotosParameters, true);
        //    //                }


        //    //    }


        //    //    //

        //    //    var questionnaireSignatureParameters = new Parameters[4]
        //    //{


        //    //             new Parameters("@paramNumber", _Transaction.TRN_QuestionnaireHygineSignature.Number, DbType.String,
        //    //                ParameterDirection.Input),
        //    //             new Parameters("@paramName",  _Transaction.TRN_QuestionnaireHygineSignature.Name, DbType.String,
        //    //                ParameterDirection.Input),
        //    //             new Parameters("@paramIdentityId",_Transaction.TRN_QuestionnaireHygineSignature.IdentityId, DbType.Int32,
        //    //                ParameterDirection.Input),
        //    //               new Parameters("@paramSignaturePhoto",_Transaction.TRN_QuestionnaireHygineSignature.SignaturePhoto, DbType.String,
        //    //                ParameterDirection.Input)

        //    //};
        //    //    //dbExecutor.ManageTransaction(TransactionType.Open);
        //    //    var questionnaireSignatureId = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "wsp_TRN_QuestionnaireHygineSignature_Post",
        //    //        questionnaireSignatureParameters, true);


        //    //    dbExecutor.ManageTransaction(TransactionType.Commit);

        //    //    ////TEst

        //    //    //var colparameters = new Parameters[2]
        //    //    //{
        //    //    //     new Parameters("@Id", _Transaction.TRN_Questionnaire.DistributorId, DbType.Int32,
        //    //    //        ParameterDirection.Input),
        //    //    //     new Parameters("@Image", _Transaction.TRN_QuestionnaireDetails.LogoImage, DbType.String,
        //    //    //        ParameterDirection.Input)


        //    //    //};
        //    //    //dbExecutor.ManageTransaction(TransactionType.Open);
        //    //    //ret = dbExecutor.ExecuteScalar32(true, CommandType.StoredProcedure, "create_test_t",
        //    //    //    colparameters, true);
        //    //    //dbExecutor.ManageTransaction(TransactionType.Commit);
        //    //}
        //    //catch (DBConcurrencyException except)
        //    //{
        //    //    dbExecutor.ManageTransaction(TransactionType.Rollback);

        //    //    string[] text4 = { "Test Log DBError ", except.ToString()};
        //    //    // Write array of strings to a file using WriteAllLines.  
        //    //    // If the file does not exists, it will create a new file.  
        //    //    // This method automatically opens the file, writes to it, and closes file  
        //    //    File.WriteAllLines(fullPath, text4);
        //    //    throw except;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    dbExecutor.ManageTransaction(TransactionType.Rollback);

        //    //    string[] text4 = { "Test Log Error ", ex.ToString() };
        //    //    // Write array of strings to a file using WriteAllLines.  
        //    //    // If the file does not exists, it will create a new file.  
        //    //    // This method automatically opens the file, writes to it, and closes file  
        //    //    File.WriteAllLines(fullPath, text4);
        //    //    throw ex;
        //    //}
        //    SqlTransaction objTrans = null;


        //    SqlConnection sqlCon = null;
        //    String SqlconString = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;


        //    using (sqlCon = new SqlConnection(SqlconString))
        //    {
        //        try
        //        {
        //            sqlCon.Open();
        //            objTrans = sqlCon.BeginTransaction();

        //            SqlCommand sql_cmndQ = new SqlCommand("wsp_TRN_Questionnaire_Post", sqlCon, objTrans);
        //            sql_cmndQ.CommandType = CommandType.StoredProcedure;
        //            sql_cmndQ.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = _Transaction.TRN_Questionnaire.Id;
        //            sql_cmndQ.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Transaction.TRN_Questionnaire.Number;
        //            sql_cmndQ.Parameters.AddWithValue("@paramUserId", SqlDbType.Int).Value = _Transaction.TRN_Questionnaire.UserId;
        //            sql_cmndQ.Parameters.AddWithValue("@paramDistributorId", SqlDbType.Int).Value = _Transaction.TRN_Questionnaire.DistributorId;
        //            sql_cmndQ.ExecuteNonQuery();


        //            // An array of strings  
        //            string[] text = { "Test Log 1st Step ", _Transaction.TRN_Questionnaire.Number };
        //            // Write array of strings to a file using WriteAllLines.  
        //            // If the file does not exists, it will create a new file.  
        //            // This method automatically opens the file, writes to it, and closes file  
        //            File.WriteAllLines(fullPath, text);

        //            SqlCommand sql_cmndQD = new SqlCommand("wsp_TRN_QuestionnaireDetails_Post", sqlCon, objTrans);
        //            sql_cmndQD.CommandType = CommandType.StoredProcedure;
        //            sql_cmndQD.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireDetails.Id;
        //            sql_cmndQD.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireDetails.Number;
        //            sql_cmndQD.Parameters.AddWithValue("@paramLogoOfTheTCC", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.LogoOfTheTCC;
        //            sql_cmndQD.Parameters.AddWithValue("@paramLogoImage", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireDetails.LogoImage;

        //            sql_cmndQD.Parameters.AddWithValue("@paramStorageOfMemoForLastYear", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.StorageOfMemoForLastYear;
        //            sql_cmndQD.Parameters.AddWithValue("@paramMemoImage", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireDetails.MemoImage;

        //            sql_cmndQD.Parameters.AddWithValue("@paramGitInIdasAvailable", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.GitInIdasAvailable;
        //            sql_cmndQD.Parameters.AddWithValue("@paramGitImage", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireDetails.GitImage;

        //            sql_cmndQD.Parameters.AddWithValue("@paramDayClosePending", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.DayClosePending;
        //            sql_cmndQD.Parameters.AddWithValue("@paramDayCloseImage", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireDetails.DayCloseImage;

        //            sql_cmndQD.Parameters.AddWithValue("@paramStorageCondition", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.StorageCondition;
        //            sql_cmndQD.Parameters.AddWithValue("@paramMarketReturnedProductAdjusted", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.MarketReturnedProductAdjusted;
        //            sql_cmndQD.Parameters.AddWithValue("@paramFreeSchemeProductAvailable", SqlDbType.Bit).Value = _Transaction.TRN_QuestionnaireDetails.FreeSchemeProductAvailable;
        //            sql_cmndQD.Parameters.AddWithValue("@paramMaintainingMandateTime", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireDetails.MaintainingMandateTime;
        //            sql_cmndQD.ExecuteNonQuery();


        //            string[] text2 = { "Test Log 2nd Step ", _Transaction.TRN_QuestionnaireDetails.MemoImage };
        //            // Write array of strings to a file using WriteAllLines.  
        //            // If the file does not exists, it will create a new file.  
        //            // This method automatically opens the file, writes to it, and closes file  
        //            File.WriteAllLines(fullPath, text2);



        //            foreach (TRN_QuestionnairePhysicalStock stock in _Transaction.TRN_QuestionnairePhysicalStocks)
        //            {

        //                SqlCommand sql_cmndQStock = new SqlCommand("wsp_TRN_QuestionnairePhysicalStock_Post", sqlCon, objTrans);
        //                sql_cmndQStock.CommandType = CommandType.StoredProcedure;
        //                sql_cmndQStock.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = stock.Id;
        //                sql_cmndQStock.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = stock.Number;
        //                sql_cmndQStock.Parameters.AddWithValue("@paramItemId", SqlDbType.Int).Value = stock.ItemId;
        //                sql_cmndQStock.Parameters.AddWithValue("@paramSystemStock", SqlDbType.Decimal).Value = stock.SystemStock;

        //                sql_cmndQStock.Parameters.AddWithValue("@paramPhysicalStock", SqlDbType.Decimal).Value = stock.PhysicalStock;
        //                sql_cmndQStock.Parameters.AddWithValue("@paramDifference", SqlDbType.Decimal).Value = stock.Difference;

        //                sql_cmndQStock.Parameters.AddWithValue("@paramBBDDamage", SqlDbType.Decimal).Value = stock.BBDDamage;
        //                sql_cmndQStock.Parameters.AddWithValue("@paramIssueId", SqlDbType.Int).Value = stock.IssueId;
        //                sql_cmndQStock.ExecuteNonQuery();


        //            }
        //            foreach (TRN_QuestionnaireStockIssueFreeHandwriting stockFreeHandWriting in _Transaction.TRN_QuestionnaireStockIssueFreeHandwritings)
        //            {

        //                SqlCommand sql_cmndQStockFH = new SqlCommand("wsp_TRN_QuestionnaireStockIssueFreeHandwriting_Post", sqlCon, objTrans);
        //                sql_cmndQStockFH.CommandType = CommandType.StoredProcedure;
        //                sql_cmndQStockFH.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = stockFreeHandWriting.Id;
        //                sql_cmndQStockFH.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = stockFreeHandWriting.Number;
        //                sql_cmndQStockFH.Parameters.AddWithValue("@paramPhysicalStockId", SqlDbType.Int).Value = stockFreeHandWriting.PhysicalStockId;
        //                sql_cmndQStockFH.Parameters.AddWithValue("@paramIssueId", SqlDbType.Int).Value = stockFreeHandWriting.IssueId;
        //                sql_cmndQStockFH.Parameters.AddWithValue("@paramIssue", SqlDbType.VarChar).Value = stockFreeHandWriting.Issue;

        //                sql_cmndQStockFH.ExecuteNonQuery();


        //            }





        //            foreach (TRN_QuestionnaireObservation observation in _Transaction.TRN_QuestionnaireObservations)
        //            {




        //                SqlCommand sql_cmndQObs = new SqlCommand("wsp_TRN_QuestionnaireObservation_Post", sqlCon, objTrans);
        //                sql_cmndQObs.CommandType = CommandType.StoredProcedure;
        //                sql_cmndQObs.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = observation.Id;
        //                sql_cmndQObs.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = observation.Number;
        //                sql_cmndQObs.Parameters.AddWithValue("@paramObservationId", SqlDbType.Int).Value = observation.ObservationId;
        //                sql_cmndQObs.Parameters.AddWithValue("@paramisChekced", SqlDbType.Int).Value = observation.isChecked;

        //                sql_cmndQObs.ExecuteNonQuery();

        //                if (observation.Id == 15)
        //                {
        //                    if (observation.isChecked)
        //                    {
        //                        SqlCommand sql_cmndQObsFH = new SqlCommand("wsp_TRN_QuestionnaireObservationFreeHandWriting_Post", sqlCon, objTrans);
        //                        sql_cmndQObsFH.CommandType = CommandType.StoredProcedure;
        //                        sql_cmndQObsFH.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireObservationFreeHandWritings.Id;
        //                        sql_cmndQObsFH.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireObservationFreeHandWritings.Number;
        //                        sql_cmndQObsFH.Parameters.AddWithValue("@paramQuestionnaireObservationId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireObservationFreeHandWritings.QuestionnaireObservationId;
        //                        sql_cmndQObsFH.Parameters.AddWithValue("@paramObservationId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireObservationFreeHandWritings.ObservationId;
        //                        sql_cmndQObsFH.Parameters.AddWithValue("@paramFreeHandWriting", SqlDbType.VarChar).Value = _Transaction.TRN_QuestionnaireObservationFreeHandWritings.FreeHandWriting;

        //                        sql_cmndQObsFH.ExecuteNonQuery();
        //                    }
        //                }

        //            }










        //            foreach (TRN_QuestionnaireHyginePhotos photo in _Transaction.TRN_QuestionnaireHyginePhotoss)
        //            {


        //                if (photo != null)
        //                {



        //                    SqlCommand sql_cmndQPhoto = new SqlCommand("wsp_TRN_QuestionnaireHyginePhotos_Post", sqlCon, objTrans);
        //                    sql_cmndQPhoto.CommandType = CommandType.StoredProcedure;
        //                    sql_cmndQPhoto.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = photo.Id;
        //                    sql_cmndQPhoto.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = photo.Number;
        //                    sql_cmndQPhoto.Parameters.AddWithValue("@paramHyginePhoto", SqlDbType.NVarChar).Value = photo.HyginePhoto;

        //                    sql_cmndQPhoto.ExecuteNonQuery();





        //                }


        //            }


        //            SqlCommand sql_cmndQSP = new SqlCommand("wsp_TRN_QuestionnaireHygineSignature_Post", sqlCon, objTrans);
        //            sql_cmndQSP.CommandType = CommandType.StoredProcedure;
        //            sql_cmndQSP.Parameters.AddWithValue("@paramId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireHygineSignature.Id;
        //            sql_cmndQSP.Parameters.AddWithValue("@paramNumber", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireHygineSignature.Number;
        //            sql_cmndQSP.Parameters.AddWithValue("@paramName", SqlDbType.VarChar).Value = _Transaction.TRN_QuestionnaireHygineSignature.Name;
        //            sql_cmndQSP.Parameters.AddWithValue("@paramIdentityId", SqlDbType.Int).Value = _Transaction.TRN_QuestionnaireHygineSignature.IdentityId;
        //            sql_cmndQSP.Parameters.AddWithValue("@paramSignaturePhoto", SqlDbType.NVarChar).Value = _Transaction.TRN_QuestionnaireHygineSignature.SignaturePhoto;

        //            sql_cmndQSP.ExecuteNonQuery();


        //            objTrans.Commit();

        //            sqlCon.Close();
        //        }

        //        catch (Exception ex)
        //        {

        //            objTrans.Rollback();
        //            sqlCon.Close();
        //            string[] text4 = { "Test Log Error ", ex.ToString() };
        //            // Write array of strings to a file using WriteAllLines.  
        //            // If the file does not exists, it will create a new file.  
        //            // This method automatically opens the file, writes to it, and closes file  
        //            File.WriteAllLines(fullPath, text4);
        //            throw ex;
        //        }
        //        finally
        //        {
        //            sqlCon.Close();

        //        }
        //    }


        //    // }

        //    return ret;
        //}

    }
}