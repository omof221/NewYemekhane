using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemekhaneDataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminler",
                columns: table => new
                {
                    adminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adminIsim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminSifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminler", x => x.adminID);
                });

            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    calisanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aktiflik = table.Column<bool>(type: "bit", nullable: false),
                    calisanIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calisanSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calisanGorevi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calisanKartNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.calisanID);
                });

            migrationBuilder.CreateTable(
                name: "Okutmalar",
                columns: table => new
                {
                    OkutmalarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calisanID = table.Column<int>(type: "int", nullable: false),
                    OkutmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jokerGecis = table.Column<bool>(type: "bit", nullable: false),
                    gecisCount = table.Column<int>(type: "int", nullable: false),
                    jokerGecisCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okutmalar", x => x.OkutmalarID);
                    table.ForeignKey(
                        name: "FK_Okutmalar_Calisanlar_calisanID",
                        column: x => x.calisanID,
                        principalTable: "Calisanlar",
                        principalColumn: "calisanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Okutmalar_calisanID",
                table: "Okutmalar",
                column: "calisanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminler");

            migrationBuilder.DropTable(
                name: "Okutmalar");

            migrationBuilder.DropTable(
                name: "Calisanlar");
        }
    }
}
