using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efCoreApp.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class KursKayitListe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_KursKayits_KursId",
                table: "KursKayits",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursKayits_OgrenciId",
                table: "KursKayits",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayits_Kurslar_KursId",
                table: "KursKayits",
                column: "KursId",
                principalTable: "Kurslar",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayits_Ogrenciler_OgrenciId",
                table: "KursKayits",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "OgrenciId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursKayits_Kurslar_KursId",
                table: "KursKayits");

            migrationBuilder.DropForeignKey(
                name: "FK_KursKayits_Ogrenciler_OgrenciId",
                table: "KursKayits");

            migrationBuilder.DropIndex(
                name: "IX_KursKayits_KursId",
                table: "KursKayits");

            migrationBuilder.DropIndex(
                name: "IX_KursKayits_OgrenciId",
                table: "KursKayits");
        }
    }
}
