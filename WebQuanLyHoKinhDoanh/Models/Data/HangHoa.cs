using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class HangHoa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên hàng hóa là bắt buộc")]
        [StringLength(255, ErrorMessage = "Tên hàng hóa không được vượt quá 255 ký tự")]
        public string TenHangHoa { get; set; }

        [Required(ErrorMessage = "Đơn vị tính là bắt buộc")]
        public int DonViTinhId { get; set; }
        [ForeignKey("DonViTinhId")]
        public virtual DonViTinh DonViTinh { get; set; }

        [Required(ErrorMessage = "Giá nhập là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá nhập phải lớn hơn hoặc bằng 0")]
        public decimal GiaNhap { get; set; }

        [Required(ErrorMessage = "Giá xuất là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá xuất phải lớn hơn hoặc bằng 0")]
        public decimal GiaXuat { get; set; }

        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}