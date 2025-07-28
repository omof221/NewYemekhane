using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemekhaneDataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class omom4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "durum",
                table: "yemekhaneCalisanlar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "durum",
                table: "yemekhaneCalisanlar");
        }
    }
}
