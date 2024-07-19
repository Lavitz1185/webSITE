using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TambahEntitasPensi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblLomba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Jenis = table.Column<int>(type: "integer", nullable: false),
                    Keterangan = table.Column<string>(type: "text", nullable: false),
                    MaksKuotaPerAngkatan = table.Column<int>(type: "integer", nullable: false),
                    MinAnggotaPerTim = table.Column<int>(type: "integer", nullable: true),
                    MaksAnggotaPerTim = table.Column<int>(type: "integer", nullable: true),
                    PasanganBedaJenisKelamin = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblLomba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblTimLomba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaTim = table.Column<string>(type: "text", nullable: false),
                    Angkatan = table.Column<int>(type: "integer", nullable: false),
                    TanggalDaftar = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LombaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTimLomba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblTimLomba_TblLomba_LombaId",
                        column: x => x.LombaId,
                        principalTable: "TblLomba",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblPesertaLomba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nim = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    JenisKelamin = table.Column<int>(type: "integer", nullable: false),
                    Angkatan = table.Column<int>(type: "integer", nullable: false),
                    NoWa = table.Column<string>(type: "text", nullable: false),
                    TanggalDaftar = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LombaId = table.Column<int>(type: "integer", nullable: true),
                    TimLombaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPesertaLomba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPesertaLomba_TblLomba_LombaId",
                        column: x => x.LombaId,
                        principalTable: "TblLomba",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblPesertaLomba_TblTimLomba_TimLombaId",
                        column: x => x.TimLombaId,
                        principalTable: "TblTimLomba",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cb908db6-76e6-4972-907e-bd89209eaa5a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5c5bacdf-5735-4355-9de4-bb2ec4b01a35");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "0708fbce-bea3-4638-9ee6-efbd2b1c67d1");

            migrationBuilder.InsertData(
                table: "TblLomba",
                columns: new[] { "Id", "Jenis", "Keterangan", "MaksAnggotaPerTim", "MaksKuotaPerAngkatan", "MinAnggotaPerTim", "Nama", "PasanganBedaJenisKelamin" },
                values: new object[,]
                {
                    { 1, 0, "Keterangan", null, 2, null, "Menyanyi", null },
                    { 2, 0, "Keterangan", null, 2, null, "Desain Poster", null },
                    { 3, 1, "Keterangan", 10, 2, 5, "Menari", null },
                    { 4, 2, "Keterangan", null, 2, null, "Fashion Show", true }
                });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba44a1ed-3f57-4435-a84d-ec02ef8989c2", "AQAAAAEAACcQAAAAEH8TmohcmGHz3OJh1NNlA8D2WIroxr4c5pBYajSJo1EG+TxOCzCVSkh4eAZUQOJY8Q==", "ae278865-5494-40d6-babc-5b0967b314b0" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9504b270-047b-4830-8b0b-27644b959282", "AQAAAAEAACcQAAAAEMWvrbtyC0uxUMBK3jAPnXmmgHDgo5FWtZVXw3F4xV3aqZSy2fCDvKIYecl8RBf3Fg==", "e5c9b39e-aca3-4fa7-b5ec-9247c46d3fa0" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ba3350c-6d80-431a-8403-e4e470994416", "AQAAAAEAACcQAAAAEO9/Kl9FMMSal3LFMozRx/c2BCU2HZj1vpYf8o3SSBe/C2oKhNDtrSPuiszTdgKYSQ==", "a6d8764c-c7c3-46f5-b89b-76b38a4e8ac8" });

            migrationBuilder.CreateIndex(
                name: "IX_TblPesertaLomba_LombaId",
                table: "TblPesertaLomba",
                column: "LombaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPesertaLomba_TimLombaId",
                table: "TblPesertaLomba",
                column: "TimLombaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblTimLomba_LombaId",
                table: "TblTimLomba",
                column: "LombaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblPesertaLomba");

            migrationBuilder.DropTable(
                name: "TblTimLomba");

            migrationBuilder.DropTable(
                name: "TblLomba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "045c3415-5586-4415-8b8b-3bcfd69001b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "efc62ff5-7a7d-4eb2-a77a-434cffa4e1b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "272dbfd1-496d-48a1-b557-ab3fc608d6a3");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3a60e5e-f6ea-48d3-89d7-87f9ee2a0f93", "AQAAAAEAACcQAAAAEHEv+28jX5FLM3ANaPqb4lJNIYZk+PCXDZJtL5jMy59adukDLn6Fh+QSMRufuXxrnw==", "39ed30ca-04b1-4727-bae5-c70fc4e63e99" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e699b63d-2545-4da8-b006-c3ede4774a99", "AQAAAAEAACcQAAAAEB9QzmBFs2h2f/fnjxAsuSLDIDK38wBo/qfNS4t7A1fuezu609C9kSM+XEfmAHsN7Q==", "6d588eec-7e7b-45a3-8482-4471af905347" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "012dc455-5f4e-4f9e-aa6d-09eb36ee38ce", "AQAAAAEAACcQAAAAEI6T8uCetPcm/X43fo+wOx/tKRwV2Ys39FkM3cxx0UW8xoiD9qfWRPJMona/fdufNA==", "d57bc0ea-8c8e-4485-bc9e-6d9d0be5e454" });
        }
    }
}
