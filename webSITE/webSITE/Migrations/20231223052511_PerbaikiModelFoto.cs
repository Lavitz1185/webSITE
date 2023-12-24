using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class PerbaikiModelFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFoto_TblKegiatan_KegiatanId",
                table: "TblFoto");

            migrationBuilder.DropIndex(
                name: "IX_TblFoto_KegiatanId",
                table: "TblFoto");

            migrationBuilder.DropColumn(
                name: "KegiatanId",
                table: "TblFoto");

            migrationBuilder.CreateIndex(
                name: "IX_TblFoto_IdKegiatan",
                table: "TblFoto",
                column: "IdKegiatan");

            migrationBuilder.AddForeignKey(
                name: "FK_TblFoto_TblKegiatan_IdKegiatan",
                table: "TblFoto",
                column: "IdKegiatan",
                principalTable: "TblKegiatan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFoto_TblKegiatan_IdKegiatan",
                table: "TblFoto");

            migrationBuilder.DropIndex(
                name: "IX_TblFoto_IdKegiatan",
                table: "TblFoto");

            migrationBuilder.AddColumn<int>(
                name: "KegiatanId",
                table: "TblFoto",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 1,
                column: "KegiatanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 2,
                column: "KegiatanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 3,
                column: "KegiatanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 4,
                column: "KegiatanId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 5,
                column: "KegiatanId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_TblFoto_KegiatanId",
                table: "TblFoto",
                column: "KegiatanId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblFoto_TblKegiatan_KegiatanId",
                table: "TblFoto",
                column: "KegiatanId",
                principalTable: "TblKegiatan",
                principalColumn: "Id");
        }
    }
}
