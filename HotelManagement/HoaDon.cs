//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            this.ChiTietHoaDonDichVus = new HashSet<ChiTietHoaDonDichVu>();
        }
    
        public string MaHoaDon { get; set; }
        public System.DateTime NgayLapHoaDon { get; set; }
        public decimal TienPhong { get; set; }
        public Nullable<decimal> TienDichVu { get; set; }
        public int MaKhachHang { get; set; }
        public int MaNhanVien { get; set; }
        public int MaPhieu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonDichVu> ChiTietHoaDonDichVus { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual PhieuThue PhieuThue { get; set; }
    }
}