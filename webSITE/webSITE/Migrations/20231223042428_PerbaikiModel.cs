using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class PerbaikiModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblMahasiswaFoto_TblFoto_FotoId",
                table: "TblMahasiswaFoto");

            migrationBuilder.DropForeignKey(
                name: "FK_TblMahasiswaFoto_TblMahasiswa_MahasiswaId",
                table: "TblMahasiswaFoto");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPesertaKegiatan_TblKegiatan_KegiatanId",
                table: "TblPesertaKegiatan");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPesertaKegiatan_TblMahasiswa_MahasiswaId",
                table: "TblPesertaKegiatan");

            migrationBuilder.DropIndex(
                name: "IX_TblPesertaKegiatan_KegiatanId",
                table: "TblPesertaKegiatan");

            migrationBuilder.DropIndex(
                name: "IX_TblPesertaKegiatan_MahasiswaId",
                table: "TblPesertaKegiatan");

            migrationBuilder.DropIndex(
                name: "IX_TblMahasiswaFoto_FotoId",
                table: "TblMahasiswaFoto");

            migrationBuilder.DropIndex(
                name: "IX_TblMahasiswaFoto_MahasiswaId",
                table: "TblMahasiswaFoto");

            migrationBuilder.DropColumn(
                name: "KegiatanId",
                table: "TblPesertaKegiatan");

            migrationBuilder.DropColumn(
                name: "MahasiswaId",
                table: "TblPesertaKegiatan");

            migrationBuilder.DropColumn(
                name: "FotoId",
                table: "TblMahasiswaFoto");

            migrationBuilder.DropColumn(
                name: "MahasiswaId",
                table: "TblMahasiswaFoto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KegiatanId",
                table: "TblPesertaKegiatan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MahasiswaId",
                table: "TblPesertaKegiatan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FotoId",
                table: "TblMahasiswaFoto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MahasiswaId",
                table: "TblMahasiswaFoto",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "FotoId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "FotoId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "FotoId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "FotoId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 3, 1 },
                columns: new[] { "FotoId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "FotoId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 4, 1 },
                columns: new[] { "FotoId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 4, 2 },
                columns: new[] { "FotoId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 5, 1 },
                columns: new[] { "FotoId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 5, 2 },
                columns: new[] { "FotoId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblPesertaKegiatan",
                keyColumns: new[] { "IdKegiatan", "IdMahasiswa" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "KegiatanId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TblPesertaKegiatan",
                keyColumns: new[] { "IdKegiatan", "IdMahasiswa" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "KegiatanId", "MahasiswaId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_TblPesertaKegiatan_KegiatanId",
                table: "TblPesertaKegiatan",
                column: "KegiatanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPesertaKegiatan_MahasiswaId",
                table: "TblPesertaKegiatan",
                column: "MahasiswaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMahasiswaFoto_FotoId",
                table: "TblMahasiswaFoto",
                column: "FotoId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMahasiswaFoto_MahasiswaId",
                table: "TblMahasiswaFoto",
                column: "MahasiswaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblMahasiswaFoto_TblFoto_FotoId",
                table: "TblMahasiswaFoto",
                column: "FotoId",
                principalTable: "TblFoto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblMahasiswaFoto_TblMahasiswa_MahasiswaId",
                table: "TblMahasiswaFoto",
                column: "MahasiswaId",
                principalTable: "TblMahasiswa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPesertaKegiatan_TblKegiatan_KegiatanId",
                table: "TblPesertaKegiatan",
                column: "KegiatanId",
                principalTable: "TblKegiatan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPesertaKegiatan_TblMahasiswa_MahasiswaId",
                table: "TblPesertaKegiatan",
                column: "MahasiswaId",
                principalTable: "TblMahasiswa",
                principalColumn: "Id");
        }
    }
}
