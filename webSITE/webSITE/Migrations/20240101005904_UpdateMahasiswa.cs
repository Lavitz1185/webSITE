using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMahasiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "TblMahasiswa");

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMahasiswa = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_TblMahasiswa_IdMahasiswa",
                        column: x => x.IdMahasiswa,
                        principalTable: "TblMahasiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_IdMahasiswa",
                table: "AppUser",
                column: "IdMahasiswa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "aditaklal@gmail.com", "adiairnona" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "aditaklal@gmail.com", "adiairnona" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Password" },
                values: new object[] { "aditaklal@gmail.com", "adiairnona" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Password" },
                values: new object[] { "aditaklal@gmail.com", "adiairnona" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Password" },
                values: new object[] { "aditaklal@gmail.com", "adiairnona" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Password" },
                values: new object[] { "aditaklal@gmail.com", "adiairnona" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Password" },
                values: new object[] { "aditaklal@gmail.com", "adiairnona" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Password" },
                values: new object[] { "aditaklal@gmail.com", "adiairnona" });
        }
    }
}
