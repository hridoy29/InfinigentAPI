//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfinigentAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRN_QuestionnaireObservationFreeHandWriting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRN_QuestionnaireObservationFreeHandWriting()
        {
            this.TRN_QuestionnaireStockIssueFreeHandwriting = new HashSet<TRN_QuestionnaireStockIssueFreeHandwriting>();
        }
    
        public int Id { get; set; }
        public int QuestionnaireId { get; set; }
        public string FreeHandWriting { get; set; }
    
        public virtual TRN_Questionnaire TRN_Questionnaire { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_QuestionnaireStockIssueFreeHandwriting> TRN_QuestionnaireStockIssueFreeHandwriting { get; set; }
    }
}