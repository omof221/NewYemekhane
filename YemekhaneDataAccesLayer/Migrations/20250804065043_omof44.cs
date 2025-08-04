using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemekhaneDataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class omof44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "girisLoglar",
                columns: table => new
                {
                    GirisLoglariId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanId = table.Column<int>(type: "int", nullable: false),
                    GirisZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Basarili = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_girisLoglar", x => x.GirisLoglariId);
                    table.ForeignKey(
                        name: "FK_girisLoglar_yemekhaneCalisanlar_CalisanId",
                        column: x => x.CalisanId,
                        principalTable: "yemekhaneCalisanlar",
                        principalColumn: "yemekhaneCalisanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_girisLoglar_CalisanId",
                table: "girisLoglar",
                column: "CalisanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "girisLoglar");
        }
    }
}
