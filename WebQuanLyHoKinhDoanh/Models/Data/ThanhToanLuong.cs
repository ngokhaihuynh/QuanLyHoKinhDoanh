using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class ThanhToanLuong
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hộ kinh doanh là bắt buộc")]
        public int HoKinhDoanhId { get; set; }
        [ForeignKey("HoKinhDoanhId")]
        public virtual HoKinhDoanh HoKinhDoanh { get; set; }

        [Required(ErrorMessage = "Nhân viên là bắt buộc")]
        public int NhanVienId { get; set; }
        [ForeignKey("NhanVienId")]
        public virtual NhanVien NhanVien { get; set; }

        [Required(ErrorMessage = "Tháng là bắt buộc")]
        [Range(1, 12, ErrorMessage = "Tháng phải từ 1 đến 12")]
        public int Thang { get; set; }

        [Required(ErrorMessage = "Năm là bắt buộc")]
        [Range(2000, int.MaxValue, ErrorMessage = "Năm phải từ 2000 trở lên")]
        public int Nam { get; set; }

        [Required(ErrorMessage = "Số công là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Số công phải lớn hơn hoặc bằng 0")]
        public int SoCong { get; set; }

        [Required(ErrorMessage = "Tiền công là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Tiền công phải lớn hơn hoặc bằng 0")]
        public decimal TienCong { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số sản phẩm phải lớn hơn hoặc bằng 0")]
        public int? SoSanPham { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Tiền sản phẩm phải lớn hơn hoặc bằng 0")]
        public decimal? TienSanPham { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Phụ cấp phải lớn hơn hoặc bằng 0")]
        public decimal PhuCap { get; set; } = 0;

        [Range(0, double.MaxValue, ErrorMessage = "Thưởng phải lớn hơn hoặc bằng 0")]
        public decimal Thuong { get; set; } = 0;

        [Range(0, double.MaxValue, ErrorMessage = "Lương nghỉ phải lớn hơn hoặc bằng 0")]
        public decimal LuongNghi { get; set; } = 0;

        public virtual ICollection<ChungTu> ChungTus { get; set; }
    }
}