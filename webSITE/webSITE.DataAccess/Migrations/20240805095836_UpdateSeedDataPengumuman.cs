using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataPengumuman : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2f0afa3b-1097-423f-88f1-b71b829fccf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "93baf42b-aedf-48c2-b1fc-5f15d8825116");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "65d7490a-60ef-48de-a92a-0530c1f8abaa");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bffa95b-48a0-48ea-b2ea-7f5dd0b270c2", "AQAAAAEAACcQAAAAENBtdm2IJJBYG0Equ5V54EszryG6R2cwnoc6ZDUQLv6B1S0LjJRd7mvtJsogzoHeFA==", "3fec6558-98fd-4d61-8acd-b895900a7679" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14195b1b-8770-4e94-baa5-b18eb0e7d821", "AQAAAAEAACcQAAAAEGS6Wi3bUVSUkeaijMzwm2l5EZmGXQ2WKibXlPaoB98qOsFNUbQnpv4FYMB6WAcDDw==", "10c49d00-f761-4a2e-ac0c-e51c6dfc0982" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a34bba4-28cb-48cc-8c7b-356c516828ee", "AQAAAAEAACcQAAAAEFmsEUn9w61wv9IHyDSEZZLstWWVr5reL8BP+uVBT5LncVyhnB/+EM5qr5rDPwl3lQ==", "61e4a37d-76e5-4316-8ecc-7b2939189a95" });

            migrationBuilder.UpdateData(
                table: "TblPengumuman",
                keyColumn: "Id",
                keyValue: 1,
                column: "Isi",
                value: "Dengan bangga kami mengundang seluruh civitas akademika untuk menghadiri Pentas Seni Ilmu Komputer 2024 yang akan diselenggarakan pada tanggal 15 Agustus 2024 di Aula Utama Kampus. Acara ini akan menampilkan berbagai pertunjukan seni kreatif dari mahasiswa, termasuk tarian, drama, musik, dan pameran karya digital. ");
        }
    }
}
