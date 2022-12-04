using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CombustiblesGT.Migrations
{
    /// <inheritdoc />
    public partial class modifiSp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"ALTER PROCEDURE [dbo].[GetListVehiculos]
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Vehiculo;
                END";

            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
