using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class PhieuThu
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hộ kinh doanh là bắt buộc")]
        public int HoKinhDoanhId { get; set; }

        [ForeignKey("HoKinhDoanhId")]
        public virtual HoKinhDoanh HoKinhDoanh { get; set; }

        [Required(ErrorMessage = "Số phiếu là bắt buộc")]
        [StringLength(50, ErrorMessage = "Số phiếu không được vượt quá 50 ký tự")]
        public string SoPhieu { get; set; }

        [Required(ErrorMessage = "Ngày thu là bắt buộc")]
        public DateTime NgayThu { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Số tiền là bắt buộc")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        public decimal SoTien { get; set; }

        [Required(ErrorMessage = "Khách hàng là bắt buộc")]
        public int KhachHangId { get; set; }

        [ForeignKey("KhachHangId")]
        public virtual KhachHang KhachHang { get; set; }

        [Required(ErrorMessage = "Lý do nộp tiền là bắt buộc")]
        [StringLength(500, ErrorMessage = "Lý do nộp tiền không được vượt quá 500 ký tự")]
        public string LyDoNopTien { get; set; }

        public virtual ICollection<ChungTu> ChungTus { get; set; }
    }
}