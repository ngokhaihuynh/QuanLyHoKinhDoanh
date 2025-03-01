namespace WebQuanLyHoKinhDoanh.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateDatabaseWithCodeFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChamCongs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    NhanVienId = c.Int(nullable: false),
                    Ngay = c.DateTime(nullable: false),
                    CaLam = c.String(nullable: false, maxLength: 50),
                    SoCongHuongLuong = c.Decimal(nullable: false, precision: 18, scale: 2),
                    SoCongNghi = c.Decimal(nullable: false, precision: 18, scale: 2),
                    SoCongNgung = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PhanTramLuong = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhanViens", t => t.NhanVienId, cascadeDelete: true)
                .Index(t => t.NhanVienId);

            CreateTable(
                "dbo.NhanViens",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Ten = c.String(nullable: false, maxLength: 100),
                    DiaChi = c.String(nullable: false, maxLength: 255),
                    SoDienThoai = c.String(nullable: false, maxLength: 20),
                    MaSoThue = c.String(nullable: false, maxLength: 50),
                    TyLeBHXH = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TyLeBHYT = c.Double(nullable: false),
                    TyLeBHTN = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SoDienThoai, unique: true);

            CreateTable(
                "dbo.ChiPhis",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HoKinhDoanhId = c.Int(nullable: false),
                    SoTien = c.Decimal(precision: 18, scale: 2),
                    LoaiChiPhi = c.String(maxLength: 50),
                    NgayChi = c.DateTime(),
                    NhaCungCapId = c.Int(),
                    NhanVienId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoKinhDoanhs", t => t.HoKinhDoanhId, cascadeDelete: true)
                .ForeignKey("dbo.NhaCungCaps", t => t.NhaCungCapId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.NhanViens", t => t.NhanVienId, cascadeDelete: false) // Tắt CASCADE
                .Index(t => t.HoKinhDoanhId)
                .Index(t => t.NhaCungCapId)
                .Index(t => t.NhanVienId);

            CreateTable(
                "dbo.ChungTus",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HoKinhDoanhId = c.Int(nullable: false),
                    SoChungTu = c.String(nullable: false, maxLength: 50),
                    NgayGiaoDich = c.DateTime(nullable: false),
                    LoaiGiaoDich = c.String(nullable: false, maxLength: 50),
                    MoTa = c.String(maxLength: 500),
                    TrangThai = c.String(maxLength: 20),
                    PhieuThuId = c.Int(),
                    PhieuChiId = c.Int(),
                    PhieuNhapKhoId = c.Int(),
                    PhieuXuatKhoId = c.Int(),
                    ThanhToanLuongId = c.Int(),
                    ThueId = c.Int(),
                    QuyTienMatId = c.Int(),
                    SoTienGuiNganHangId = c.Int(),
                    ChiPhiId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChiPhis", t => t.ChiPhiId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.HoKinhDoanhs", t => t.HoKinhDoanhId, cascadeDelete: true)
                .ForeignKey("dbo.PhieuChis", t => t.PhieuChiId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.PhieuXuatKhoes", t => t.PhieuXuatKhoId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.PhieuThus", t => t.PhieuThuId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.PhieuNhapKhoes", t => t.PhieuNhapKhoId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.QuyTienMats", t => t.QuyTienMatId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.SoTienGuiNganHangs", t => t.SoTienGuiNganHangId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.ThanhToanLuongs", t => t.ThanhToanLuongId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.Thues", t => t.ThueId, cascadeDelete: false) // Tắt CASCADE
                .Index(t => t.HoKinhDoanhId)
                .Index(t => t.SoChungTu, unique: true)
                .Index(t => t.PhieuThuId)
                .Index(t => t.PhieuChiId)
                .Index(t => t.PhieuNhapKhoId)
                .Index(t => t.PhieuXuatKhoId)
                .Index(t => t.ThanhToanLuongId)
                .Index(t => t.ThueId)
                .Index(t => t.QuyTienMatId)
                .Index(t => t.SoTienGuiNganHangId)
                .Index(t => t.ChiPhiId);

            CreateTable(
                "dbo.HoKinhDoanhs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenHoKinhDoanh = c.String(nullable: false, maxLength: 100),
                    DiaChi = c.String(nullable: false, maxLength: 255),
                    QuyMo = c.String(nullable: false, maxLength: 50),
                    MaSoThue = c.String(maxLength: 50),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TenHoKinhDoanh, unique: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.PhieuChis",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HoKinhDoanhId = c.Int(nullable: false),
                    SoPhieu = c.String(nullable: false, maxLength: 50),
                    NgayChi = c.DateTime(nullable: false),
                    SoTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    NhaCungCapId = c.Int(),
                    NhanVienId = c.Int(),
                    LyDoChi = c.String(nullable: false, maxLength: 500),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoKinhDoanhs", t => t.HoKinhDoanhId, cascadeDelete: true)
                .ForeignKey("dbo.NhaCungCaps", t => t.NhaCungCapId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.NhanViens", t => t.NhanVienId, cascadeDelete: false) // Tắt CASCADE
                .Index(t => t.HoKinhDoanhId)
                .Index(t => t.SoPhieu, unique: true)
                .Index(t => t.NhaCungCapId)
                .Index(t => t.NhanVienId);

            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Ten = c.String(nullable: false, maxLength: 100),
                    DiaChi = c.String(nullable: false, maxLength: 255),
                    SoDienThoai = c.String(nullable: false, maxLength: 20),
                    MaSoThue = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SoDienThoai, unique: true);

            CreateTable(
                "dbo.PhieuNhapKhoes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HoKinhDoanhId = c.Int(nullable: false),
                    SoPhieu = c.String(maxLength: 50),
                    NgayNhap = c.DateTime(),
                    NhaCungCapId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoKinhDoanhs", t => t.HoKinhDoanhId, cascadeDelete: true)
                .ForeignKey("dbo.NhaCungCaps", t => t.NhaCungCapId, cascadeDelete: false) // Tắt CASCADE
                .Index(t => t.HoKinhDoanhId)
                .Index(t => t.NhaCungCapId);

            CreateTable(
                "dbo.ChiTietPhieuNhaps",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PhieuNhapId = c.Int(nullable: false),
                    HangHoaId = c.Int(nullable: false),
                    DonViTinhId = c.Int(nullable: false),
                    SoLuong = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DonViTinhs", t => t.DonViTinhId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.HangHoas", t => t.HangHoaId, cascadeDelete: true)
                .ForeignKey("dbo.PhieuNhapKhoes", t => t.PhieuNhapId, cascadeDelete: true)
                .Index(t => t.PhieuNhapId)
                .Index(t => t.HangHoaId)
                .Index(t => t.DonViTinhId);

            CreateTable(
                "dbo.DonViTinhs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenDonVi = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenDonVi, unique: true);

            CreateTable(
                "dbo.ChiTietPhieuXuats",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PhieuXuatId = c.Int(nullable: false),
                    HangHoaId = c.Int(nullable: false),
                    DonViTinhId = c.Int(nullable: false),
                    SoLuong = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DonViTinhs", t => t.DonViTinhId, cascadeDelete: false) // Tắt CASCADE
                .ForeignKey("dbo.HangHoas", t => t.HangHoaId, cascadeDelete: true)
                .ForeignKey("dbo.PhieuXuatKhoes", t => t.PhieuXuatId, cascadeDelete: true)
                .Index(t => t.PhieuXuatId)
                .Index(t => t.HangHoaId)
                .Index(t => t.DonViTinhId);

            CreateTable(
                "dbo.HangHoas",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenHangHoa = c.String(nullable: false, maxLength: 255),
                    DonViTinhId = c.Int(nullable: false),
                    GiaNhap = c.Decimal(nullable: false, precision: 18, scale: 2),
                    GiaXuat = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DonViTinhs", t => t.DonViTinhId, cascadeDelete: false) // Tắt CASCADE
                .Index(t => t.TenHangHoa, unique: true)
                .Index(t => t.DonViTinhId);

            CreateTable(
                "dbo.PhieuXuatKhoes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HoKinhDoanhId = c.Int(nullable: false),
                    SoPhieu = c.String(maxLength: 50),
                    NgayXuat = c.DateTime(),
                    KhachHangId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoKinhDoanhs", t => t.HoKinhDoanhId, cascadeDelete: true)
                .ForeignKey("dbo.KhachHangs", t => t.KhachHangId, cascadeDelete: false) // Tắt CASCADE
                .Index(t => t.HoKinhDoanhId)
                .Index(t => t.KhachHangId);

            CreateTable(
                "dbo.KhachHangs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Ten = c.String(nullable: false, maxLength: 100),
                    DiaChi = c.String(nullable: false, maxLength: 255),
                    SoDienThoai = c.String(nullable: false, maxLength: 20),
                    MaSoThue = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SoDienThoai, unique: true);

            CreateTable(
                "dbo.PhieuThus",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HoKinhDoanhId = c.Int(nullable: false),
                    SoPhieu = c.String(nullable: false, maxLength: 50),
                    NgayThu = c.DateTime(nullable: false),
                    SoTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    KhachHangId = c.Int(nullable: false),
                    LyDoNopTien = c.String(nullable: false, maxLength: 500),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoKinhDoanhs", t => t.HoKinhDoanhId, cascadeDelete: true)
                .ForeignKey("dbo.KhachHangs", t => t.KhachHangId, cascadeDelete: false) // Tắt CASCADE
                .Index(t => t.HoKinhDoanhId)
                .Index(t => t.SoPhieu, unique: true)
                .Index(t => t.KhachHangId);

            CreateTable(
                "dbo.QuyTienMats",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HoKinhDoanhId = c.Int(nullable: false),
                    SoTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                    NgayGiaoDich = c.DateTime(nullable: false),
                    LoaiGiaoDich = c.String(nullable: false, maxLength: 10),
                    MoTa = c.String(maxLength: 255),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoKinhDoanhs", t => t.HoKinhDoanhId, cascadeDelete: true)
                .Index(t => t.HoKinhDoanhId);

            CreateTable(
                "dbo.SoTienGuiNganHangs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HoKinhDoanhId = c.Int(nullable: false),
                    SoTien = c.Decimal(precision: 18, scale: 2),
                    NgayGiaoDich = c.DateTime(),
                    MoTa = c.String(maxLength: 255),
                    LoaiGiaoDich = c.String(maxLength: 10),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoKinhDoanhs", t => t.HoKinhDoanhId, cascadeDelete: true)
                .Index(t => t.HoKinhDoanhId);

            CreateTable(
                "dbo.ThanhToanLuongs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HoKinhDoanhId = c.Int(nullable: false),
                    NhanVienId = c.Int(nullable: false),
                    Thang = c.Int(nullable: false),
                    Nam = c.Int(nullable: false),
                    SoCong = c.Int(nullable: false),
                    TienCong = c.Decimal(nullable: false, precision: 18, scale: 2),
                    SoSanPham = c.Int(),
                    TienSanPham = c.Decimal(precision: 18, scale: 2),
                    PhuCap = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Thuong = c.Decimal(nullable: false, precision: 18, scale: 2),
                    LuongNghi = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoKinhDoanhs", t => t.HoKinhDoanhId, cascadeDelete: true)
                .ForeignKey("dbo.NhanViens", t => t.NhanVienId, cascadeDelete: false) // Tắt CASCADE
                .Index(t => t.HoKinhDoanhId)
                .Index(t => t.NhanVienId);

            CreateTable(
                "dbo.Thues",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    HoKinhDoanhId = c.Int(nullable: false),
                    LoaiThue = c.String(maxLength: 50),
                    SoTien = c.Decimal(precision: 18, scale: 2),
                    NgayNop = c.DateTime(),
                    SoTienDaNop = c.Decimal(nullable: false, precision: 18, scale: 2),
                    KyKeKhai = c.String(maxLength: 10),
                    TrangThaiNop = c.String(maxLength: 10),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HoKinhDoanhs", t => t.HoKinhDoanhId, cascadeDelete: true)
                .Index(t => t.HoKinhDoanhId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    HoTen = c.String(),
                    NgayDangKy = c.DateTime(nullable: false),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ChiPhis", "NhanVienId", "dbo.NhanViens");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HoKinhDoanhs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Thues", "HoKinhDoanhId", "dbo.HoKinhDoanhs");
            DropForeignKey("dbo.ChungTus", "ThueId", "dbo.Thues");
            DropForeignKey("dbo.ThanhToanLuongs", "NhanVienId", "dbo.NhanViens");
            DropForeignKey("dbo.ThanhToanLuongs", "HoKinhDoanhId", "dbo.HoKinhDoanhs");
            DropForeignKey("dbo.ChungTus", "ThanhToanLuongId", "dbo.ThanhToanLuongs");
            DropForeignKey("dbo.SoTienGuiNganHangs", "HoKinhDoanhId", "dbo.HoKinhDoanhs");
            DropForeignKey("dbo.ChungTus", "SoTienGuiNganHangId", "dbo.SoTienGuiNganHangs");
            DropForeignKey("dbo.QuyTienMats", "HoKinhDoanhId", "dbo.HoKinhDoanhs");
            DropForeignKey("dbo.ChungTus", "QuyTienMatId", "dbo.QuyTienMats");
            DropForeignKey("dbo.PhieuChis", "NhanVienId", "dbo.NhanViens");
            DropForeignKey("dbo.PhieuNhapKhoes", "NhaCungCapId", "dbo.NhaCungCaps");
            DropForeignKey("dbo.PhieuNhapKhoes", "HoKinhDoanhId", "dbo.HoKinhDoanhs");
            DropForeignKey("dbo.ChungTus", "PhieuNhapKhoId", "dbo.PhieuNhapKhoes");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "PhieuNhapId", "dbo.PhieuNhapKhoes");
            DropForeignKey("dbo.PhieuXuatKhoes", "KhachHangId", "dbo.KhachHangs");
            DropForeignKey("dbo.PhieuThus", "KhachHangId", "dbo.KhachHangs");
            DropForeignKey("dbo.PhieuThus", "HoKinhDoanhId", "dbo.HoKinhDoanhs");
            DropForeignKey("dbo.ChungTus", "PhieuThuId", "dbo.PhieuThus");
            DropForeignKey("dbo.PhieuXuatKhoes", "HoKinhDoanhId", "dbo.HoKinhDoanhs");
            DropForeignKey("dbo.ChungTus", "PhieuXuatKhoId", "dbo.PhieuXuatKhoes");
            DropForeignKey("dbo.ChiTietPhieuXuats", "PhieuXuatId", "dbo.PhieuXuatKhoes");
            DropForeignKey("dbo.HangHoas", "DonViTinhId", "dbo.DonViTinhs");
            DropForeignKey("dbo.ChiTietPhieuXuats", "HangHoaId", "dbo.HangHoas");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "HangHoaId", "dbo.HangHoas");
            DropForeignKey("dbo.ChiTietPhieuXuats", "DonViTinhId", "dbo.DonViTinhs");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "DonViTinhId", "dbo.DonViTinhs");
            DropForeignKey("dbo.PhieuChis", "NhaCungCapId", "dbo.NhaCungCaps");
            DropForeignKey("dbo.ChiPhis", "NhaCungCapId", "dbo.NhaCungCaps");
            DropForeignKey("dbo.PhieuChis", "HoKinhDoanhId", "dbo.HoKinhDoanhs");
            DropForeignKey("dbo.ChungTus", "PhieuChiId", "dbo.PhieuChis");
            DropForeignKey("dbo.ChungTus", "HoKinhDoanhId", "dbo.HoKinhDoanhs");
            DropForeignKey("dbo.ChiPhis", "HoKinhDoanhId", "dbo.HoKinhDoanhs");
            DropForeignKey("dbo.ChungTus", "ChiPhiId", "dbo.ChiPhis");
            DropForeignKey("dbo.ChamCongs", "NhanVienId", "dbo.NhanViens");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Thues", new[] { "HoKinhDoanhId" });
            DropIndex("dbo.ThanhToanLuongs", new[] { "NhanVienId" });
            DropIndex("dbo.ThanhToanLuongs", new[] { "HoKinhDoanhId" });
            DropIndex("dbo.SoTienGuiNganHangs", new[] { "HoKinhDoanhId" });
            DropIndex("dbo.QuyTienMats", new[] { "HoKinhDoanhId" });
            DropIndex("dbo.PhieuThus", new[] { "KhachHangId" });
            DropIndex("dbo.PhieuThus", new[] { "HoKinhDoanhId" });
            DropIndex("dbo.PhieuThus", new[] { "SoPhieu" });
            DropIndex("dbo.PhieuXuatKhoes", new[] { "KhachHangId" });
            DropIndex("dbo.PhieuXuatKhoes", new[] { "HoKinhDoanhId" });
            DropIndex("dbo.HangHoas", new[] { "TenHangHoa" });
            DropIndex("dbo.HangHoas", new[] { "DonViTinhId" });
            DropIndex("dbo.ChiTietPhieuXuats", new[] { "DonViTinhId" });
            DropIndex("dbo.ChiTietPhieuXuats", new[] { "HangHoaId" });
            DropIndex("dbo.ChiTietPhieuXuats", new[] { "PhieuXuatId" });
            DropIndex("dbo.DonViTinhs", new[] { "TenDonVi" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "DonViTinhId" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "HangHoaId" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "PhieuNhapId" });
            DropIndex("dbo.PhieuNhapKhoes", new[] { "NhaCungCapId" });
            DropIndex("dbo.PhieuNhapKhoes", new[] { "HoKinhDoanhId" });
            DropIndex("dbo.NhaCungCaps", new[] { "SoDienThoai" });
            DropIndex("dbo.PhieuChis", new[] { "NhanVienId" });
            DropIndex("dbo.PhieuChis", new[] { "NhaCungCapId" });
            DropIndex("dbo.PhieuChis", new[] { "HoKinhDoanhId" });
            DropIndex("dbo.PhieuChis", new[] { "SoPhieu" });
            DropIndex("dbo.HoKinhDoanhs", new[] { "UserId" });
            DropIndex("dbo.HoKinhDoanhs", new[] { "TenHoKinhDoanh" });
            DropIndex("dbo.ChungTus", new[] { "ChiPhiId" });
            DropIndex("dbo.ChungTus", new[] { "SoTienGuiNganHangId" });
            DropIndex("dbo.ChungTus", new[] { "QuyTienMatId" });
            DropIndex("dbo.ChungTus", new[] { "ThueId" });
            DropIndex("dbo.ChungTus", new[] { "ThanhToanLuongId" });
            DropIndex("dbo.ChungTus", new[] { "PhieuXuatKhoId" });
            DropIndex("dbo.ChungTus", new[] { "PhieuNhapKhoId" });
            DropIndex("dbo.ChungTus", new[] { "PhieuChiId" });
            DropIndex("dbo.ChungTus", new[] { "PhieuThuId" });
            DropIndex("dbo.ChungTus", new[] { "HoKinhDoanhId" });
            DropIndex("dbo.ChungTus", new[] { "SoChungTu" });
            DropIndex("dbo.ChiPhis", new[] { "NhanVienId" });
            DropIndex("dbo.ChiPhis", new[] { "NhaCungCapId" });
            DropIndex("dbo.ChiPhis", new[] { "HoKinhDoanhId" });
            DropIndex("dbo.NhanViens", new[] { "SoDienThoai" });
            DropIndex("dbo.ChamCongs", new[] { "NhanVienId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Thues");
            DropTable("dbo.ThanhToanLuongs");
            DropTable("dbo.SoTienGuiNganHangs");
            DropTable("dbo.QuyTienMats");
            DropTable("dbo.PhieuThus");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.PhieuXuatKhoes");
            DropTable("dbo.HangHoas");
            DropTable("dbo.ChiTietPhieuXuats");
            DropTable("dbo.DonViTinhs");
            DropTable("dbo.ChiTietPhieuNhaps");
            DropTable("dbo.PhieuNhapKhoes");
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.PhieuChis");
            DropTable("dbo.HoKinhDoanhs");
            DropTable("dbo.ChungTus");
            DropTable("dbo.ChiPhis");
            DropTable("dbo.NhanViens");
            DropTable("dbo.ChamCongs");
        }
    }
}