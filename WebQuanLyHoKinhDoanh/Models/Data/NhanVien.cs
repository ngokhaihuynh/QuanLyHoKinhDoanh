using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class NhanVien
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên nhân viên là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên nhân viên không được vượt quá 100 ký tự")]
        public string Ten { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        [StringLength(255, ErrorMessage = "Địa chỉ không được vượt quá 255 ký tự")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [StringLength(20, ErrorMessage = "Số điện thoại không được vượt quá 20 ký tự")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Mã số thuế là bắt buộc")]
        [StringLength(50, ErrorMessage = "Mã số thuế không được vượt quá 50 ký tự")]
        public string MaSoThue { get; set; }

        [Required(ErrorMessage = "Tỷ lệ BHXH là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Tỷ lệ BHXH phải lớn hơn hoặc bằng 0")]
        public decimal TyLeBHXH { get; set; } = 8;

        [Required(ErrorMessage = "Tỷ lệ BHYT là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Tỷ lệ BHYT phải lớn hơn hoặc bằng 0")]
        public double TyLeBHYT { get; set; } = 1.5;

        [Required(ErrorMessage = "Tỷ lệ BHTN là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Tỷ lệ BHTN phải lớn hơn hoặc bằng 0")]
        public decimal TyLeBHTN { get; set; } = 1;

        public virtual ICollection<PhieuChi> PhieuChis { get; set; }
        public virtual ICollection<ChiPhi> ChiPhis { get; set; }
        public virtual ICollection<ThanhToanLuong> ThanhToanLuongs { get; set; }
        public virtual ICollection<ChamCong> ChamCongs { get; set; }
    }
}