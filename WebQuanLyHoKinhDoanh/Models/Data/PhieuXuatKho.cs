using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class PhieuXuatKho
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hộ kinh doanh là bắt buộc")]
        public int HoKinhDoanhId { get; set; }
        [ForeignKey("HoKinhDoanhId")]
        public virtual HoKinhDoanh HoKinhDoanh { get; set; }

        [StringLength(50, ErrorMessage = "Số phiếu không được vượt quá 50 ký tự")]
        public string SoPhieu { get; set; }

        public DateTime? NgayXuat { get; set; }

        [Required(ErrorMessage = "Khách hàng là bắt buộc")]
        public int KhachHangId { get; set; }
        [ForeignKey("KhachHangId")]
        public virtual KhachHang KhachHang { get; set; }

        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public virtual ICollection<ChungTu> ChungTus { get; set; }
    }
}