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
    
    public partial class LU_AssetInfo_Log
    {
        public int Id { get; set; }
        public string AssetNumber { get; set; }
        public string SerialNumber { get; set; }
        public int DistributorId { get; set; }
        public int AICId { get; set; }
        public int ASMId { get; set; }
        public int MDOId { get; set; }
        public int OutletId { get; set; }
        public int CoolerId { get; set; }
        public int CreatorId { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int ModifierId { get; set; }
        public System.DateTime ModificationDate { get; set; }
    }
}
