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
    
    public partial class LU_Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LU_Department()
        {
            this.LU_UserDepartment = new HashSet<LU_UserDepartment>();
        }
    
        public int Id { get; set; }
        public string DeptName { get; set; }
        public bool IsActive { get; set; }
        public int CreatorId { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int ModifierId { get; set; }
        public System.DateTime ModificationDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LU_UserDepartment> LU_UserDepartment { get; set; }
    }
}