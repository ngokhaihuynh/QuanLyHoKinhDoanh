using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class Thue
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hộ kinh doanh là bắt buộc")]
        public int HoKinhDoanhId { get; set; }
        [ForeignKey("HoKinhDoanhId")]
        public virtual HoKinhDoanh HoKinhDoanh { get; set; }

        [StringLength(50, ErrorMessage = "Loại thuế không được vượt quá 50 ký tự")]
        public string LoaiThue { get; set; }

        public decimal? SoTien { get; set; }

        public DateTime? NgayNop { get; set; }

        public decimal SoTienDaNop { get; set; } = 0;

        [StringLength(10, ErrorMessage = "Kỳ kê khai không được vượt quá 10 ký tự")]
        public string KyKeKhai { get; set; }

        [StringLength(10, ErrorMessage = "Trạng thái nộp không được vượt quá 10 ký tự")]
        public string TrangThaiNop { get; set; } = "Chưa nộp";

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? SoTienConLai => SoTien - SoTienDaNop;

        public virtual ICollection<ChungTu> ChungTus { get; set; }
    }
}