using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TambahKolomDiPengumuman : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPriority",
                table: "TblPengumuman",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPriority",
                table: "TblPengumuman");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "82e0eb28-186e-45be-8677-6b932bbf3b6f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a3d2b494-e5d0-41b3-828d-2b112f12d284");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "7bdd601b-e96a-4159-92d4-0d68e4696e50");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61d70b94-9839-4a8d-94ac-d93f69f207b2", "AQAAAAEAACcQAAAAEPy2Q2M51g2isVPjth6jDxhAelU0/7X+OKcTQGaS9P7rOF6i7uyfZLvQ9tg7D8nbUA==", "6f861bd4-2303-4141-ad1c-2bb0e0f91960" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9dd397c-a187-4c60-a41d-4f53509261c4", "AQAAAAEAACcQAAAAEJbj5prjvqy3ypwq1gxFdjazauRRm5+46Olf0/Zo4PIgqKoestHsrG3BbteJ8AMKCA==", "bf11ca49-1cf8-43be-969c-e22ac96179ff" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82527df7-16c6-4f18-9425-12503de6c662", "AQAAAAEAACcQAAAAEACDck59G3+tJ5e7Caqsyptin93ySmCDkKtn3zaN1I8YrhakPUf4OpeKnH7qyqSTKw==", "da46e7d7-adde-48cf-a051-e337372fc3da" });
        }
    }
}
