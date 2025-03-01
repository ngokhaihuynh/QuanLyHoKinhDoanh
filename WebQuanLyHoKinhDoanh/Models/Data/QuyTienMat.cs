using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class QuyTienMat
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hộ kinh doanh là bắt buộc")]
        public int HoKinhDoanhId { get; set; }
        [ForeignKey("HoKinhDoanhId")]
        public virtual HoKinhDoanh HoKinhDoanh { get; set; }

        [Required(ErrorMessage = "Số tiền là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn hoặc bằng 0")]
        public decimal SoTien { get; set; }

        [Required(ErrorMessage = "Ngày giao dịch là bắt buộc")]
        public DateTime NgayGiaoDich { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Loại giao dịch là bắt buộc")]
        [StringLength(10, ErrorMessage = "Loại giao dịch không được vượt quá 10 ký tự")]
        public string LoaiGiaoDich { get; set; }

        [StringLength(255, ErrorMessage = "Mô tả không được vượt quá 255 ký tự")]
        public string MoTa { get; set; }

        public virtual ICollection<ChungTu> ChungTus { get; set; }
    }
}