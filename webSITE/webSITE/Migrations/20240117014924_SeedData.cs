using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "58d0744e-bdc7-4d08-9722-84252f0d1d53");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "56d76a2b-ee72-4938-a7a8-351e096fd0b6");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "329d4c81-80cb-4c54-932c-3dc314ddabe3", "AQAAAAEAACcQAAAAENHoAuSPbm0rMpcLD30pYYw2GT4Eaf5RJ4vNVtpx+g9xcYme0hMLwOhqlFGA42JOpw==", "03addb97-b4d3-4c9e-b943-fd5c46f93370" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9998088-2411-4d29-9c9d-155b8e8d6932", "AQAAAAEAACcQAAAAEGlWgNncoFY5OTJwtI4nlA3wwMbuqkxWQgzh9Tg/mhrVCb0w2V86jWmitQC1SpcjNg==", "6a73ca2b-6302-4a9f-a58f-c2e6448fa077" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f9f127e-50d1-4087-8bda-100739488ab9", "AQAAAAEAACcQAAAAEDGA0P9LAHgx5ZH1LoVzLiDD4yu0Qmr9RBGTLayQQDZNGRuOnSWyJQ6KbXrpX7UV4g==", "b023fbb8-e5a7-4ea5-89c9-77db9431aa51" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
