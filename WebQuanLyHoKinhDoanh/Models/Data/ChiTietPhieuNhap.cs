using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class ChiTietPhieuNhap
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Phiếu nhập kho là bắt buộc")]
        public int PhieuNhapId { get; set; }
        [ForeignKey("PhieuNhapId")]
        public virtual PhieuNhapKho PhieuNhapKho { get; set; }

        [Required(ErrorMessage = "Hàng hóa là bắt buộc")]
        public int HangHoaId { get; set; }
        [ForeignKey("HangHoaId")]
        public virtual HangHoa HangHoa { get; set; }

        [Required(ErrorMessage = "Đơn vị tính là bắt buộc")]
        public int DonViTinhId { get; set; }
        [ForeignKey("DonViTinhId")]
        public virtual DonViTinh DonViTinh { get; set; }

        [Required(ErrorMessage = "Số lượng là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 0")]
        public int SoLuong { get; set; }
    }
}