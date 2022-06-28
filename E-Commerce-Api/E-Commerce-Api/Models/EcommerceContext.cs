using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace E_Commerce_Api.Models
{
    public partial class EcommerceContext : DbContext
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4SN8KIT;Initial Catalog=E-commerce;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.ToTable("ProductDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductDescription).HasMaxLength(50);

                entity.Property(e => e.ProductDiscount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductFinal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductImage).HasMaxLength(50);

                entity.Property(e => e.ProductMrp).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.ProductQuantity).HasMaxLength(50);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserLastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
