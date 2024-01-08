using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class UbahModelMahasiswa1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "242e57b6-a6e2-4e7a-863e-7592714270a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "be5ef484-3952-4650-9ce3-635c3019924e");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e461a6f-b3f4-4531-80c9-ecd1155a0bf3", "AQAAAAEAACcQAAAAEMzVVpIX4q1ITf/W8Vlv8dL2PM4lLBLjo10IsmKkObOb5hYDrtqUH45CBi5G7HQQWA==", "b15d884b-4443-4015-81e9-f40ecbf09fda" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07b1c7d6-2160-47be-abb6-f57e536f4309", "AQAAAAEAACcQAAAAEHT+W9LmzxoigEpev+PJtXLj8Dsjt1isTTq7aDtgHeQZBaYk7HYIJNt78WJQPHGlvg==", "e0fc6454-388a-4645-8b74-a8caa550fadf" });
        }
    }
}
