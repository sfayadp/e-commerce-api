using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace e_commerce_api.Models
{
    public partial class ecommerceContext : DbContext
    {
        public ecommerceContext()
        {
        }

        public ecommerceContext(DbContextOptions<ecommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Descuento> Descuentos { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=ecommerce;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.17-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("categoria");

                entity.HasIndex(e => e.Estado, "fk_Categoria_Estado_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Codigo).HasMaxLength(45);

                entity.Property(e => e.Descripcion).HasMaxLength(255);

                entity.Property(e => e.Estado).HasColumnType("int(11)");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Categoria)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Categoria_Estado");
            });

            modelBuilder.Entity<Descuento>(entity =>
            {
                entity.ToTable("descuento");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Codigo).HasMaxLength(255);

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e.ValorPorcentaje).HasPrecision(10);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(255);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("marca");

                entity.HasIndex(e => e.Estado, "fk_Marca_Estado1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Descripcion).HasMaxLength(255);

                entity.Property(e => e.Estado).HasColumnType("int(11)");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Marcas)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Marca_Estado1");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.HasIndex(e => e.Categoria, "fk_Producto_Categoria1_idx");

                entity.HasIndex(e => e.Descuento, "fk_Producto_Descuento1_idx");

                entity.HasIndex(e => e.Estado, "fk_Producto_Estado1_idx");

                entity.HasIndex(e => e.Marca, "fk_Producto_Marca1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Categoria).HasColumnType("int(11)");

                entity.Property(e => e.Descuento).HasColumnType("int(11)");

                entity.Property(e => e.Estado).HasColumnType("int(11)");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Imagen)
                    .HasColumnType("text")
                    .UseCollation("armscii8_general_ci")
                    .HasCharSet("armscii8");

                entity.Property(e => e.Marca).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasMaxLength(225);

                entity.Property(e => e.PrecioCompra).HasPrecision(10);

                entity.Property(e => e.PrecioVenta).HasPrecision(10);

                entity.Property(e => e.Stock).HasColumnType("int(11)");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_Categoria1");

                entity.HasOne(d => d.DescuentoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Descuento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_Descuento1");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_Estado1");

                entity.HasOne(d => d.MarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Marca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_Marca1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
