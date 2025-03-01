using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class HoKinhDoanh
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên hộ kinh doanh là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên hộ kinh doanh không được vượt quá 100 ký tự")]
        public string TenHoKinhDoanh { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        [StringLength(255, ErrorMessage = "Địa chỉ không được vượt quá 255 ký tự")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Quy mô là bắt buộc")]
        [StringLength(50, ErrorMessage = "Quy mô không được vượt quá 50 ký tự")]
        public string QuyMo { get; set; }

        [StringLength(50, ErrorMessage = "Mã số thuế không được vượt quá 50 ký tự")]
        public string MaSoThue { get; set; }

        [Required(ErrorMessage = "UserId là bắt buộc")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
        public virtual ICollection<PhieuChi> PhieuChis { get; set; }
        public virtual ICollection<ThanhToanLuong> ThanhToanLuongs { get; set; }
        public virtual ICollection<Thue> Thues { get; set; }
        public virtual ICollection<QuyTienMat> QuyTienMats { get; set; }
        public virtual ICollection<SoTienGuiNganHang> SoTienGuiNganHangs { get; set; }
        public virtual ICollection<ChiPhi> ChiPhis { get; set; }
        public virtual ICollection<PhieuNhapKho> PhieuNhapKhos { get; set; }
        public virtual ICollection<PhieuXuatKho> PhieuXuatKhos { get; set; }
        public virtual ICollection<ChungTu> ChungTus { get; set; }
    }
}