using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataKegiatanFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblFoto",
                columns: new[] { "Id", "IdKegiatan", "KegiatanId", "PhotoPath", "Tanggal" },
                values: new object[,]
                {
                    { 1, 1, null, "/img/contoh.jpeg", new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, null, "/img/contoh.jpeg", new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, null, "/img/contoh.jpeg", new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, null, "/img/contoh.jpeg", new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, null, "/img/contoh.jpeg", new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TblKegiatan",
                columns: new[] { "Id", "Keterangan", "NamaKegiatan", "TanggalBerakhir", "TanggalMulai", "TempatKegiatan" },
                values: new object[] { 1, "Kegiatan Pertama", "Kegiatan 1", new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Undana" });

            migrationBuilder.InsertData(
                table: "TblMahasiswaFoto",
                columns: new[] { "IdFoto", "IdMahasiswa", "FotoId", "MahasiswaId" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 1, 2, null, null },
                    { 2, 1, null, null },
                    { 2, 2, null, null },
                    { 3, 1, null, null },
                    { 3, 2, null, null },
                    { 4, 1, null, null },
                    { 4, 2, null, null },
                    { 5, 1, null, null },
                    { 5, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "TblPesertaKegiatan",
                columns: new[] { "IdKegiatan", "IdMahasiswa", "KegiatanId", "MahasiswaId" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 1, 2, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "TblPesertaKegiatan",
                keyColumns: new[] { "IdKegiatan", "IdMahasiswa" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TblPesertaKegiatan",
                keyColumns: new[] { "IdKegiatan", "IdMahasiswa" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblKegiatan",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
