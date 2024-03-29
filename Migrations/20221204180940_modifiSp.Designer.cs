﻿// <auto-generated />
using System;
using CombustiblesGT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CombustiblesGT.Migrations
{
    [DbContext(typeof(DbCombusiblesGtContext))]
    [Migration("20221204180940_modifiSp")]
    partial class modifiSp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CombustiblesGT.Models.Bomba", b =>
                {
                    b.Property<int>("IdBomba")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBomba"));

                    b.Property<string>("Codigo")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Ubicacion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdBomba");

                    b.ToTable("Bomba", (string)null);
                });

            modelBuilder.Entity("CombustiblesGT.Models.Despacho", b =>
                {
                    b.Property<int>("IdDespacho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDespacho"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int>("IdBomba")
                        .HasColumnType("int");

                    b.Property<int>("IdVehiculo")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalDespachado")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("IdDespacho");

                    b.HasIndex("IdBomba");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("Despacho", (string)null);
                });

            modelBuilder.Entity("CombustiblesGT.Models.TipoCombustible", b =>
                {
                    b.Property<int>("IdTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipo"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTipo");

                    b.ToTable("TipoCombustible", (string)null);
                });

            modelBuilder.Entity("CombustiblesGT.Models.Vehiculo", b =>
                {
                    b.Property<int>("IdVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVehiculo"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("IdTipo")
                        .HasColumnType("int");

                    b.Property<int>("Modelo")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVehiculo");

                    b.HasIndex("IdTipo");

                    b.ToTable("Vehiculo", (string)null);
                });

            modelBuilder.Entity("CombustiblesGT.Models.Despacho", b =>
                {
                    b.HasOne("CombustiblesGT.Models.Bomba", "IdBombaNavigation")
                        .WithMany("Despachos")
                        .HasForeignKey("IdBomba")
                        .IsRequired()
                        .HasConstraintName("FK_Despacho_Bomba");

                    b.HasOne("CombustiblesGT.Models.Vehiculo", "IdVehiculoNavigation")
                        .WithMany("Despachos")
                        .HasForeignKey("IdVehiculo")
                        .IsRequired()
                        .HasConstraintName("FK_Despacho_Vehiculo");

                    b.Navigation("IdBombaNavigation");

                    b.Navigation("IdVehiculoNavigation");
                });

            modelBuilder.Entity("CombustiblesGT.Models.Vehiculo", b =>
                {
                    b.HasOne("CombustiblesGT.Models.TipoCombustible", "IdTipoNavigation")
                        .WithMany("Vehiculos")
                        .HasForeignKey("IdTipo")
                        .HasConstraintName("FK_Vehiculo_TipoCombustible");

                    b.Navigation("IdTipoNavigation");
                });

            modelBuilder.Entity("CombustiblesGT.Models.Bomba", b =>
                {
                    b.Navigation("Despachos");
                });

            modelBuilder.Entity("CombustiblesGT.Models.TipoCombustible", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("CombustiblesGT.Models.Vehiculo", b =>
                {
                    b.Navigation("Despachos");
                });
#pragma warning restore 612, 618
        }
    }
}
