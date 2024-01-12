using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "856531aa-f591-46a3-8c2b-fa48651d9de2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b81b397a-62f9-4cf0-8c58-37f8cd86ea15");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Foto\\Front_Building.jpg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64bae022-2e2b-4efa-b14a-0181f59068ba", "AQAAAAEAACcQAAAAEDiJljYqEtWCdQZ6wvYDyG+BZkvi5gxJoFTT4HSPtB+Vct5rUJIfyQQZzUkIthbqQg==", "23d48853-74b0-4827-8c46-cd38c2e467d4" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01ec1bc1-1f5d-4e42-829d-5dc0b117747e", "AQAAAAEAACcQAAAAEA73B8nheCzqQUPRdNkmpDIRd3E1GL8twr89xtM6Z8+FOTY0GpRIvtz4lEf9G6xPQA==", "d1300556-a849-40c1-884f-8e9a3bb7aed9" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abb61139-682e-4723-9530-3e291089261b", "AQAAAAEAACcQAAAAEKGkg9mCfUNdKzghl52tEgQBd6BRZyz829KotNW0vXNNXmbyAO+nPwSFB/M1mKEE7w==", "5fb381fa-7da7-4fd6-a14f-0356d86ce8e0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Front_Building.jpg");

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
        }
    }
}
