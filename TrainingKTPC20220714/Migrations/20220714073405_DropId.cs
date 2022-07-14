using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingKTPC20220714.Migrations
{
    public partial class DropId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bangunan",
                newName: "IdKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdKey",
                table: "Bangunan",
                newName: "Id");
        }
    }
}
