using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemekhaneDataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class omof4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "aktif",
                table: "Okutmalar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aktif",
                table: "Okutmalar");
        }
    }
}
