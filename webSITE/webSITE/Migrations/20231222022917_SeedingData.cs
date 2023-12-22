using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TblMahasiswa",
                columns: new[] { "Nim", "Email", "JenisKelamin", "NamaLengkap", "NamaPanggilan", "Password", "PhotoPath", "TanggalLahir" },
                values: new object[,]
                {
                    { "2206080051", "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2206080052", "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2206080053", "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2206080054", "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2206080055", "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2206080056", "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2206080057", "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2206080058", "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Nim",
                keyValue: "2206080051");

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Nim",
                keyValue: "2206080052");

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Nim",
                keyValue: "2206080053");

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Nim",
                keyValue: "2206080054");

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Nim",
                keyValue: "2206080055");

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Nim",
                keyValue: "2206080056");

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Nim",
                keyValue: "2206080057");

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Nim",
                keyValue: "2206080058");
        }
    }
}
