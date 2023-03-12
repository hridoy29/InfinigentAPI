
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class ShortNoteBLL //: IDisposible
    {
            public ShortNoteBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _ShortNoteDAO = new ShortNoteDAO();
            }

        public ShortNoteDAO _ShortNoteDAO { get; set; }





      

        public async Task<List<LU_ShortNote>> GetShortNotes()
        {
            try
            {
                return await _ShortNoteDAO.GetShortNotes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


      
        

    

}
