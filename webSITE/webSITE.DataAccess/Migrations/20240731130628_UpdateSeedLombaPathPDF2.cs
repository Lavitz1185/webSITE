using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedLombaPathPDF2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "96b7a5b4-39a8-4c88-a512-89e3948917a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b8f18541-ae1e-4ac1-b2f3-fbe5728f21d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "e7f6db97-78ad-49a9-895c-6531aa68377c");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 4,
                column: "PDFPath",
                value: "/pdf/Csharp_in_Depth_4th_Edition.pdf");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f48ae7b9-8492-4834-860a-73ae1cc69615", "AQAAAAEAACcQAAAAEIQqWYhdnaDWbjHZksRsjtdupJ1bfl810ThTk9dOvzb8ZYxKSiSJU4rpJo6x4zsHyA==", "bc884d1f-b2c4-430d-b5a9-ccb90f49c9f2" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7b10d44-4366-4ecc-8857-9219c7b2caed", "AQAAAAEAACcQAAAAEE/oDVZVH46HfrMHXHQbcSsWXkTgNiuBEHv6HiCmeKJbyMPU45wM1ffRGVOxeZtUhg==", "e00cba64-a397-4d63-8ea0-fa40566b7e52" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef19bb21-44b7-4bc2-8dc7-61efe66933d3", "AQAAAAEAACcQAAAAEPH7e2WRaRKFB60uGvRG8AhrQjvVXtihMtJakhq3px+i2Y077UIl0RRyMkXSnpWS+Q==", "34523c11-fc07-4275-80e9-27bb23e9f835" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "de491b86-3253-43ef-a11a-c882d5b08c2f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ad7b43bc-bb7b-45d9-b983-9f2ec36e399b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c576bcbb-6e1e-4801-99f0-88ec189dcfca");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 4,
                column: "PDFPath",
                value: "Csharp_in_Depth_4th_Edition.pdf");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5346a8b9-b9d9-440d-9c86-51d419361cc4", "AQAAAAEAACcQAAAAEFNEjy0DVVxFZNJzd/7jORA34Pog8sPUvSm86Wn92ua4X6860nsm3pVfYymlMEvFcA==", "9701d23a-5952-4af6-a46c-4d9956d3667e" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e97a2a95-12c5-4936-b529-13e51c0583d6", "AQAAAAEAACcQAAAAEJ/1dOwS873ChP8ACJGa5LiamDcBsJzRFqR5UBWJkYD/zQ/xIiDtf34CSiG4JN7rhw==", "a0101c82-059c-4775-9464-077810db5dfd" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d6aa92e-4cfd-4247-bf72-dd096e3d4ab1", "AQAAAAEAACcQAAAAEODZtuSNlSU6thhx2NMJ+hgSWHwO/mrn0Qpq6pXfOF6WoYIbGFHmSIkFSLfMcAPzHA==", "5aa60f2c-2231-4840-be6a-54a66b0c0084" });
        }
    }
}
