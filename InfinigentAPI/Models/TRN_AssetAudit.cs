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
    
    public partial class TRN_AssetAudit
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int AssetInfoId { get; set; }
        public bool IsMDONameCorrect { get; set; }
        public string MDONameShortNote { get; set; }
        public string MDONameRemarks { get; set; }
        public bool IsMDOIdCorrect { get; set; }
        public string MDOIdShortNote { get; set; }
        public string MDOIdRemarks { get; set; }
        public bool IsOutletIdCorrect { get; set; }
        public string OutletIdShortNote { get; set; }
        public string OutletIdRemarks { get; set; }
        public bool IsOutletNameCorrect { get; set; }
        public string OutletNameShortNote { get; set; }
        public string OutletNameRemarks { get; set; }
        public bool IsOutletAddressCorrect { get; set; }
        public string OutletAddressShortNote { get; set; }
        public string OutletAddressRemarks { get; set; }
        public bool IsContactNumberCorrect { get; set; }
        public string ContactNumberShortNote { get; set; }
        public string ContactNumberRemarks { get; set; }
        public bool IsCoolerModelCorrect { get; set; }
        public string CoolerModelShortNote { get; set; }
        public string CoolerModelRemarks { get; set; }
        public bool IsAssetNumberCorrect { get; set; }
        public string AssetNumberShortNote { get; set; }
        public string AssetNumberRemarks { get; set; }
        public bool IsSerialNumberCorrect { get; set; }
        public string SerialNumberShortNote { get; set; }
        public string SerialNumberNumberRemarks { get; set; }
        public int CreatorId { get; set; }
        public System.DateTime CreationDate { get; set; }
    }
}
