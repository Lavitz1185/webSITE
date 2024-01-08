using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class UbahModelMahasiswa2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusAkun",
                table: "TblMahasiswa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "62201f37-f33d-4cd9-8fdb-b83d5b548391");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "59504e0f-1282-4709-9597-ef284c51735e");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StatusAkun" },
                values: new object[] { "99dff034-2ada-48b5-8099-ed4b4ac419e2", "AQAAAAEAACcQAAAAEOv6JQCmS6iAF7Avn8m1Z0aDOOxnNJuX939YOBepGsmgMe4gfBZDBcGYJEglsjmlQg==", "7d674acf-1abd-4999-a7ea-b858da8a6f98", 0 });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StatusAkun" },
                values: new object[] { "bb3e7fc3-a9cb-436d-9a88-d652a3c0a6ca", "AQAAAAEAACcQAAAAEC624B8gFh9VWltDoyQsyBRjZpy56t3AFaai6Q6l7pMN5thiEMeTxh9VoApzc5z5PA==", "0f500d7c-7d7b-4a61-8fcd-e7d32f11db3d", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusAkun",
                table: "TblMahasiswa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "eaff335b-2287-450b-be09-d2c9fc397f60");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4a36bf71-ebbf-4dee-aeb1-6d0911342d95");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75b99d57-1cac-48ca-a3b3-f7e3cac44c9f", "AQAAAAEAACcQAAAAECrFYGucwUuQX1LLWHbeikzWLObft/vTj00fXEo8PsP77qAFfR33cpHOmLwV5GPOWg==", "40c15726-1052-4fb9-a768-d9edb55885eb" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab326288-51ba-4f0f-83d7-1fda424f5922", "AQAAAAEAACcQAAAAEE+jz5utmLTHEHS5VEH3cbF+FcnhCFdV6tERht93lLX+9m7L3Wf5Dq1FunOQTSZKIw==", "25cd09d6-2a88-457a-8f0f-de8fee5d41d5" });
        }
    }
}
