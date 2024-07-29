using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TambahLinkGrupWaDanFotoDiLomba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FotoLombaId",
                table: "TblLomba",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkGrupWa",
                table: "TblLomba",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "dc8e7307-df55-4d67-80a3-c85cc9ab02d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8f5a499d-42c5-44d8-8275-39a0958edbf9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "410a047b-dbf8-4762-9b83-b8f1978f5400");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FotoLombaId", "LinkGrupWa" },
                values: new object[] { null, "http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM" });

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FotoLombaId", "LinkGrupWa" },
                values: new object[] { null, "http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM" });

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FotoLombaId", "LinkGrupWa" },
                values: new object[] { null, "http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM" });

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FotoLombaId", "LinkGrupWa" },
                values: new object[] { null, "http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb606927-c1c0-483a-87c9-365f08976fe7", "AQAAAAEAACcQAAAAEP2rNyuufJ6IAJk3L1niNaawL/gW85WjvlVVRpS8h6B2dMaTpokZ3NvxIEPi3dU3og==", "d715953b-ccdc-4919-a7ff-d5e90d3a16a6" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08b1d519-4e1b-459c-bbd8-c477416fde65", "AQAAAAEAACcQAAAAEAW3qF7KPKMvR7N9GBKG3ZcPqiIQTy8hDOgWYQDcZFiybuaklCx3Fsfz28mqPGTgSg==", "19b2306b-bc88-4293-ae60-1345a72253c3" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "871b61af-1aff-4c66-bbf8-86df1e4e8f67", "AQAAAAEAACcQAAAAEPJVzLtVBEtQBOlshghbVB/ocPFgO5InKLa2MUuhARRzHDsbz4/eJO2OTXrHQJZ7TA==", "e5825d5d-ced5-4d0b-948d-d6dc4c9832c2" });

            migrationBuilder.CreateIndex(
                name: "IX_TblLomba_FotoLombaId",
                table: "TblLomba",
                column: "FotoLombaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblLomba_TblFoto_FotoLombaId",
                table: "TblLomba",
                column: "FotoLombaId",
                principalTable: "TblFoto",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblLomba_TblFoto_FotoLombaId",
                table: "TblLomba");

            migrationBuilder.DropIndex(
                name: "IX_TblLomba_FotoLombaId",
                table: "TblLomba");

            migrationBuilder.DropColumn(
                name: "FotoLombaId",
                table: "TblLomba");

            migrationBuilder.DropColumn(
                name: "LinkGrupWa",
                table: "TblLomba");

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
    }
}
