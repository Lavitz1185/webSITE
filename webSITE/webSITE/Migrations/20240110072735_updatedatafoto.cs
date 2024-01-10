using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class updatedatafoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4a7e5b26-24a7-4b83-afb5-d5944ed0fe62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c4fad1d5-ce3c-4102-8328-414abb85c686");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "/img/contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: "/img/contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoPath",
                value: "/img/contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoPath",
                value: "/img/contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoPath",
                value: "/img/contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "093d6d75-7bb3-4716-83ec-14babef318a4", "AQAAAAEAACcQAAAAEC4yVCE8CjeePeWdsQMrrGWPg5V8iFYxUhQwrgTxpVSkd9etoBaNlANP4wgWXIL6YQ==", "9b7b051a-866b-41e9-9ef8-47a408ccc73a" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62d0c3f5-d77b-4036-89b2-f27fa354e4f3", "AQAAAAEAACcQAAAAEOwn2Uxh8V48+fFJjLKdOS1lx+wsOdJ6IQbp6tZSDw8Ml63Rn5dzjxkT+cWJM9Gu/Q==", "b8c7506d-04ea-4a33-b53a-57ce7de07ec7" });
        }
    }
}
