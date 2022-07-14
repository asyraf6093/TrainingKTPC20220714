using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingKTPC20220714.Migrations
{
    public partial class BilTingkat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategori2",
                table: "Bangunan");

            migrationBuilder.DropColumn(
                name: "BilTingkat",
                table: "Bangunan");

            migrationBuilder.AddColumn<string>(
                name: "BilTingkat",
                table: "Bangunan",
                type: "int",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kategori2",
                table: "Bangunan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
