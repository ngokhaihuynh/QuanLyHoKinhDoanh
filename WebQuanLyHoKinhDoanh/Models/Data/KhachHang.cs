using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class KhachHang
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên khách hàng là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên khách hàng không được vượt quá 100 ký tự")]
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

        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
        public virtual ICollection<PhieuXuatKho> PhieuXuatKhos { get; set; }
    }
}