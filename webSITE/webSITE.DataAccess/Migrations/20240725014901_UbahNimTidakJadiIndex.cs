using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UbahNimTidakJadiIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TblPesertaLomba_Nim",
                table: "TblPesertaLomba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8833fbe1-b137-477f-ac87-ccdffb4b7883");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ed73bb40-4f50-4585-90d0-9e3858407dc4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "04e4f33e-d080-44cf-bc70-231a29632ab2");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ef62ee1-a919-4df1-824e-93c7800805f4", "AQAAAAEAACcQAAAAEF9r/e0XS3k04Yz1RuO1V39sNcD9uVX+pmDQh8cEs+X63WJw52Lw8EWsvoKcs0WIhg==", "358c9ee4-7d63-4082-b871-800fe15bfe8f" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c016215-751e-4505-aac7-24f35156987e", "AQAAAAEAACcQAAAAEHMVDvdFC3p/EP7lK1uaq2Jo4WroJlru4u02ct8scxbe5LJAu3gob8jbGx/y+Tkp8g==", "e5f196bc-144d-40ef-ac20-60e71fd2c4f7" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "893dfc87-a959-46c0-90a2-43d4a330899b", "AQAAAAEAACcQAAAAELcvx2ysmeOxi95xUAyAmkD99fDTlf1ekpKKeiS8zxiwGIzbE27dKiqOAV+0A7ZBug==", "b0e05471-8fa5-47c8-a336-f320427e559e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "1ef2ae51-ec94-4769-aaa7-a4b4059e54ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e552aa81-7895-42c5-a1e5-a8c6ed06c6bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "226dd8cb-f729-4467-a240-0361bd530ab3");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a907dfc0-0b61-469b-8dd7-02a4f7d127d6", "AQAAAAEAACcQAAAAEDqyTHYtV2Bec4uKebKi6qP/JYRB4HdsqJkku/igD2XD5sOimbpPEi/vFKW62uD5UA==", "818c343b-cc4d-419f-a34c-897ae8b27137" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0a4adf5-394f-443b-83f7-8f1d64b0f282", "AQAAAAEAACcQAAAAEIWzUY3S+wunLfG2mjIwMrJrYJgQfWHaVUxNqfa5hpH/NyQvsgOOOFsvJfAk5/Gs3w==", "6cf977c4-a1a2-4d5e-8800-e4cdb62866ae" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5174c308-5360-48ba-84b0-894058aca141", "AQAAAAEAACcQAAAAEAhjhXNx1TZKqdBS0znbBMPaTyH9TM3ZlCCkGWWxf8x+vhAgIWPlrKtxQer43sAX5g==", "efd428b0-fdd7-4ee1-bc03-94ff5905f519" });

            migrationBuilder.CreateIndex(
                name: "IX_TblPesertaLomba_Nim",
                table: "TblPesertaLomba",
                column: "Nim",
                unique: true);
        }
    }
}
