﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Hotel_ManagementEntities : DbContext
    {
        public Hotel_ManagementEntities()
            : base("name=Hotel_ManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietHoaDonDichVu> ChiTietHoaDonDichVus { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuThue> PhieuThues { get; set; }
        public virtual DbSet<PhieuThuePhong> PhieuThuePhongs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<TaiKhoanKH> TaiKhoanKHs { get; set; }
        public virtual DbSet<TaiKhoanNV> TaiKhoanNVs { get; set; }
    }
}