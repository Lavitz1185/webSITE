using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UbahModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4891d6fd-e2e6-4960-9f90-247158fec232");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2bf7a7ec-993b-47c2-93d9-18bce9101c3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "b423dd5a-3884-400f-9f7e-a14e73f4700f");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aaf8567a-87e5-4064-a26a-615be1a23de5", "AQAAAAEAACcQAAAAEM6k//6INPpjYE1KBiK4d1bF8vggrmqGKg83Oc3miqfZfudd7zfaO8btwD5ok4Vakw==", "888e5aea-4f2a-4941-9179-e556665beb44" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "421c955c-61d1-41f1-884e-6f1f32b190c8", "AQAAAAEAACcQAAAAEKO13Gs9nS+Vyl1/mOEg5Yx9kaGriEhcvMfJEjDgaVDAlEksom13b+5Q2CeHlva0Zg==", "0d5af767-951d-454b-abfa-a7450f95cdbc" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec420ea2-33fb-48b5-9133-fb5158494d79", "AQAAAAEAACcQAAAAEPsvv1Ye6SGZOKO00YduqA2VADVd/Puh4H+2uoDRDYvdUCVKnMoUEXIHFqHfRDWhMw==", "2ddc81e3-11ce-408b-9fae-c56589363f3f" });

            migrationBuilder.CreateIndex(
                name: "IX_TblMahasiswa_Nim",
                table: "TblMahasiswa",
                column: "Nim");
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
                value: "fec0bdff-713d-4924-bbd0-489614a0adbc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5bd7cc3d-fe7d-458f-b94f-5c792ba00564");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "165ea6d2-7d29-4985-a078-55cf9347acbb");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "270d5945-f20d-4907-b5c7-48e7347731af", "AQAAAAEAACcQAAAAEOnwgkn0VpM/cPvZMSRUEgLRwnQ5OiG5J4Vl+vw2Ey/WWlzzyneZ60ra7EQx6vImSA==", "65554d7f-b8c1-4fa9-be83-5f011599777c" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4843e05-0d8c-43fa-9ca7-0ad2c4839e86", "AQAAAAEAACcQAAAAEAZ6MR2VpF1lHwIYBpJb7MhgirTplVB4CNF8HIYN/JIEFMsl5HBSjuV97nVRfaNwlw==", "aba56ec3-8594-4230-a2d3-230947f27500" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae127854-0640-4d92-95d8-e13c3fe94fc8", "AQAAAAEAACcQAAAAEGLttFC+N1F9I0QUyHwkakviK/QEaWBdkTPp+y2BmCQfcAvnINgDgTKl/wQQw6pKTA==", "bb54cdb3-345f-4823-ad3d-9023caf52589" });
        }
    }
}
