using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinigentBackend.SECURITY.SecurityEntity
{
    public class QuestionnaireTransaction
    {
       

        public TRN_Questionnaire TRN_Questionnaire { get; set; }
        public TRN_QuestionnaireDetails TRN_QuestionnaireDetails { get; set; }
        public List<TRN_QuestionnairePhysicalStock> TRN_QuestionnairePhysicalStocks { get; set; }
        public List<TRN_QuestionnaireStockIssueFreeHandwriting> TRN_QuestionnaireStockIssueFreeHandwritings { get; set; }
        public List<TRN_QuestionnaireObservation> TRN_QuestionnaireObservations { get; set; }
        public TRN_QuestionnaireObservationFreeHandWriting TRN_QuestionnaireObservationFreeHandWritings { get; set; }
        public List<TRN_QuestionnaireHyginePhotos> TRN_QuestionnaireHyginePhotoss { get; set; }
        public TRN_QuestionnaireHygineSignature TRN_QuestionnaireHygineSignature { get; set; }

    }
}
