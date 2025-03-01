using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class PhieuNhapKho
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hộ kinh doanh là bắt buộc")]
        public int HoKinhDoanhId { get; set; }
        [ForeignKey("HoKinhDoanhId")]
        public virtual HoKinhDoanh HoKinhDoanh { get; set; }

        [StringLength(50, ErrorMessage = "Số phiếu không được vượt quá 50 ký tự")]
        public string SoPhieu { get; set; }

        public DateTime? NgayNhap { get; set; }

        [Required(ErrorMessage = "Nhà cung cấp là bắt buộc")]
        public int NhaCungCapId { get; set; }
        [ForeignKey("NhaCungCapId")]
        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual ICollection<ChungTu> ChungTus { get; set; }
    }
}