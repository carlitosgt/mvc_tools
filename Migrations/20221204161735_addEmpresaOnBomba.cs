using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CombustiblesGT.Migrations
{
    /// <inheritdoc />
    public partial class addEmpresaOnBomba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "Bomba",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "Bomba");
        }
    }
}
