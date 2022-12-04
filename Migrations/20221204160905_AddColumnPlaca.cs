using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CombustiblesGT.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnPlaca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Vehiculo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Vehiculo");
        }
    }
}
