using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TambahLinkInstagramDiAlbert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bf0134c9-09f6-4026-885c-04499c16fdd9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d612d053-b579-4745-9d1d-58341c32a6fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "7bee1f70-9a1d-4dc5-9c5c-ad2b93265cd5");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a68f69a-921f-4be2-8e2b-74b025e48c27", "AQAAAAEAACcQAAAAEPH9rk5futgrZtfOOk9Ejr6V59ZoA/23ocBVGHyZLwEgmyOPAb6W2FjcxUGuKjs5Dg==", "15b3c76e-c20a-4239-94f5-60b4b21827a6" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4416b91-082e-40f5-9512-b5c3a518de67", "AQAAAAEAACcQAAAAEHK6TX805YJ8ZFifu13UoejX44kJbgklvEYi8a0kdHTMvTqm9Wu9hfcfKPs9uQ0v9w==", "b796f1bd-55ee-49bf-a4c4-3fb9b874d70b" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "InstagramProfileLink", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d72eddcb-a58e-4b9c-bdca-318a8ec59b19", "https://www.instagram.com/_all.berliano/", "AQAAAAEAACcQAAAAEOVo6gHBkjvMJCQfpx/HKqdczj26dRHzV7mj4NtYpBybCsWqnieP/F2Kz5rS/ENyNA==", "7f981998-11d4-487a-8339-2c501c7d51ef" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d63f65b6-55ff-421e-80fe-ca3b35c13853", "AQAAAAEAACcQAAAAEFtbFbVjGTTmkPeS2avIzu+pjXdnexEa/bB1LGC4YcStLUTLXejznD/We5e/FtQmWA==", "336e983c-3b3a-4dc2-99be-84c90aa47347" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fa08101-c58b-4370-9cbe-ed3331d0ec13", "AQAAAAEAACcQAAAAEHmnxHVvhYizIFw6GiWZp8IhAOmvIloRt3v+bmux9Ht3jvr/opUSpegAEsBrvAfO9Q==", "c975076a-c2c2-44b3-9c65-9d8c03969364" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "InstagramProfileLink", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b5850f6-c166-4225-a478-50b2ec4f6274", null, "AQAAAAEAACcQAAAAEOxYK7WWOYz+SsK9LEBlKiRNnzQTHXkDzjf5m4z+dsFhhjNzQSqQQb/1GX0T27UZYg==", "c9a32677-b89d-48d1-b1db-45bfcd1ba3fd" });
        }
    }
}
