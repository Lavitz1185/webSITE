using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webSITE.Migrations.Identity
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityRole<int>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<int>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<int>",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<int>", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "JenisKelamin", "LockoutEnabled", "LockoutEnd", "NamaLengkap", "NamaPanggilan", "Nim", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TanggalLahir", "TwoFactorEnabled", "UserName" },
                values: new object[] { "610ac781-a73e-46e4-bb3e-c35782ca3304", 0, "63bf2b8a-e786-488e-b5d1-b757bed058b1", "aditaklal@gmail.com", true, 0, false, null, "Adi Juanito Taklal", "Adi", "2206080051", "ADITAKLAL@GMAIL.COM", "ADITAKLAL@GMAIL.COM", "AQAAAAEAACcQAAAAEAkEnmkZtCLkHr7FIVCEg1b43u6nXok1hGbNyK1QoZ2jdaSwURK3JFAAMp7jbZlcug==", null, false, "/img/contoh.jpeg", "f53b2124-dbc9-4dfe-afc7-aa8e5e324c1b", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "aditaklal@gmail.com" });

            migrationBuilder.InsertData(
                table: "IdentityRole<int>",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "080ac954-6051-4800-958a-c84a12b1a0bc", "Mahasiswa", "MAHASISWA" },
                    { 2, "54dabdbe-7959-4d77-b2e8-7c6d316f51f9", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "IdentityUserRole<int>",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole<int>");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<int>");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "610ac781-a73e-46e4-bb3e-c35782ca3304");
        }
    }
}
