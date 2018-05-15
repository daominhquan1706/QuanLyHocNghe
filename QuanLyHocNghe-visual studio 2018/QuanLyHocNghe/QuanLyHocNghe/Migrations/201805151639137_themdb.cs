namespace QuanLyHocNghe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        IDSinhVien = c.String(nullable: false, maxLength: 128),
                        MSSV = c.Int(nullable: false),
                        HoTen = c.String(),
                        DiaChi = c.String(),
                        NgonNguLapTrinh = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        TrinhDoHocVan = c.String(),
                        DiemTOEFL = c.Int(),
                        TinhTrangSinhVien = c.String(),
                        DiemThiTracNghiem = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDSinhVien)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ChungChiSinhViens",
                c => new
                    {
                        MaChungChiSinhVien = c.Int(nullable: false, identity: true),
                        IDSinhVien = c.String(maxLength: 128),
                        MaChungChi = c.Int(nullable: false),
                        NgayNhanChungChi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaChungChiSinhVien)
                .ForeignKey("dbo.ChungChis", t => t.MaChungChi, cascadeDelete: true)
                .ForeignKey("dbo.SinhViens", t => t.IDSinhVien)
                .Index(t => t.IDSinhVien)
                .Index(t => t.MaChungChi);
            
            CreateTable(
                "dbo.ChungChis",
                c => new
                    {
                        MaChungChi = c.Int(nullable: false, identity: true),
                        TenChungChi = c.String(),
                    })
                .PrimaryKey(t => t.MaChungChi);
            
            CreateTable(
                "dbo.HopDongs",
                c => new
                    {
                        MaHopDong = c.String(nullable: false, maxLength: 128),
                        IDSinhVien = c.String(maxLength: 128),
                        IDHuanLuyenVien = c.String(maxLength: 128),
                        NgayTaoHopDong = c.DateTime(nullable: false),
                        NgayKetThucHopDong = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaHopDong)
                .ForeignKey("dbo.HuanLuyenViens", t => t.IDHuanLuyenVien)
                .ForeignKey("dbo.SinhViens", t => t.IDSinhVien)
                .Index(t => t.IDSinhVien)
                .Index(t => t.IDHuanLuyenVien);
            
            CreateTable(
                "dbo.HuanLuyenViens",
                c => new
                    {
                        IDHuanLuyenVien = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(),
                        DienThoai = c.String(),
                        BoPhan = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDHuanLuyenVien)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HopDongs", "IDSinhVien", "dbo.SinhViens");
            DropForeignKey("dbo.HopDongs", "IDHuanLuyenVien", "dbo.HuanLuyenViens");
            DropForeignKey("dbo.HuanLuyenViens", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChungChiSinhViens", "IDSinhVien", "dbo.SinhViens");
            DropForeignKey("dbo.ChungChiSinhViens", "MaChungChi", "dbo.ChungChis");
            DropForeignKey("dbo.SinhViens", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.HuanLuyenViens", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.HopDongs", new[] { "IDHuanLuyenVien" });
            DropIndex("dbo.HopDongs", new[] { "IDSinhVien" });
            DropIndex("dbo.ChungChiSinhViens", new[] { "MaChungChi" });
            DropIndex("dbo.ChungChiSinhViens", new[] { "IDSinhVien" });
            DropIndex("dbo.SinhViens", new[] { "ApplicationUser_Id" });
            DropTable("dbo.HuanLuyenViens");
            DropTable("dbo.HopDongs");
            DropTable("dbo.ChungChis");
            DropTable("dbo.ChungChiSinhViens");
            DropTable("dbo.SinhViens");
        }
    }
}
