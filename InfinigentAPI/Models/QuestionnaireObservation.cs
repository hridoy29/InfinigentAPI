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
    
    public partial class QuestionnaireObservation
    {
        public int Id { get; set; }
        public int QuestionnaireId { get; set; }
        public int ObservationId { get; set; }
        public bool isChekced { get; set; }
    
        public virtual Observation Observation { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }
    }
}