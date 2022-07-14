using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingKTPC20220714.Migrations
{
    public partial class Lokasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Bangunan");

            migrationBuilder.AddColumn<int>(
                name: "LokasiID",
                table: "Bangunan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lokasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokasi", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bangunan_LokasiID",
                table: "Bangunan",
                column: "LokasiID");

            

            migrationBuilder.AddForeignKey(
                name: "FK_Bangunan_2",
                table: "Bangunan",
                column: "LokasiID",
                principalTable: "Lokasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bangunan_Lokasi_LokasiID",
                table: "Bangunan");

            migrationBuilder.DropTable(
                name: "Lokasi");

            migrationBuilder.DropIndex(
                name: "IX_Bangunan_LokasiID",
                table: "Bangunan");

            migrationBuilder.DropColumn(
                name: "LokasiID",
                table: "Bangunan");
        }
    }
}
