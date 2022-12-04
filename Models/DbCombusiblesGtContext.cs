using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CombustiblesGT.Models;

public partial class DbCombusiblesGtContext : DbContext
{
    public DbCombusiblesGtContext()
    {
    }

    public DbCombusiblesGtContext(DbContextOptions<DbCombusiblesGtContext> options)
        : base(options)
    {
    } 

    public virtual DbSet<Bomba> Bombas { get; set; }

    public virtual DbSet<Despacho> Despachos { get; set; }

    public virtual DbSet<TipoCombustible> TipoCombustibles { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseNpgsql("Server=127.0.0.1; Port=5455; Database=TEST; UserId=USER; Password=12345; Timeout=15; ");
    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=dbCombusiblesGT;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bomba>(entity =>
        {
            entity.HasKey(e => e.IdBomba);

            entity.ToTable("Bomba");

            entity.Property(e => e.Codigo).HasMaxLength(5);
            entity.Property(e => e.Nombre).HasMaxLength(20);
            entity.Property(e => e.Ubicacion).HasMaxLength(50);
        });

        modelBuilder.Entity<Despacho>(entity =>
        {
            entity.HasKey(e => e.IdDespacho);

            entity.ToTable("Despacho");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.TotalDespachado).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdBombaNavigation).WithMany(p => p.Despachos)
                .HasForeignKey(d => d.IdBomba)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Despacho_Bomba");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Despachos)
                .HasForeignKey(d => d.IdVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Despacho_Vehiculo");
        });

        modelBuilder.Entity<TipoCombustible>(entity =>
        {
            entity.HasKey(e => e.IdTipo);

            entity.ToTable("TipoCombustible");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo);

            entity.ToTable("Vehiculo");

            entity.Property(e => e.Descripcion).HasMaxLength(50);

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK_Vehiculo_TipoCombustible");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
