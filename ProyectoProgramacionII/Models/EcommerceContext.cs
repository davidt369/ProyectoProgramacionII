using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacionII.Models;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tbcategory> Tbcategories { get; set; }

    public virtual DbSet<Tbpaymentmethod> Tbpaymentmethods { get; set; }

    public virtual DbSet<Tbpaymentreceipt> Tbpaymentreceipts { get; set; }

    public virtual DbSet<Tbproduct> Tbproducts { get; set; }

    public virtual DbSet<Tbrole> Tbroles { get; set; }

    public virtual DbSet<Tbsale> Tbsales { get; set; }

    public virtual DbSet<Tbsaledetail> Tbsaledetails { get; set; }

    public virtual DbSet<Tbsalesstatus> Tbsalesstatuses { get; set; }

    public virtual DbSet<Tbuser> Tbusers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HA9DUIT\\SQLEXPRESS;Database=dbecommerce;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tbcategory>(entity =>
        {
            entity.HasKey(e => e.PkCategory).HasName("PK__tbcatego__CEBD9669B9350E14");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Tbpaymentmethod>(entity =>
        {
            entity.HasKey(e => e.PkPaymentmethod).HasName("PK__tbpaymen__CAE60DAB84FB07D4");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Tbpaymentreceipt>(entity =>
        {
            entity.HasKey(e => e.PkPaymentreceipt).HasName("PK__tbpaymen__A7692AB5F0FDE136");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.FkPaymentmethodNavigation).WithMany(p => p.Tbpaymentreceipts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbpaymentreceipts_tbpaymentmethods");

            entity.HasOne(d => d.FkSaleNavigation).WithMany(p => p.Tbpaymentreceipts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbpaymentreceipts_tbsales");
        });

        modelBuilder.Entity<Tbproduct>(entity =>
        {
            entity.HasKey(e => e.PkProduct).HasName("PK__tbproduc__DA9C5091472A5025");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.FkCategoryNavigation).WithMany(p => p.Tbproducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbproducts_tbcategories");
        });

        modelBuilder.Entity<Tbrole>(entity =>
        {
            entity.HasKey(e => e.PkRole).HasName("PK__tbroles__1FAB9065A925C7B5");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Tbsale>(entity =>
        {
            entity.HasKey(e => e.PkSale).HasName("PK__tbsales__89FAEEB4A716CFDF");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.FkSalestatusNavigation).WithMany(p => p.Tbsales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbsales_tbsalesstatuses");

            entity.HasOne(d => d.FkUserNavigation).WithMany(p => p.Tbsales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbsales_tbusers");
        });

        modelBuilder.Entity<Tbsaledetail>(entity =>
        {
            entity.HasKey(e => e.PkSaledetail).HasName("PK__tbsalede__6281ECE586E82F42");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.FkProductNavigation).WithMany(p => p.Tbsaledetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbsaledetails_tbproducts");

            entity.HasOne(d => d.FkSaleNavigation).WithMany(p => p.Tbsaledetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbsaledetails_tbsales");
        });

        modelBuilder.Entity<Tbsalesstatus>(entity =>
        {
            entity.HasKey(e => e.PkSalestatus).HasName("PK__tbsaless__F2F0769E0FAB02EF");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Tbuser>(entity =>
        {
            entity.HasKey(e => e.PkUser).HasName("PK__tbusers__5F98DC5BEB96D78D");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FkRole).HasDefaultValue(67483231);
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.FkRoleNavigation).WithMany(p => p.Tbusers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbusers_tbroles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
