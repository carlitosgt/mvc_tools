using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CombustiblesGT.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bomba",
                columns: table => new
                {
                    IdBomba = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bomba", x => x.IdBomba);
                });

            migrationBuilder.CreateTable(
                name: "TipoCombustible",
                columns: table => new
                {
                    IdTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCombustible", x => x.IdTipo);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipo = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculo_TipoCombustible",
                        column: x => x.IdTipo,
                        principalTable: "TipoCombustible",
                        principalColumn: "IdTipo");
                });

            migrationBuilder.CreateTable(
                name: "Despacho",
                columns: table => new
                {
                    IdDespacho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdVehiculo = table.Column<int>(type: "int", nullable: false),
                    IdBomba = table.Column<int>(type: "int", nullable: false),
                    TotalDespachado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despacho", x => x.IdDespacho);
                    table.ForeignKey(
                        name: "FK_Despacho_Bomba",
                        column: x => x.IdBomba,
                        principalTable: "Bomba",
                        principalColumn: "IdBomba");
                    table.ForeignKey(
                        name: "FK_Despacho_Vehiculo",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "IdVehiculo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despacho_IdBomba",
                table: "Despacho",
                column: "IdBomba");

            migrationBuilder.CreateIndex(
                name: "IX_Despacho_IdVehiculo",
                table: "Despacho",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_IdTipo",
                table: "Vehiculo",
                column: "IdTipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despacho");

            migrationBuilder.DropTable(
                name: "Bomba");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "TipoCombustible");
        }
    }
}
