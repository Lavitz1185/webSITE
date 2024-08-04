using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TambahMediaSosialDanMaksPanjangBio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusAkun",
                table: "TblMahasiswa");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "TblMahasiswa",
                type: "character varying(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "FacebookProfileLink",
                table: "TblMahasiswa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramProfileLink",
                table: "TblMahasiswa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TikTokProfileLink",
                table: "TblMahasiswa",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a90aa586-4887-48e6-977e-74155256b88b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f16d3081-fe34-4133-9edf-7faa0465055f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "206bedac-3feb-47f6-836d-170a9380a346");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "FacebookProfileLink", "InstagramProfileLink", "PasswordHash", "SecurityStamp", "TikTokProfileLink" },
                values: new object[] { "d63f65b6-55ff-421e-80fe-ca3b35c13853", null, null, "AQAAAAEAACcQAAAAEFtbFbVjGTTmkPeS2avIzu+pjXdnexEa/bB1LGC4YcStLUTLXejznD/We5e/FtQmWA==", "336e983c-3b3a-4dc2-99be-84c90aa47347", null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "FacebookProfileLink", "InstagramProfileLink", "PasswordHash", "SecurityStamp", "TikTokProfileLink" },
                values: new object[] { "3fa08101-c58b-4370-9cbe-ed3331d0ec13", null, null, "AQAAAAEAACcQAAAAEHmnxHVvhYizIFw6GiWZp8IhAOmvIloRt3v+bmux9Ht3jvr/opUSpegAEsBrvAfO9Q==", "c975076a-c2c2-44b3-9c65-9d8c03969364", null });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "FacebookProfileLink", "InstagramProfileLink", "PasswordHash", "SecurityStamp", "TikTokProfileLink" },
                values: new object[] { "9b5850f6-c166-4225-a478-50b2ec4f6274", null, null, "AQAAAAEAACcQAAAAEOxYK7WWOYz+SsK9LEBlKiRNnzQTHXkDzjf5m4z+dsFhhjNzQSqQQb/1GX0T27UZYg==", "c9a32677-b89d-48d1-b1db-45bfcd1ba3fd", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookProfileLink",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "InstagramProfileLink",
                table: "TblMahasiswa");

            migrationBuilder.DropColumn(
                name: "TikTokProfileLink",
                table: "TblMahasiswa");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "TblMahasiswa",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(55)",
                oldMaxLength: 55);

            migrationBuilder.AddColumn<int>(
                name: "StatusAkun",
                table: "TblMahasiswa",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e8abbe2a-11b2-4b1d-8042-c3213d11ba64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "bbabb1b7-df11-4c43-aaaa-e66abcafede7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "77bfe7c0-d596-4e1a-a075-0f4039f5ae3e");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StatusAkun" },
                values: new object[] { "74fb924d-7197-4707-b289-94083c85794e", "AQAAAAEAACcQAAAAEKcNLy/RDLqKTueBgYhd5w24SuNvNHrr83e27xeVseyaja1/wFVrgXvyhGusRQKZrQ==", "19c28df7-77f3-4161-a235-c88050fe9cd6", 0 });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StatusAkun" },
                values: new object[] { "ae23bb87-8df8-42f7-be70-01b0ce14662d", "AQAAAAEAACcQAAAAELrDQjxW9VhGIWjv0IxkdDGKglB3VDZCNdx0AXXJ/6eLl7pWp0U/XiuftLLAnGVXhA==", "6a12a739-be48-4a49-8441-7f058adb08b3", 0 });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "StatusAkun" },
                values: new object[] { "8ac6d132-7929-400a-9480-aef6c69d299b", "AQAAAAEAACcQAAAAEJSFGsL7Uyss+cDJkfSUXZmT+7CYrzsHclcEaxYt7diCIEaiI24VFxfmSxAAM0wK3w==", "68e20c10-2b21-47c4-8b25-b076a1dd32b6", 0 });
        }
    }
}
