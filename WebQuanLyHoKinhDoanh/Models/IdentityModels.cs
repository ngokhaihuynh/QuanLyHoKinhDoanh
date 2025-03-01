using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebQuanLyHoKinhDoanh.Models.Data;

namespace WebQuanLyHoKinhDoanh.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string HoTen { get; set; }
        public DateTime NgayDangKy { get; set; } = DateTime.Now;

        // Một người dùng quản lý nhiều hộ kinh doanh
        public virtual ICollection<HoKinhDoanh> HoKinhDoanhs { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<HoKinhDoanh> HoKinhDoanhs { get; set; }
        public DbSet<DonViTinh> DonViTinhs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhieuThu> PhieuThus { get; set; }
        public DbSet<PhieuChi> PhieuChis { get; set; }
        public DbSet<ThanhToanLuong> ThanhToanLuongs { get; set; }
        public DbSet<ChamCong> ChamCongs { get; set; }
        public DbSet<Thue> Thues { get; set; }
        public DbSet<QuyTienMat> QuyTienMats { get; set; }
        public DbSet<SoTienGuiNganHang> SoTienGuiNganHangs { get; set; }
        public DbSet<ChiPhi> ChiPhis { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<PhieuNhapKho> PhieuNhapKhos { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<PhieuXuatKho> PhieuXuatKhos { get; set; }
        public DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public DbSet<ChungTu> ChungTus { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }







    }
}