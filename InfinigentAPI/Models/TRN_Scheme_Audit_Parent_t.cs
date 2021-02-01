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
    
    public partial class TRN_Scheme_Audit_Parent_t
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int UserId { get; set; }
        public string OutlateName { get; set; }
        public System.DateTime Date { get; set; }
        public int GccCode { get; set; }
        public string RetailSellerName { get; set; }
        public string MobileNumber { get; set; }
        public int OutlateTypeId { get; set; }
        public System.DateTime VisitedDate { get; set; }
        public string DistributorName { get; set; }
        public int AsmId { get; set; }
        public int AicId { get; set; }
        public string OutlateAddress { get; set; }
        public int IsKnowenAboutScheme { get; set; }
        public string SchemeDetails { get; set; }
        public int SchemeMediaTypeId { get; set; }
        public int IsFacilitatedByScheme { get; set; }
        public Nullable<System.DateTime> DateOfScheme { get; set; }
        public Nullable<int> IsWrittenRecordAvailable { get; set; }
        public Nullable<System.DateTime> LatestChallanDate { get; set; }
        public string ChallanAmount { get; set; }
        public Nullable<int> DoesGotAnyChallan { get; set; }
        public Nullable<int> ChallanTypeId { get; set; }
        public Nullable<int> DoesExpiredProductAvailable { get; set; }
        public Nullable<int> DoesSatisfiedWithSallesOfficer { get; set; }
        public Nullable<int> DoesSatisfiedWithProductOrderAndService { get; set; }
        public Nullable<int> SallesOfficerVisitingDay { get; set; }
        public Nullable<int> DoesGotLatestDiscountOffer { get; set; }
        public Nullable<int> WillGetAnyDiscountOfferFromDistributor { get; set; }
        public Nullable<int> DoesCocaColaLabelAvailable { get; set; }
        public Nullable<int> IsGccCodeAvailable { get; set; }
        public Nullable<int> CommentsType { get; set; }
        public Nullable<int> Comments { get; set; }
        public string CommentDetails { get; set; }
        public byte CreatorName { get; set; }
        public System.DateTime CreationDate { get; set; }
        public byte ModifierName { get; set; }
        public System.DateTime ModificationDate { get; set; }
    }
}
