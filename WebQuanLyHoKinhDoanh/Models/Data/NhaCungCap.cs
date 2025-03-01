using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên nhà cung cấp là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên nhà cung cấp không được vượt quá 100 ký tự")]
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

        public virtual ICollection<PhieuChi> PhieuChis { get; set; }
        public virtual ICollection<ChiPhi> ChiPhis { get; set; }
        public virtual ICollection<PhieuNhapKho> PhieuNhapKhos { get; set; }
    }
}