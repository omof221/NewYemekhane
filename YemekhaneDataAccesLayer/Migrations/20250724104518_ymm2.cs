using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemekhaneDataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class ymm2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "calisanKartNo",
                table: "Calisanlar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "calisanKartNo",
                table: "Calisanlar",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
