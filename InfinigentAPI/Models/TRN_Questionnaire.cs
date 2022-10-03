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
    
    public partial class TRN_Questionnaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRN_Questionnaire()
        {
            this.TRN_QuestionnaireHyginePhotos = new HashSet<TRN_QuestionnaireHyginePhotos>();
            this.TRN_QuestionnaireHygineSignature = new HashSet<TRN_QuestionnaireHygineSignature>();
            this.TRN_QuestionnaireObservation = new HashSet<TRN_QuestionnaireObservation>();
            this.TRN_QuestionnaireObservationFreeHandWriting = new HashSet<TRN_QuestionnaireObservationFreeHandWriting>();
            this.TRN_QuestionnairePhysicalStock = new HashSet<TRN_QuestionnairePhysicalStock>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DistributorId { get; set; }
        public System.DateTime Date { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int CreatorId { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int ModifierId { get; set; }
        public System.DateTime ModificationDate { get; set; }
    
        public virtual LU_Distributor LU_Distributor { get; set; }
        public virtual LU_User LU_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_QuestionnaireHyginePhotos> TRN_QuestionnaireHyginePhotos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_QuestionnaireHygineSignature> TRN_QuestionnaireHygineSignature { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_QuestionnaireObservation> TRN_QuestionnaireObservation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_QuestionnaireObservationFreeHandWriting> TRN_QuestionnaireObservationFreeHandWriting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_QuestionnairePhysicalStock> TRN_QuestionnairePhysicalStock { get; set; }
    }
}