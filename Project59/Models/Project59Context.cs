using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project59.Models;

public partial class Project59Context : DbContext
{
    public Project59Context()
    {
    }

    public Project59Context(DbContextOptions<Project59Context> options)
        : base(options)
    {
    }


    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Tintuc> Tintucs { get; set; }

    public virtual DbSet<Truycap> Truycaps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-I3CH2RE\\SQLEXPRESS;Initial Catalog=project59;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId);

            entity.ToTable("post");

            entity.Property(e => e.PostId).HasColumnName("postID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.Link)
                .HasMaxLength(50)
                .HasColumnName("link");
            entity.Property(e => e.Loai)
                .HasMaxLength(50)
                .HasColumnName("loai");
            entity.Property(e => e.Ngay)
                .HasColumnType("datetime")
                .HasColumnName("ngay");
            entity.Property(e => e.Nguoidang)
                .HasMaxLength(50)
                .HasColumnName("nguoidang");
            entity.Property(e => e.Noidung).HasColumnName("noidung");
            entity.Property(e => e.Noidungchitiet).HasColumnName("noidungchitiet");
            entity.Property(e => e.Ten)
                .HasMaxLength(50)
                .HasColumnName("ten");
            entity.Property(e => e.Trangthai).HasColumnName("trangthai");

        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.ToTable("taikhoan");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Diachi).HasColumnName("diachi");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .HasColumnName("hoten");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(50)
                .HasColumnName("matkhau");
            entity.Property(e => e.Mota).HasColumnName("mota");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Sdt).HasColumnName("sdt");
            entity.Property(e => e.Taikhoan1)
                .HasMaxLength(50)
                .HasColumnName("taikhoan");
            entity.Property(e => e.Trangthai).HasColumnName("trangthai");

            entity.HasOne(d => d.Role).WithMany(p => p.Taikhoans)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_taikhoan_Truycap");
        });

        modelBuilder.Entity<Tintuc>(entity =>
        {
            entity.ToTable("Tintuc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cmt).HasColumnName("cmt");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.Loai)
                .HasMaxLength(50)
                .HasColumnName("loai");
            entity.Property(e => e.Ngay)
                .HasColumnType("datetime")
                .HasColumnName("ngay");
            entity.Property(e => e.Noidung).HasColumnName("noidung");
            entity.Property(e => e.Share).HasColumnName("share");
            entity.Property(e => e.Ten).HasColumnName("ten");
            entity.Property(e => e.Tieude).HasColumnName("tieude");
            entity.Property(e => e.Tim).HasColumnName("tim");
            entity.Property(e => e.Trangthai).HasColumnName("trangthai");
        });

        modelBuilder.Entity<Truycap>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("Truycap");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Mota)
                .HasMaxLength(50)
                .HasColumnName("mota");
            entity.Property(e => e.Trangthai).HasColumnName("trangthai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
