using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class UodateMahasiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblMahasiswa",
                table: "TblMahasiswa");

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

            migrationBuilder.AlterColumn<string>(
                name: "Nim",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TblMahasiswa",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblMahasiswa",
                table: "TblMahasiswa",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TblMahasiswa",
                columns: new[] { "Id", "Email", "JenisKelamin", "NamaLengkap", "NamaPanggilan", "Nim", "Password", "PhotoPath", "TanggalLahir" },
                values: new object[,]
                {
                    { 1, "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "2206080051", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "2206080052", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "2206080053", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "2206080054", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "2206080055", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "2206080056", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "2206080057", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "aditaklal@gmail.com", 0, "Adi Juanito Taklal", "Adi", "2206080058", "adiairnona", "/img/contoh.jpeg", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblMahasiswa",
                table: "TblMahasiswa");

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TblMahasiswa");

            migrationBuilder.AlterColumn<string>(
                name: "Nim",
                table: "TblMahasiswa",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblMahasiswa",
                table: "TblMahasiswa",
                column: "Nim");

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
    }
}
