using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class TambahDataAwal1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 2, "1" });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 3, "1" });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 4, "1" });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 5, "1" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5819f36b-9e9e-4120-9110-4a2bd79cc6f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9c332e9b-a6cf-4fc9-8a40-cba22bc3800e");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce4e1f4c-836d-4ad7-917a-bd73d45ed914", "AQAAAAEAACcQAAAAEOYGg6rXVXaSjYPkSE2OiYDolEJW6hJYMVul63wC1Q3/rIMnRak78/TCalUdbwUN+Q==", "893495f3-68ab-4322-bbf5-6cd9a2910b5a" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26a69159-2915-4add-ae95-242b59ec9e5d", "AQAAAAEAACcQAAAAEJjYcNowVF6pXhVsJNYbtdyvZ4F/aiPJtvvA/bG3QboAMweI9NWtgAAG4aFWJT0ceA==", "d26de674-ae38-4b69-9865-7a6a815fe8af" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e88a54b-3dd0-4763-8707-ad1e9ca2214b", "AQAAAAEAACcQAAAAEKRgrJqdjtsrvGjr/9nrhpzzeCPrvfPv87CaGWSsVjidyYzcNoKIRQwjlrPjY7tXCw==", "4db34b5b-7e72-4fd9-a4e0-577d39cd3954" });

            migrationBuilder.InsertData(
                table: "TblMahasiswaFoto",
                columns: new[] { "IdFoto", "IdMahasiswa" },
                values: new object[,]
                {
                    { 2, "2" },
                    { 3, "2" },
                    { 4, "2" },
                    { 5, "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 2, "2" });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 3, "2" });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 4, "2" });

            migrationBuilder.DeleteData(
                table: "TblMahasiswaFoto",
                keyColumns: new[] { "IdFoto", "IdMahasiswa" },
                keyValues: new object[] { 5, "2" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c39b71dd-c027-421e-a17f-d583e8bdb8cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b6c8eb3c-7b20-4d0e-adeb-37af30e15e2a");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7caf9d60-6ee4-4632-babb-1dc58c2c88b5", "AQAAAAEAACcQAAAAEEgUzvWYVfIfSrGYXtwYAi3026mxYSFJxAfn7uxF3BuKf04vnJqGTr1c8qYALk+4Dg==", "327e6bb4-0a70-4c65-9a0f-a3a8d6f6b1c7" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cf5ed1b-248c-4eea-832c-0069d7e78a79", "AQAAAAEAACcQAAAAELcV652P1P0Q5pXmys3IoYCX411oJVIvfP+Jmy2/CFqdI+/9vMLB5BsFQAHO55FUDA==", "a3b0e382-2671-40f1-bfed-86603296f76c" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e1dc14b-958e-495f-b88d-65de06831eb7", "AQAAAAEAACcQAAAAEAESzA/Ex8hCqtNf8AVoL0xWhK1oGDp9SvAtkFKzTz9TB3EeNz++dD0McG6xdCuWTg==", "e0961182-7da7-4201-8d64-0648ee3ef27c" });

            migrationBuilder.InsertData(
                table: "TblMahasiswaFoto",
                columns: new[] { "IdFoto", "IdMahasiswa" },
                values: new object[,]
                {
                    { 2, "1" },
                    { 3, "1" },
                    { 4, "1" },
                    { 5, "1" }
                });
        }
    }
}
