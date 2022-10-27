
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class QuestionnaireTransactionBLL //: IDisposible
    {
            public QuestionnaireTransactionBLL()
            {
            _QuestionnaireTransactionDAO = new QuestionnaireTransactionDAO();
            }

        public QuestionnaireTransactionDAO _QuestionnaireTransactionDAO { get; set; }





        public async Task<int> Post(QuestionnaireTransaction _Transaction)
        {
            try
            {
                return await _QuestionnaireTransactionDAO.Post(_Transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }


      
        

    

}
