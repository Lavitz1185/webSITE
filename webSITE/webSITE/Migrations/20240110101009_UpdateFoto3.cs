using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFoto3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4a17af72-9d25-454f-9338-c6adbc90cc36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "6b60a7a1-e2c7-47ef-be37-bda94443f2b9");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c4095d2-6776-4a9d-a2d9-fa08e5cdee7c", "AQAAAAEAACcQAAAAEFUnakm5Q3YsCP6N6swkVsxwQq+O7hEpUkODC8PLeO89mz40PJm2A2OqCa4pUGVQEw==", "79d3ec54-890e-4ae6-ae1f-46924cd351bb" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a86b7464-8025-4c00-bd3e-ec6ba936f490", "AQAAAAEAACcQAAAAED/9jjYBVHU7U+hHw181GKBbUa1lcmSd8fH+sciA31aUNC7dcmZzAewxeZVpwsh2sg==", "3a0234d2-f6c1-4203-86ed-7e4505ee6140" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1ae602a9-4d9f-471a-bef2-95962f4d488c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b90bcb97-765d-49fd-83a9-c50b693b249e");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\contoh.jpg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\contoh.jpg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\contoh.jpg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\contoh.jpg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\contoh.jpg");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8eb46bee-218b-4498-b429-5c34529d153d", "AQAAAAEAACcQAAAAEMcx6fnM+UdQum/Dupwa/NGyZu6NFktE1FNVc/KqLcbcFzSowFNbjzesS6dRpnJ1Pw==", "8958a086-5c24-4bb3-a2c2-d17e2e2e821e" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a6f5593-536d-449e-9159-79a0bce57d79", "AQAAAAEAACcQAAAAEGzO3u0NVR28z16AnHZsz876pqbIJHoCpYJr81yZx8KyzqyWAOOyUsTXa3m/9cxJ/w==", "e64981b6-caf9-44a9-9938-34ade47e2faa" });
        }
    }
}
