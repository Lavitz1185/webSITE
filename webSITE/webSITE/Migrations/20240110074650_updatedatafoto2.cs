using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class updatedatafoto2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "db4b6179-bd1f-42e3-8890-59d74d1f3372");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "940e2ac5-a1a6-4acc-94a4-b3a30cb18fa0");

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
                values: new object[] { "6bc4bca7-bdf3-42b6-8ad7-04b1fbcfa066", "AQAAAAEAACcQAAAAECdy2Pe9IjDTYB29zFyaIT9sDhWffD5GGGe8FoPKOEgj2rZHtueUIrKv7evlGtr2lw==", "aa0a2691-de6f-4502-a8e4-43499b44ac5a" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98092990-61de-44af-9ddd-d367bd88cbfe", "AQAAAAEAACcQAAAAELycqdjPgrDhjvuoh6buXuDuoMxvcX1uFY95fOFrRvyG7iFJCWsGgNYAH1Ep12i0AQ==", "e6806ab6-dfeb-473c-b011-69a18eb0ef43" });
        }
    }
}
