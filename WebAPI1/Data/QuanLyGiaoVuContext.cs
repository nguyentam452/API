using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI1.Data
{
    public partial class QuanLyGiaoVuContext : DbContext
    {
        public QuanLyGiaoVuContext()
        {
        }

        public QuanLyGiaoVuContext(DbContextOptions<QuanLyGiaoVuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CtDt> CtDts { get; set; } = null!;
        public virtual DbSet<CtPcGiangday> CtPcGiangdays { get; set; } = null!;
        public virtual DbSet<HsGiangvien> HsGiangviens { get; set; } = null!;
        public virtual DbSet<Khoa> Khoas { get; set; } = null!;
        public virtual DbSet<Khoadt> Khoadts { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<Monhoc> Monhocs { get; set; } = null!;
        public virtual DbSet<Nganh> Nganhs { get; set; } = null!;
        public virtual DbSet<PcGiangday> PcGiangdays { get; set; } = null!;
        public virtual DbSet<Phong> Phongs { get; set; } = null!;
        public virtual DbSet<QlTiendogd> QlTiendogds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=sql6.freesqldatabase.com;user=sql6582440;database=sql6582440;password=44xMrXnsuN;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.62-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<CtDt>(entity =>
            {
                entity.HasKey(e => e.MaHocPhan)
                    .HasName("PRIMARY");

                entity.ToTable("CT_DT");

                entity.HasIndex(e => e.MaKhoaDt, "FK_CTDT_maKhoa");

                entity.HasIndex(e => e.MaMon, "FK_CTDT_maMon");

                entity.Property(e => e.MaHocPhan)
                    .HasColumnType("int(11)")
                    .HasColumnName("maHocPhan");

                entity.Property(e => e.HocKy)
                    .HasColumnType("int(11)")
                    .HasColumnName("hocKy");

                entity.Property(e => e.MaKhoaDt)
                    .HasColumnType("int(11)")
                    .HasColumnName("maKhoaDT");

                entity.Property(e => e.MaMon)
                    .HasColumnType("int(11)")
                    .HasColumnName("maMon");

                entity.Property(e => e.Nam)
                    .HasColumnType("int(11)")
                    .HasColumnName("nam");

                entity.Property(e => e.SoTinChi)
                    .HasColumnType("int(11)")
                    .HasColumnName("soTinChi");

                entity.Property(e => e.Tcll)
                    .HasColumnType("int(11)")
                    .HasColumnName("TCLL");

                entity.Property(e => e.Tcth)
                    .HasColumnType("int(11)")
                    .HasColumnName("TCTH");

                entity.Property(e => e.TietDatLt)
                    .HasColumnType("int(11)")
                    .HasColumnName("tietDatLT");

                entity.Property(e => e.TietDayTh)
                    .HasColumnType("int(11)")
                    .HasColumnName("tietDayTH");

            });

            modelBuilder.Entity<CtPcGiangday>(entity =>
            {
                entity.HasKey(e => e.MaCtpcgd)
                    .HasName("PRIMARY");

                entity.ToTable("CT_PC_GIANGDAY");

                entity.HasIndex(e => e.MaGv, "FK_CT_PCGD_maGV");

                entity.HasIndex(e => e.MaPcgd, "FK_CT_PCGD_maPCGD");

                entity.HasIndex(e => e.MaPhong, "FK_CT_PCGD_maPhong");

                entity.Property(e => e.MaCtpcgd)
                    .HasColumnType("int(11)")
                    .HasColumnName("maCTPCGD");

                entity.Property(e => e.MaGv)
                    .HasColumnType("int(11)")
                    .HasColumnName("maGV");

                entity.Property(e => e.MaPcgd)
                    .HasColumnType("int(11)")
                    .HasColumnName("maPCGD");

                entity.Property(e => e.MaPhong)
                    .HasColumnType("int(11)")
                    .HasColumnName("maPhong");

                entity.Property(e => e.NgayBd).HasColumnName("ngayBD");

                entity.Property(e => e.NgayKt).HasColumnName("ngayKT");

            });

            modelBuilder.Entity<HsGiangvien>(entity =>
            {
                entity.HasKey(e => e.MaGv)
                    .HasName("PRIMARY");

                entity.ToTable("HS_GIANGVIEN");

                entity.HasIndex(e => e.MaKhoa, "FK_HSGV_maKhoa");

                entity.Property(e => e.MaGv)
                    .HasColumnType("int(11)")
                    .HasColumnName("maGV");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(4)
                    .HasColumnName("gioiTINH");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(50)
                    .HasColumnName("hoTEN");

                entity.Property(e => e.HocHam)
                    .HasMaxLength(10)
                    .HasColumnName("hocHAM");

                entity.Property(e => e.HocVi)
                    .HasMaxLength(10)
                    .HasColumnName("hocVI");

                entity.Property(e => e.MaKhoa)
                    .HasColumnType("int(11)")
                    .HasColumnName("maKhoa");

                entity.Property(e => e.Ngsinh).HasColumnName("NGSINH");

                entity.Property(e => e.Ngvl).HasColumnName("NGVL");

                entity.Property(e => e.SDt)
                    .HasMaxLength(11)
                    .HasColumnName("sDT")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa)
                    .HasName("PRIMARY");

                entity.ToTable("KHOA");

                entity.HasIndex(e => e.TrgKhoa, "FK_KHOA_TrgKhoa");

                entity.Property(e => e.MaKhoa)
                    .HasColumnType("int(11)")
                    .HasColumnName("maKhoa");

                entity.Property(e => e.TenKhoa)
                    .HasMaxLength(50)
                    .HasColumnName("tenKhoa")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TrgKhoa)
                    .HasColumnType("int(11)")
                    .HasColumnName("trgKhoa");

            });

            modelBuilder.Entity<Khoadt>(entity =>
            {
                entity.HasKey(e => e.MaKhoaDt)
                    .HasName("PRIMARY");

                entity.ToTable("KHOADT");

                entity.HasIndex(e => e.MaNganh, "FK_KHOADT_maNganh");

                entity.Property(e => e.MaKhoaDt)
                    .HasColumnType("int(11)")
                    .HasColumnName("maKhoaDT");

                entity.Property(e => e.MaNganh)
                    .HasColumnType("int(11)")
                    .HasColumnName("maNganh");

                entity.Property(e => e.NamNhap).HasColumnName("namNhap");

                entity.Property(e => e.SoNamDt)
                    .HasColumnType("int(11)")
                    .HasColumnName("soNamDT");

                entity.Property(e => e.TenKhoaDt)
                    .HasMaxLength(50)
                    .HasColumnName("tenKhoaDT");

            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLop)
                    .HasName("PRIMARY");

                entity.ToTable("LOP");

                entity.HasIndex(e => e.MaGvcn, "FK_LOP_maGVCN");

                entity.Property(e => e.MaLop)
                    .HasMaxLength(10)
                    .HasColumnName("maLop");

                entity.Property(e => e.MaGvcn)
                    .HasColumnType("int(11)")
                    .HasColumnName("maGVCN");

                entity.Property(e => e.SiSo)
                    .HasColumnType("int(11)")
                    .HasColumnName("siSO");

                entity.Property(e => e.TenLop)
                    .HasMaxLength(40)
                    .HasColumnName("tenLop");
            });

            modelBuilder.Entity<Monhoc>(entity =>
            {
                entity.HasKey(e => e.MaMon)
                    .HasName("PRIMARY");

                entity.ToTable("MONHOC");

                entity.Property(e => e.MaMon)
                    .HasColumnType("int(11)")
                    .HasColumnName("maMon");

                entity.Property(e => e.TenMon)
                    .HasMaxLength(50)
                    .HasColumnName("tenMon");
            });

            modelBuilder.Entity<Nganh>(entity =>
            {
                entity.HasKey(e => e.MaNganh)
                    .HasName("PRIMARY");

                entity.ToTable("NGANH");

                entity.HasIndex(e => e.MaKhoa, "FK_NGANH_maKhoa");

                entity.Property(e => e.MaNganh)
                    .HasColumnType("int(11)")
                    .HasColumnName("maNganh");

                entity.Property(e => e.MaKhoa)
                    .HasColumnType("int(11)")
                    .HasColumnName("maKhoa");

                entity.Property(e => e.TenNganh)
                    .HasMaxLength(50)
                    .HasColumnName("tenNganh")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                //entity.HasOne(d => d.MaKhoaNavigation)
                //    .WithMany(p => p.Nganhs)
                //    .HasForeignKey(d => d.MaKhoa)
                //    .HasConstraintName("FK_NGANH_maKhoa");
            });

            modelBuilder.Entity<PcGiangday>(entity =>
            {
                entity.HasKey(e => e.MaPcgd)
                    .HasName("PRIMARY");

                entity.ToTable("PC_GIANGDAY");

                entity.HasIndex(e => e.MaHocPhan, "FK_PCGD_maHocphan");

                entity.Property(e => e.MaPcgd)
                    .HasColumnType("int(11)")
                    .HasColumnName("maPCGD");

                entity.Property(e => e.Ca)
                    .HasMaxLength(5)
                    .HasColumnName("ca")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MaHocPhan)
                    .HasColumnType("int(11)")
                    .HasColumnName("maHocPhan");

                entity.Property(e => e.MaLop)
                    .HasColumnType("int(11)")
                    .HasColumnName("maLop");

                entity.Property(e => e.Ngay).HasColumnName("NGAY");

                entity.Property(e => e.Thu)
                    .HasMaxLength(10)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                //entity.HasOne(d => d.MaHocPhanNavigation)
                //    .WithMany(p => p.PcGiangdays)
                //    .HasForeignKey(d => d.MaHocPhan)
                //    .HasConstraintName("FK_PCGD_maHocphan");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong)
                    .HasName("PRIMARY");

                entity.ToTable("PHONG");

                entity.Property(e => e.MaPhong)
                    .HasColumnType("int(11)")
                    .HasColumnName("maPhong");

                entity.Property(e => e.DiaDiem)
                    .HasMaxLength(50)
                    .HasColumnName("diaDiem")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TenPhong)
                    .HasMaxLength(50)
                    .HasColumnName("tenPhong")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<QlTiendogd>(entity =>
            {
                entity.HasKey(e => e.MatienDo)
                    .HasName("PRIMARY");

                entity.ToTable("QL_TIENDOGD");

                entity.HasIndex(e => e.MaGv, "FK_LOP_maGV");

                entity.Property(e => e.MatienDo)
                    .HasColumnType("int(11)")
                    .HasColumnName("MATienDo");

                entity.Property(e => e.MaGv)
                    .HasColumnType("int(11)")
                    .HasColumnName("maGV");

                entity.Property(e => e.NgayBu).HasColumnName("ngayBu");

                entity.Property(e => e.NgayNghi).HasColumnName("ngayNghi");

                entity.Property(e => e.SoTietBu)
                    .HasColumnType("int(11)")
                    .HasColumnName("soTietBu");

                entity.Property(e => e.SoTietNghi)
                    .HasColumnType("int(11)")
                    .HasColumnName("soTietNghi");

                //entity.HasOne(d => d.MaGvNavigation)
                //    .WithMany(p => p.QlTiendogds)
                //    .HasForeignKey(d => d.MaGv)
                //    .HasConstraintName("FK_LOP_maGV");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
