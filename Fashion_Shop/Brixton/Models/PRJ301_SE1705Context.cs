using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Brixton.Models
{
    public partial class PRJ301_SE1705Context : DbContext
    {
        public PRJ301_SE1705Context()
        {
        }

        public PRJ301_SE1705Context(DbContextOptions<PRJ301_SE1705Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountHe161048> AccountHe161048s { get; set; } = null!;
        public virtual DbSet<CategoriesHe161048> CategoriesHe161048s { get; set; } = null!;
        public virtual DbSet<CollectionsHe161048> CollectionsHe161048s { get; set; } = null!;
        public virtual DbSet<OrderDetailHe161048> OrderDetailHe161048s { get; set; } = null!;
        public virtual DbSet<OrderHe161048> OrderHe161048s { get; set; } = null!;
        public virtual DbSet<ProductHe161048> ProductHe161048s { get; set; } = null!;
        public virtual DbSet<SecurityQuestionHe161048> SecurityQuestionHe161048s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json").Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetValue<string>
                    ("ConnectionStrings:DBContext"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountHe161048>(entity =>
            {
                entity.HasKey(e => e.AccId)
                    .HasName("PK__Account___91CBC378844B0DC1");

                entity.ToTable("Account_HE161048");

                entity.Property(e => e.AccId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccPass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserAddress).HasMaxLength(150);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ques)
                    .WithMany(p => p.AccountHe161048s)
                    .HasForeignKey(d => d.QuesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account_H__QuesI__2F10007B");
            });

            modelBuilder.Entity<CategoriesHe161048>(entity =>
            {
                entity.HasKey(e => e.CaId)
                    .HasName("PK__Categori__A679D840D2B569D9");

                entity.ToTable("Categories_HE161048");

                entity.Property(e => e.CaName).HasMaxLength(100);
            });

            modelBuilder.Entity<CollectionsHe161048>(entity =>
            {
                entity.HasKey(e => e.CoId)
                    .HasName("PK__Collecti__A25F3E2B09643E06");

                entity.ToTable("Collections_HE161048");

                entity.Property(e => e.CoName).HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetailHe161048>(entity =>
            {
                entity.HasKey(e => new { e.OrId, e.ProId });

                entity.ToTable("OrderDetail_HE161048");

                entity.HasOne(d => d.Or)
                    .WithMany()
                    .HasForeignKey(d => d.OrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDetai__OrId__31EC6D26");

                entity.HasOne(d => d.Pro)
                    .WithMany()
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__ProId__30F848ED");
            });

            modelBuilder.Entity<OrderHe161048>(entity =>
            {
                entity.HasKey(e => e.OrId)
                    .HasName("PK__Order_HE__E16497A8571C43F8");

                entity.ToTable("Order_HE161048");

                entity.Property(e => e.AccId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrDate).HasColumnType("date");

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.OrderHe161048s)
                    .HasForeignKey(d => d.AccId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_HE1__AccId__300424B4");
            });

            modelBuilder.Entity<ProductHe161048>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("PK__Product___62029590D5E96C69");

                entity.ToTable("Product_HE161048");

                entity.Property(e => e.ProDetail).HasMaxLength(1000);

                entity.Property(e => e.ProName).HasMaxLength(100);

                entity.HasOne(d => d.Ca)
                    .WithMany(p => p.ProductHe161048s)
                    .HasForeignKey(d => d.CaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_HE__CaId__32E0915F");

                entity.HasOne(d => d.Co)
                    .WithMany(p => p.ProductHe161048s)
                    .HasForeignKey(d => d.CoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_HE__CoId__33D4B598");
            });

            modelBuilder.Entity<SecurityQuestionHe161048>(entity =>
            {
                entity.HasKey(e => e.QuesId)
                    .HasName("PK__Security__5F3F5FF4F51ACFA7");

                entity.ToTable("SecurityQuestion_HE161048");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
