using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class UbahModelMahasiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "242e57b6-a6e2-4e7a-863e-7592714270a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "be5ef484-3952-4650-9ce3-635c3019924e");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Bio", "ConcurrencyStamp", "PasswordHash", "PhotoPath", "SecurityStamp" },
                values: new object[] { "Adi Juanito Taklal ILKOM #1", "9e461a6f-b3f4-4531-80c9-ecd1155a0bf3", "AQAAAAEAACcQAAAAEMzVVpIX4q1ITf/W8Vlv8dL2PM4lLBLjo10IsmKkObOb5hYDrtqUH45CBi5G7HQQWA==", "/img/SIte_Transparant.png", "b15d884b-4443-4015-81e9-f40ecbf09fda" });

            migrationBuilder.InsertData(
                table: "TblMahasiswa",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "JenisKelamin", "LockoutEnabled", "LockoutEnd", "NamaLengkap", "NamaPanggilan", "Nim", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TanggalLahir", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "Oswaldus Putra Fernando ILKOM #1", "07b1c7d6-2160-47be-abb6-f57e536f4309", "fernandputra14@gmail.com", true, 0, false, null, "Oswaldus Putra Fernando", "Fernand", "2206080016", "FERNANDPUTRA14@GMAIL.COM", "FERNANDPUTRA14@GMAIL.COM", "AQAAAAEAACcQAAAAEHT+W9LmzxoigEpev+PJtXLj8Dsjt1isTTq7aDtgHeQZBaYk7HYIJNt78WJQPHGlvg==", null, false, "/img/SIte_Transparant.png", "e0fc6454-388a-4645-8b74-a8caa550fadf", new DateTime(2004, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "fernandputra14@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "2" },
                    { "2", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "TblMahasiswa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f4fa70ec-c39e-464b-a645-726fb3ee2a23");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "18bfd6a2-0803-4162-89fd-38265e398489");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhotoPath", "SecurityStamp" },
                values: new object[] { "cf2d410b-d1d9-4313-9d91-4c6c60fdffeb", "AQAAAAEAACcQAAAAEIOqSfoY7u8WUFyVG70hnPfb+I5gzpSz+1vvQf/jYHkzzPHW7zxWwwxkj4iKCspCVw==", "/img/contoh.jpeg", "336d8b47-7c60-4232-9302-2d3c3e9aeb14" });
        }
    }
}
