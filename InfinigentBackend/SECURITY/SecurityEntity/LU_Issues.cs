//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfinigentBackend.SECURITY.SecurityEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class LU_Issues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool isDefault { get; set; }
        public int CreatorId { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int ModifierId { get; set; }
        public System.DateTime ModificationDate { get; set; }
    }
}
