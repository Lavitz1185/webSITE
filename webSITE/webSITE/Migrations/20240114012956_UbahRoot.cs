using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class UbahRoot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "93bb894d-c7fb-401d-ab6a-8c227f46cd57");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3d123fc9-c849-4eb8-be26-76e64647ee8f");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "\\img\\Foto\\Front_Building.jpg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: "\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoPath",
                value: "\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoPath",
                value: "\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblFoto",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoPath",
                value: "\\img\\Foto\\contoh.jpeg");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1c0b50b-8c55-48be-bc03-7aebf17c74ed", "AQAAAAEAACcQAAAAEIfBRCgUga5xqXyP3/xPdW50BIb0vQNkeCQPzIN/QlXcqcyl7kuMCrmZCHo8dwumMQ==", "ee8181bc-0579-4e6d-95aa-abde4300bfa3" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "364beb82-67d7-40ea-a583-447d4aaff97d", "AQAAAAEAACcQAAAAEF5yGLzAN9okOUBp6bO8yJ3j9cNBXafyY5UH/GIZQwPLfKOqvCu8V6nsZC/CeYNVxQ==", "d09302aa-989c-499f-9836-fa8766e45b2b" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc9c5892-8610-48aa-82b0-539fc435cf16", "AQAAAAEAACcQAAAAEHki1RwC7arubXMy2Q95/Acrs3tpSrB61aE8OjKmWOZ4+rLhirrFRfaj1lWhFgbimA==", "18a1875a-6500-4116-8793-686926a056b3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
