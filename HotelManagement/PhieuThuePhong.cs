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
    
    public partial class PhieuThuePhong
    {
        public int MaPhieu { get; set; }
        public string MaPhong { get; set; }
        public Nullable<byte> SoNguoiO { get; set; }
    
        public virtual PhieuThue PhieuThue { get; set; }
        public virtual Phong Phong { get; set; }
    }
}