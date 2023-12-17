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
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.HoaDons = new HashSet<HoaDon>();
            this.PhieuThues = new HashSet<PhieuThue>();
            this.TaiKhoanKHs = new HashSet<TaiKhoanKH>();
        }

        [DisplayName("Guest ID")]
        public int MaKhachHang { get; set; }

        [DisplayName("ID Number")]
        [Required(ErrorMessage = "Số CCCD khách hàng không được để trống.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Số CCCD phải là 12 chữ số.")]
        [CustomValidation(typeof(KhachHang), "ValidateCCCDAndPhone")]
        public string CCCD { get; set; }

        [DisplayName("Guest Name")]
        [Required(ErrorMessage = "Họ tên khách hàng không được để trống.")]
        public string TenKhachHang { get; set; }

        [DisplayName("Guest Categories")]
        public string LoaiKhachHang { get; set; }

        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Ngày sinh khách hàng chưa được chọn.")]
        [CustomValidation(typeof(KhachHang), "ValidateDateOfBirth")]
        public System.DateTime? NgaySinh { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải là 10 chữ số.")]
        [CustomValidation(typeof(KhachHang), "ValidateCCCDAndPhone")]
        public string SoDienThoai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThue> PhieuThues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoanKH> TaiKhoanKHs { get; set; }

        public static ValidationResult ValidateDateOfBirth(DateTime? ngaySinh, ValidationContext context)
        {
            if (ngaySinh.HasValue)
            {
                DateTime currentDate = DateTime.Now;

                // Tính toán số tuổi
                int age = currentDate.Year - ngaySinh.Value.Year;

                // Kiểm tra nếu ngày sinh sau ngày hiện tại thì giảm tuổi đi 1
                if (ngaySinh.Value.Date > currentDate.Date)
                {
                    age--;
                }

                // Kiểm tra nếu tuổi nhỏ hơn 18
                if (age < 18)
                {
                    return new ValidationResult("Khách hàng phải đủ 18 tuổi trở lên.");
                }
            }

            return ValidationResult.Success;
        }

        public static ValidationResult ValidateCCCDAndPhone(string value, ValidationContext context)
        {
            string fieldValue = value;
            string propertyName = context.MemberName;
            string violationMessage = "";

            if ((propertyName == "CCCD" || propertyName == "SoDienThoai") && !string.IsNullOrEmpty(fieldValue))
            {
                KhachHang customer = context.ObjectInstance as KhachHang;

                Hotel_ManagementEntities dbContext = new Hotel_ManagementEntities();
                var customers = dbContext.KhachHangs.ToList();

                if (customers != null)
                {
                    KhachHang existingCustomerCCCD = customers.FirstOrDefault(e =>
                        propertyName == "CCCD" && e.CCCD == fieldValue && e.MaKhachHang != customer.MaKhachHang);

                    KhachHang existingCustomerPhone = customers.FirstOrDefault(e =>
                        propertyName == "SoDienThoai" && e.SoDienThoai == fieldValue && e.MaKhachHang != customer.MaKhachHang);

                    if (existingCustomerCCCD != null)
                    {
                        violationMessage += "CCCD đã tồn tại cho khách hàng khác. ";
                    }

                    if (existingCustomerPhone != null)
                    {
                        violationMessage += "Số điện thoại đã tồn tại cho khách hàng khác. ";
                    }

                    if (!string.IsNullOrEmpty(violationMessage))
                    {
                        return new ValidationResult(violationMessage.Trim());
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
