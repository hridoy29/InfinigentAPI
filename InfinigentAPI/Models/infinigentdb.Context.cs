﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class qt_infinigentdbEntities : DbContext
    {
        public qt_infinigentdbEntities()
            : base("name=qt_infinigentdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LU_AIC> LU_AIC { get; set; }
        public virtual DbSet<LU_ASM> LU_ASM { get; set; }
        public virtual DbSet<LU_ChallanType> LU_ChallanType { get; set; }
        public virtual DbSet<LU_CommentsType> LU_CommentsType { get; set; }
        public virtual DbSet<LU_Commnets> LU_Commnets { get; set; }
        public virtual DbSet<LU_ConfigarationSettings> LU_ConfigarationSettings { get; set; }
        public virtual DbSet<LU_DeviceInfo> LU_DeviceInfo { get; set; }
        public virtual DbSet<LU_DistributorDetails> LU_DistributorDetails { get; set; }
        public virtual DbSet<LU_Employee> LU_Employee { get; set; }
        public virtual DbSet<LU_Module> LU_Module { get; set; }
        public virtual DbSet<LU_OutletType> LU_OutletType { get; set; }
        public virtual DbSet<LU_SchemeMediaType> LU_SchemeMediaType { get; set; }
        public virtual DbSet<LU_SchemeName> LU_SchemeName { get; set; }
        public virtual DbSet<LU_Screen> LU_Screen { get; set; }
        public virtual DbSet<LU_ScreenDetail> LU_ScreenDetail { get; set; }
        public virtual DbSet<LU_ScreenFunction> LU_ScreenFunction { get; set; }
        public virtual DbSet<LU_User> LU_User { get; set; }
        public virtual DbSet<LU_UserGroup> LU_UserGroup { get; set; }
        public virtual DbSet<LU_UserLoginIds> LU_UserLoginIds { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TRN_Permission> TRN_Permission { get; set; }
        public virtual DbSet<TRN_PermissionDetail> TRN_PermissionDetail { get; set; }
        public virtual DbSet<pratdummy> pratdummies { get; set; }
        public virtual DbSet<TRN_SMkneet_t> TRN_SMkneet_t { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TRN_SchemeAuditShopDetails> TRN_SchemeAuditShopDetails { get; set; }
        public virtual DbSet<TRN_Number> TRN_Number { get; set; }
        public virtual DbSet<TRN_SchemeAuditChild> TRN_SchemeAuditChild { get; set; }
        public virtual DbSet<TRN_SchemeAuditParent> TRN_SchemeAuditParent { get; set; }
    }
}
