using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class ChamCong
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nhân viên là bắt buộc")]
        public int NhanVienId { get; set; }
        [ForeignKey("NhanVienId")]
        public virtual NhanVien NhanVien { get; set; }

        [Required(ErrorMessage = "Ngày là bắt buộc")]
        public DateTime Ngay { get; set; }

        [Required(ErrorMessage = "Ca làm là bắt buộc")]
        [StringLength(50, ErrorMessage = "Ca làm không được vượt quá 50 ký tự")]
        public string CaLam { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Số công hưởng lương phải lớn hơn hoặc bằng 0")]
        public decimal SoCongHuongLuong { get; set; } = 0;

        [Range(0, double.MaxValue, ErrorMessage = "Số công nghỉ phải lớn hơn hoặc bằng 0")]
        public decimal SoCongNghi { get; set; } = 0;

        [Range(0, double.MaxValue, ErrorMessage = "Số công ngừng phải lớn hơn hoặc bằng 0")]
        public decimal SoCongNgung { get; set; } = 0;

        [Range(0, 100, ErrorMessage = "Phần trăm lương phải từ 0 đến 100")]
        public decimal PhanTramLuong { get; set; } = 0;
    }
}