using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efCoreApp.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class KursKayitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ogrenciId",
                table: "KursKayits",
                newName: "OgrenciId");

            migrationBuilder.RenameColumn(
                name: "kursId",
                table: "KursKayits",
                newName: "KursId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "KursKayits",
                newName: "KayitId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Ogrenciler",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Ogrenciler",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OgrenciId",
                table: "KursKayits",
                newName: "ogrenciId");

            migrationBuilder.RenameColumn(
                name: "KursId",
                table: "KursKayits",
                newName: "kursId");

            migrationBuilder.RenameColumn(
                name: "KayitId",
                table: "KursKayits",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Ogrenciler",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Ogrenciler",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);
        }
    }
}
