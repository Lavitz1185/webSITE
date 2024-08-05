using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataPengumuman2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b326acaa-9456-4e7c-bbee-2f1c45b73752");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9338fce0-78d4-4dbd-afbd-52aa4ce00435");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "5469686f-1387-47dd-ac19-51bba461c4aa");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf344eab-69da-4149-b6f1-486ac8a66546", "AQAAAAEAACcQAAAAEJExqFvPRaZBGwazXM2IzoTeMz6Cls/EFZbgqvE7VVx+2TeSRQXHe1JNlmFzi3zPWA==", "e511bcfb-3a3e-4e5b-83b2-49040dd7262d" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ac0d726-7ea6-4eb9-9788-69180740ffb9", "AQAAAAEAACcQAAAAEL/L5MAfarLFh7hRy5/DQh1rZnAfdHakbXD2/2SNr2lvxPixAgkgJHSFtU4Mx7AhhQ==", "5649824e-0dcf-40ad-ae69-94baede3fce9" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4856e09-f87c-417e-b996-295396688a73", "AQAAAAEAACcQAAAAEJ8WIevWJH8Ymp82FtZRY+lIJ2gdiVcIosrGfqSfhoHhzIR5acZlxULTU+TLTZ0/6w==", "840d4a3c-27c7-4644-9b04-1b88c8a663fd" });

            migrationBuilder.UpdateData(
                table: "TblPengumuman",
                keyColumn: "Id",
                keyValue: 1,
                column: "Isi",
                value: "Dengan bangga kami mengundang seluruh civitas akademika untuk menghadiri Pentas Seni Ilmu Komputer 2024 yang akan diselenggarakan pada tanggal 15 Agustus 2024 di Aula Utama Kampus. Acara ini akan menampilkan berbagai pertunjukan seni kreatif dari mahasiswa, termasuk tarian, drama, musik, dan pameran karya digital. Daftar Pensi >> <a href=\"/Pensi\">Klik Untuk Mendaftar Pensi</a> <<");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a6d3cffc-997d-4750-8e8f-f40953ef394e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7b8ae1f8-5a16-4e48-a37b-c000eae275a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a039590b-1952-49ea-97f3-117428756cb7");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef75455d-881d-4d7e-9432-e3fcbd8a3a8f", "AQAAAAEAACcQAAAAECfpf6cLMQC1lsIVGAp2J8aSIz+TxOivwPQcGfOeQQZe5beCAwtRix7oAbzU88T8Hw==", "7143bc9d-7bdb-4f02-98ff-94a232cffc39" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a6996e0-5925-4873-8251-02c193ee14a9", "AQAAAAEAACcQAAAAENjfKXKjj0jQK1cEEVVjS4VBmhGkWKJ0lC7qSTo3ilmtpwKUcUkgv+pbjyaA7txDBQ==", "04cae050-afb9-4efc-aaf4-bba0d67c8ec3" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09342055-4f5f-485b-bb20-c96bb6bbd6fb", "AQAAAAEAACcQAAAAEBLtmOoECEQPWiskhNIuTsz4LTtKzInMRcQFAU5D78OCb7rngtvBRGdlQUJRqF8mgw==", "c3c4214d-2b57-46bf-b2f7-4b85946a4d14" });

            migrationBuilder.UpdateData(
                table: "TblPengumuman",
                keyColumn: "Id",
                keyValue: 1,
                column: "Isi",
                value: "Dengan bangga kami mengundang seluruh civitas akademika untuk menghadiri Pentas Seni Ilmu Komputer 2024 yang akan diselenggarakan pada tanggal 15 Agustus 2024 di Aula Utama Kampus. Acara ini akan menampilkan berbagai pertunjukan seni kreatif dari mahasiswa, termasuk tarian, drama, musik, dan pameran karya digital. Daftar Pensi >> <a href=\"/Pensi\">Klik Untuk Mendaftar Pensi</a>");
        }
    }
}
