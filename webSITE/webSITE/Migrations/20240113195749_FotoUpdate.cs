using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class FotoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "29fb7b65-c07d-4a65-8128-12b280b34285");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5a452d86-50b8-4479-93bc-5c723e7b159c");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "D:\\Coding MVC\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Foto\\Front_Building.jpg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: "D:\\Coding MVC\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoPath",
                value: "D:\\Coding MVC\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoPath",
                value: "D:\\Coding MVC\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoPath",
                value: "D:\\Coding MVC\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "659ebe14-d35b-4ac5-9225-305cdd7731f2", "AQAAAAEAACcQAAAAEKRoBRLlEICvB3E9cubQufoR9KM5kwYMDg5Ir3qriS3C54SmO6W4+OsbhRdjPyTpqQ==", "dcf6452c-2596-4938-89e1-f3227ea08538" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c787df18-e9bb-456e-921d-1afe5fb0c7d0", "AQAAAAEAACcQAAAAEJYPjiF81FErzyUZ/ZbDTcwOcgphbveZlFlg9IOyRcQdRYX5xf1kVevrmQ1bjz9jPA==", "88bfc0fc-7a60-4cea-9e6a-c023a6596954" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "407e5752-a5c9-410e-9870-ce903d596dc3", "AQAAAAEAACcQAAAAENTlS7DTlL6s+hdjxMWGe9O2Mt77qFLTps1kzyj76WhfBqSZ+0V0Jd0BtUFZNtlZSQ==", "3403eda8-0ff5-4fdc-bd55-df2ac1720da9" });
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
