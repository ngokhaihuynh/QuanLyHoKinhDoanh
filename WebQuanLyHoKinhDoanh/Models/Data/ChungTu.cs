using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyHoKinhDoanh.Models.Data
{
    public class ChungTu
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hộ kinh doanh là bắt buộc")]
        public int HoKinhDoanhId { get; set; }
        [ForeignKey("HoKinhDoanhId")]
        public virtual HoKinhDoanh HoKinhDoanh { get; set; }

        [Required(ErrorMessage = "Số chứng từ là bắt buộc")]
        [StringLength(50, ErrorMessage = "Số chứng từ không được vượt quá 50 ký tự")]
        public string SoChungTu { get; set; }

        [Required(ErrorMessage = "Ngày giao dịch là bắt buộc")]
        public DateTime NgayGiaoDich { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Loại giao dịch là bắt buộc")]
        [StringLength(50, ErrorMessage = "Loại giao dịch không được vượt quá 50 ký tự")]
        public string LoaiGiaoDich { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
        public string MoTa { get; set; }

        [StringLength(20, ErrorMessage = "Trạng thái không được vượt quá 20 ký tự")]
        public string TrangThai { get; set; } = "Hoàn tất";

        public int? PhieuThuId { get; set; }
        [ForeignKey("PhieuThuId")]
        public virtual PhieuThu PhieuThu { get; set; }

        public int? PhieuChiId { get; set; }
        [ForeignKey("PhieuChiId")]
        public virtual PhieuChi PhieuChi { get; set; }

        public int? PhieuNhapKhoId { get; set; }
        [ForeignKey("PhieuNhapKhoId")]
        public virtual PhieuNhapKho PhieuNhapKho { get; set; }

        public int? PhieuXuatKhoId { get; set; }
        [ForeignKey("PhieuXuatKhoId")]
        public virtual PhieuXuatKho PhieuXuatKho { get; set; }

        public int? ThanhToanLuongId { get; set; }
        [ForeignKey("ThanhToanLuongId")]
        public virtual ThanhToanLuong ThanhToanLuong { get; set; }

        public int? ThueId { get; set; }
        [ForeignKey("ThueId")]
        public virtual Thue Thue { get; set; }

        public int? QuyTienMatId { get; set; }
        [ForeignKey("QuyTienMatId")]
        public virtual QuyTienMat QuyTienMat { get; set; }

        public int? SoTienGuiNganHangId { get; set; }
        [ForeignKey("SoTienGuiNganHangId")]
        public virtual SoTienGuiNganHang SoTienGuiNganHang { get; set; }

        public int? ChiPhiId { get; set; }
        [ForeignKey("ChiPhiId")]
        public virtual ChiPhi ChiPhi { get; set; }
    }
}