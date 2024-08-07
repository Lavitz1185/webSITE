using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UbahBatasKarakterBioJadi60 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "TblMahasiswa",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(55)",
                oldMaxLength: 55);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "95cfb43d-d0eb-41fa-8abf-6323e72972f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "69899856-f599-4ef5-93c7-ea7b00214c28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "3d257050-7947-4635-abfc-71b3d8ae5225");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce8e1ced-3e36-49fd-86b2-8f6a97b88f27", "AQAAAAEAACcQAAAAEOJVCSFbFmuAl85QsYqeQ9VqC5/Ky5CSz2zu671znIwCnmPUQ3HOiMg+3Pw/hWy9rQ==", "db7e12a4-ffd0-4be6-8d5c-071fa99dac22" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a9eb07c-b5f4-42f3-8cb1-07d288d7047e", "AQAAAAEAACcQAAAAEOVrXekYhsMK25fjUjavoeJQao/bQZKTbUxa1w4Kawhxm0u5fGY3ZGzOMc61LRil0Q==", "714ae30a-aefe-44f0-9f86-a052e84f1b96" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bc05ad2-3db1-47b8-9300-cdc97b004ba8", "AQAAAAEAACcQAAAAEAsnN+GxIwT+yfD3fAPD0cSHxO813xmMsnhva0pJz2n34nzR+OqqnvhyOR8BZhSzCw==", "b679b53b-2ccd-43a0-aa62-9337128c44c6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "TblMahasiswa",
                type: "character varying(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

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
        }
    }
}
