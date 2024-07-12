using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BuatIndexNimMenjadiUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TblMahasiswa_Nim",
                table: "TblMahasiswa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "232108a4-3615-45d7-a9a3-b774afaa31f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f9c63a59-e20b-4554-a8f7-afd04a637283");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f912212d-4f0b-4028-a763-3bf9492f1ff2");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d924d416-6c63-4d89-a738-708f734180e7", "AQAAAAEAACcQAAAAEIxmqjDjy3ky6/9milaWwvgx8WxEtP5KZmtWa5GQu/NctM3U82344eibdVtIhYBv2A==", "6f45b2ca-3c0e-4712-aec0-e5eab42fcb25" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cbee7d3-2774-41f4-8196-4a2bd24a46ea", "AQAAAAEAACcQAAAAECxZDDZvDDvZ5+u+CRt5mNUF+DRQ2M7fetyS6Ne7EoIK0Ea3FkUmZ4+cBRiSrzA1BA==", "12c9edb9-65fe-4d9c-a870-b20269844a24" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "539fc411-fae0-4d3c-afc9-d1b7a9029310", "AQAAAAEAACcQAAAAEGlMg96sol+6BAJ9CFKXmWbg2AzkFJd3Jxc9dbo1AhoGPi7NQIzgWswfHwdjTewVjw==", "1bc66d19-cc30-4d9c-885f-7f710ca5692a" });

            migrationBuilder.CreateIndex(
                name: "IX_TblMahasiswa_Nim",
                table: "TblMahasiswa",
                column: "Nim",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TblMahasiswa_Nim",
                table: "TblMahasiswa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "572a38d6-cd1d-4588-bb5e-324630f92385");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3b2f94b0-0337-4600-85ec-ebaf333adffa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "82800ed1-7d5b-4ef5-a2b2-755d4e4a1602");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "caca796a-a33f-4cc1-87fe-1f85130f0a11", "AQAAAAEAACcQAAAAEDx0EaqgvW4VxkR+drV/5jmugY092IsUhYtoe7HnSKy9jM6//LwAppAhSE2d1C9OHA==", "eb0866b8-98e4-488c-8696-389a277ed756" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02102982-ad99-4616-b0db-8dff886939dc", "AQAAAAEAACcQAAAAEMFp7fEB89i0WcTcn+Gcpxi6E6W+GTYA1yO1tRX2IWPcJM7Nnop7Bco/PzTJn5IE7w==", "fd764568-3863-45a5-a252-19a057d64f40" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95479723-2e9b-46f4-b0c0-c6810e526975", "AQAAAAEAACcQAAAAEO6vQU0708sCqb1aYcfz1pUMiRh9iDb/MfKn2/fYH4jK6mcYRSR33YLMwi0lQVdh+Q==", "28fd1084-b92d-4924-8e3e-5411d7c4c2b7" });

            migrationBuilder.CreateIndex(
                name: "IX_TblMahasiswa_Nim",
                table: "TblMahasiswa",
                column: "Nim");
        }
    }
}
