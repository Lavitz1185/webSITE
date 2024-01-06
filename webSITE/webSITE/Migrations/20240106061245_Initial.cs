using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "TblMahasiswa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "TblMahasiswa",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "TblMahasiswa",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "TblMahasiswa",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "TblMahasiswa",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "TblMahasiswa",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "34041a30-8807-43d7-a5b9-a6519c6e9597", null, false, false, null, null, null, null, null, false, "094b3a2b-13ab-450e-ab4d-1cec50c4e4b1", false, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "d5b4928b-d297-4345-954c-8382dd5a294c", null, false, false, null, null, null, null, null, false, "8bdba0a6-a14b-441b-aa82-3a1ae8eee92f", false, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "3d4c13d1-2efe-4989-b60b-5209bada9419", null, false, false, null, null, null, null, null, false, "475443b8-4d1e-42e3-ab16-dad87f056515", false, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "b68c0e30-c6ff-465d-8269-a1d51bd135ce", null, false, false, null, null, null, null, null, false, "9c74d879-34c4-4f4c-ab79-dc483538cc34", false, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "01472c61-c064-4dc8-8baf-d30bd24f7aff", null, false, false, null, null, null, null, null, false, "26edfc02-cad6-42ad-9cc9-859da64979cd", false, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "c82961fa-1a8c-485c-99c8-595e43624407", null, false, false, null, null, null, null, null, false, "c046a7ac-f662-45cf-9c93-70ab148146c0", false, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "384bafba-f162-4a9f-84b1-fa78e5890fee", null, false, false, null, null, null, null, null, false, "68f6b256-fa1b-44d7-8fe8-690441f25459", false, null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "87848c38-bdcd-4d52-9e3f-703ad8627b47", null, false, false, null, null, null, null, null, false, "645c8925-0053-4a23-9700-187c940fce27", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "TblMahasiswa");

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMahasiswa = table.Column<int>(type: "int", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
