using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class SoTienGuiNganHang
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hộ kinh doanh là bắt buộc")]
        public int HoKinhDoanhId { get; set; }
        [ForeignKey("HoKinhDoanhId")]
        public virtual HoKinhDoanh HoKinhDoanh { get; set; }

        public decimal? SoTien { get; set; }

        public DateTime? NgayGiaoDich { get; set; }

        [StringLength(255, ErrorMessage = "Mô tả không được vượt quá 255 ký tự")]
        public string MoTa { get; set; }

        [StringLength(10, ErrorMessage = "Loại giao dịch không được vượt quá 10 ký tự")]
        public string LoaiGiaoDich { get; set; }

        public virtual ICollection<ChungTu> ChungTus { get; set; }
    }
}