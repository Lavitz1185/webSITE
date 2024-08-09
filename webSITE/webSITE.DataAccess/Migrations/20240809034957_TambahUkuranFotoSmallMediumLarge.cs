using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TambahUkuranFotoSmallMediumLarge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Keterangan",
                table: "TblKegiatan",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Large",
                table: "TblFoto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Medium",
                table: "TblFoto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Small",
                table: "TblFoto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "89bbf80d-5932-44ac-862d-5bf0a2754582");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "371c4614-d992-4a7f-9fde-d6b9b45bc54a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "848bb3ce-3be2-491f-8334-c2e7a215ce97");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7f00d79-d28e-4200-bb5d-a4667e4380d1", "AQAAAAEAACcQAAAAEOY3gBPEQc+uwQgcfKRynuDnZaf9JYeHy9vx+GEaQj2QE+H6syjYsZKpEJeaPrU1hg==", "625c6859-630e-4f51-bd9b-1f91148bcea8" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad3cf5d2-4d39-46af-a9c1-2a7b57599074", "AQAAAAEAACcQAAAAED24lJ6Gyd4quLWusT9/7GoXn+ZWRJKQCtdO0r/lOKraJuS7mbluaCxr7yrGOEiZpA==", "9e3148e2-1325-45bc-8050-551c7c7532e7" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ffc27ca-2f44-45f6-b417-610bd5144a15", "AQAAAAEAACcQAAAAEHfkHbjOoXNDjDBAVedNWV92Iu5prgjPqBtsr5phc8ol+wW7vvwywi4hoLVsK3TtPQ==", "19c57ed8-33ee-420b-9e91-e7d448f60b90" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Large",
                table: "TblFoto");

            migrationBuilder.DropColumn(
                name: "Medium",
                table: "TblFoto");

            migrationBuilder.DropColumn(
                name: "Small",
                table: "TblFoto");

            migrationBuilder.AlterColumn<string>(
                name: "Keterangan",
                table: "TblKegiatan",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "95cfb43d-d0eb-41fa-8abf-6323e72972f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "69899856-f599-4ef5-93c7-ea7b00214c28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "3d257050-7947-4635-abfc-71b3d8ae5225");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce8e1ced-3e36-49fd-86b2-8f6a97b88f27", "AQAAAAEAACcQAAAAEOJVCSFbFmuAl85QsYqeQ9VqC5/Ky5CSz2zu671znIwCnmPUQ3HOiMg+3Pw/hWy9rQ==", "db7e12a4-ffd0-4be6-8d5c-071fa99dac22" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a9eb07c-b5f4-42f3-8cb1-07d288d7047e", "AQAAAAEAACcQAAAAEOVrXekYhsMK25fjUjavoeJQao/bQZKTbUxa1w4Kawhxm0u5fGY3ZGzOMc61LRil0Q==", "714ae30a-aefe-44f0-9f86-a052e84f1b96" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bc05ad2-3db1-47b8-9300-cdc97b004ba8", "AQAAAAEAACcQAAAAEAsnN+GxIwT+yfD3fAPD0cSHxO813xmMsnhva0pJz2n34nzR+OqqnvhyOR8BZhSzCw==", "b679b53b-2ccd-43a0-aa62-9337128c44c6" });
        }
    }
}
