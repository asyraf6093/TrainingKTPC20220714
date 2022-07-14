using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingKTPC20220714.Migrations
{
    public partial class Kategori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kategori",
                table: "Bangunan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kategori2",
                table: "Bangunan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategori2",
                table: "Bangunan");
        }
    }
}
