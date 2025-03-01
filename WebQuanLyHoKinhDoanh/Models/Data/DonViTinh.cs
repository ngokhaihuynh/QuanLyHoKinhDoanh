using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class DonViTinh
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đơn vị tính là bắt buộc")]
        [StringLength(50, ErrorMessage = "Tên đơn vị tính không được vượt quá 50 ký tự")]
        public string TenDonVi { get; set; }

        public virtual ICollection<HangHoa> HangHoas { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}