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
    
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            this.PhieuThuePhongs = new HashSet<PhieuThuePhong>();
        }
    
        public string MaPhong { get; set; }
        public bool HienTrang { get; set; }
        public string MaLoaiPhong { get; set; }
    
        public virtual LoaiPhong LoaiPhong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThuePhong> PhieuThuePhongs { get; set; }
    }
}
