﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTL_WebBanSach05.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebBanSach9Entities : DbContext
    {
        public WebBanSach9Entities()
            : base("name=WebBanSach9Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<HOADONBAN> HOADONBANs { get; set; }
        public virtual DbSet<HOADONNHAP> HOADONNHAPs { get; set; }
        public virtual DbSet<NHACC> NHACCs { get; set; }
        public virtual DbSet<NXB> NXBs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }
        public virtual DbSet<TAIKHOANADMIN> TAIKHOANADMINs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }
        public virtual DbSet<TK_KHACHHANG> TK_KHACHHANG { get; set; }
        public virtual DbSet<CT_HDBAN> CT_HDBAN { get; set; }
        public virtual DbSet<CT_HDNHAP> CT_HDNHAP { get; set; }
    }
}
