using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class ChiPhi
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hộ kinh doanh là bắt buộc")]
        public int HoKinhDoanhId { get; set; }
        [ForeignKey("HoKinhDoanhId")]
        public virtual HoKinhDoanh HoKinhDoanh { get; set; }

        public decimal? SoTien { get; set; }

        [StringLength(50, ErrorMessage = "Loại chi phí không được vượt quá 50 ký tự")]
        public string LoaiChiPhi { get; set; }

        public DateTime? NgayChi { get; set; }

        public int? NhaCungCapId { get; set; }
        [ForeignKey("NhaCungCapId")]
        public virtual NhaCungCap NhaCungCap { get; set; }

        public int? NhanVienId { get; set; }
        [ForeignKey("NhanVienId")]
        public virtual NhanVien NhanVien { get; set; }

        public virtual ICollection<ChungTu> ChungTus { get; set; }
    }
}