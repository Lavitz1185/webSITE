using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OnCascadeDeleteDiLomba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPesertaLomba_TblLomba_LombaId",
                table: "TblPesertaLomba");

            migrationBuilder.DropForeignKey(
                name: "FK_TblTimLomba_TblLomba_LombaId",
                table: "TblTimLomba");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TblPesertaLomba_TblLomba_LombaId",
                table: "TblPesertaLomba",
                column: "LombaId",
                principalTable: "TblLomba",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblTimLomba_TblLomba_LombaId",
                table: "TblTimLomba",
                column: "LombaId",
                principalTable: "TblLomba",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPesertaLomba_TblLomba_LombaId",
                table: "TblPesertaLomba");

            migrationBuilder.DropForeignKey(
                name: "FK_TblTimLomba_TblLomba_LombaId",
                table: "TblTimLomba");

            migrationBuilder.DropIndex(
                name: "IX_TblPesertaLomba_Nim",
                table: "TblPesertaLomba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cb908db6-76e6-4972-907e-bd89209eaa5a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5c5bacdf-5735-4355-9de4-bb2ec4b01a35");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "0708fbce-bea3-4638-9ee6-efbd2b1c67d1");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba44a1ed-3f57-4435-a84d-ec02ef8989c2", "AQAAAAEAACcQAAAAEH8TmohcmGHz3OJh1NNlA8D2WIroxr4c5pBYajSJo1EG+TxOCzCVSkh4eAZUQOJY8Q==", "ae278865-5494-40d6-babc-5b0967b314b0" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9504b270-047b-4830-8b0b-27644b959282", "AQAAAAEAACcQAAAAEMWvrbtyC0uxUMBK3jAPnXmmgHDgo5FWtZVXw3F4xV3aqZSy2fCDvKIYecl8RBf3Fg==", "e5c9b39e-aca3-4fa7-b5ec-9247c46d3fa0" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ba3350c-6d80-431a-8403-e4e470994416", "AQAAAAEAACcQAAAAEO9/Kl9FMMSal3LFMozRx/c2BCU2HZj1vpYf8o3SSBe/C2oKhNDtrSPuiszTdgKYSQ==", "a6d8764c-c7c3-46f5-b89b-76b38a4e8ac8" });

            migrationBuilder.AddForeignKey(
                name: "FK_TblPesertaLomba_TblLomba_LombaId",
                table: "TblPesertaLomba",
                column: "LombaId",
                principalTable: "TblLomba",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblTimLomba_TblLomba_LombaId",
                table: "TblTimLomba",
                column: "LombaId",
                principalTable: "TblLomba",
                principalColumn: "Id");
        }
    }
}
