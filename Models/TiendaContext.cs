using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoBBDD.Models;

public partial class TiendaContext : DbContext
{
    public TiendaContext()
    {
    }

    public TiendaContext(DbContextOptions<TiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Registrocompras> Registrocompras { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server = 26.252.149.4;user = ProyePINDAN; password = PROYEPINDAN$123; database = Tienda", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.Imagen).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("double(10,2)");
        });

        modelBuilder.Entity<Registrocompras>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("registrocompras");

            entity.HasIndex(e => e.IdProducto, "fk_Producto_Compra_idx");

            entity.HasIndex(e => e.IdUsuario, "fk_Usuarios_Compra_idx");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Registrocompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("fk_Producto_Compra");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Registrocompras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_Usuarios_Compra");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Correo, "Correo_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Idrol, "fkIdrol_idx");

            entity.Property(e => e.Contrasena).HasMaxLength(256);
            entity.Property(e => e.Correo).HasMaxLength(90);
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkIdrol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
