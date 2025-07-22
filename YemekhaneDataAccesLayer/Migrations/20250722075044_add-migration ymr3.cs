using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YemekhaneDataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationymr3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "yemekhaneCalisanlar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "yemekhaneCalisanlar",
                columns: table => new
                {
                    yemekhaneCalisanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yemekhaneCalisanlar", x => x.yemekhaneCalisanId);
                });
        }
    }
}
