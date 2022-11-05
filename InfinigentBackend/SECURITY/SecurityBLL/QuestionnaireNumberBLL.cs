
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class QuestionnaireNumberBLL //: IDisposible
    {
            public QuestionnaireNumberBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _QuestionnaireNumberDAO = new QuestionnaireNumberDAO();
            }

        public QuestionnaireNumberDAO _QuestionnaireNumberDAO { get; set; }





     


        public async Task<List<TRN_QuestionnaireNumber>> GetQuestionnaireNumbers()
        {
            try
            {
                return await _QuestionnaireNumberDAO.GetQuestionnaireNumbers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<int> Post(TRN_QuestionnaireNumber _Number)
        {
            try
            {
                return await _QuestionnaireNumberDAO.Post(_Number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
