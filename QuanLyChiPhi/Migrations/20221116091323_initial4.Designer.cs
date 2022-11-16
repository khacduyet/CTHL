﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyChiPhi.Entities;

#nullable disable

namespace QuanLyChiPhi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221116091323_initial4")]
    partial class initial4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuanLyChiPhi.Entities.CanHo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ChuSoHuu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double?>("DienTich")
                        .HasColumnType("float");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdChungCu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CanHo");
                });

            modelBuilder.Entity("QuanLyChiPhi.Entities.CanHo_PhuongTien", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("BienKiemSoat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IdCanHo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdChungCu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdLoaiXe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPhuongTien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CanHo_PhuongTien");
                });

            modelBuilder.Entity("QuanLyChiPhi.Entities.ChungCu", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ChungCu");
                });

            modelBuilder.Entity("QuanLyChiPhi.Entities.LoaiDichVu", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double?>("DonGia")
                        .HasColumnType("float");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("LoaiDichVu");
                });

            modelBuilder.Entity("QuanLyChiPhi.Entities.LoaiDongPhi", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("LoaiDongPhi");
                });

            modelBuilder.Entity("QuanLyChiPhi.Entities.LoaiXe", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double?>("DonGia")
                        .HasColumnType("float");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("LoaiXe");
                });

            modelBuilder.Entity("QuanLyChiPhi.Entities.PhuongTien", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PhuongTien");
                });

            modelBuilder.Entity("QuanLyChiPhi.Entities.PSM_FileDinhKem", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FileName")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("FileNameGUI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdBang")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Link")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("LinkMau")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("LinkName")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("TenBang")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenTaiLieu")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool?>("isPhaiNop")
                        .HasColumnType("bit");

                    b.Property<bool?>("isPheDuyet")
                        .HasColumnType("bit");

                    b.Property<bool?>("isQuyTrinh")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PSM_FileDinhKem");
                });

            modelBuilder.Entity("QuanLyChiPhi.Entities.QuanLyPhi", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCanHo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdChungCu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdLoaiXe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdXeNgoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaiDongPhi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("Nam")
                        .HasColumnType("int");

                    b.Property<int?>("Ngay")
                        .HasColumnType("int");

                    b.Property<string>("NguoiDongPhi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoPhieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Thang")
                        .HasColumnType("int");

                    b.Property<double?>("TongTien")
                        .HasColumnType("float");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<bool>("isGanNhat")
                        .HasColumnType("bit");

                    b.Property<bool>("isXeNgoai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("QuanLyPhi");
                });

            modelBuilder.Entity("QuanLyChiPhi.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<string>("MaNhanVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("QuanLyChiPhi.Entities.XeNgoai", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("BienKiemSoat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdChungCu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdLoaiXe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPhuongTien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ModifiedByName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("XeNgoai");
                });
#pragma warning restore 612, 618
        }
    }
}