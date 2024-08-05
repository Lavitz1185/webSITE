using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TambahFotoThumbnailDiKegiatan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Keterangan",
                table: "TblLomba");

            migrationBuilder.AddColumn<int>(
                name: "FotoThumbnailId",
                table: "TblKegiatan",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "447fb64e-c576-49ec-8630-96b854f2ece9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7898860e-b805-4413-868c-051df0f0cd5d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "5d1a7c71-14c2-4cba-9dff-134b7108f3dc");

            migrationBuilder.UpdateData(
                table: "TblKegiatan",
                keyColumn: "Id",
                keyValue: 1,
                column: "FotoThumbnailId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblKegiatan",
                keyColumn: "Id",
                keyValue: 2,
                column: "FotoThumbnailId",
                value: null);

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1483b009-ca22-4d26-94ac-688de4ae4ed9", "AQAAAAEAACcQAAAAEJhxJ9SA6pw4HXYPf8njsosU4jkEafbSh4mwiGogGBuUSaP1j0DW8k6tkEYGC4rU0g==", "a174db91-98a0-4ec5-89c1-c559dc79c0ae" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e14045a4-a2d7-43d2-a517-3d987b3b8a1d", "AQAAAAEAACcQAAAAEDCaoeZNf5gJav4HUzofpJ8/WfWHc2dcTjuFuY/uHWU3rcSvVYDaVfs6q0NWaV3i0g==", "cdcd2cf7-df18-41d6-b67b-285ea71ab4ee" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67b1a69c-ae26-4829-b3a2-8ecc930c4566", "AQAAAAEAACcQAAAAEFkZyWyEsS0Q3nXuSX92PKwBuTnmUFzNk+dH2wqXWL/DKZoZsTaYPGX3z+GWI17OBQ==", "7b654987-f4db-4c5b-8ba8-bf2468178b01" });

            migrationBuilder.CreateIndex(
                name: "IX_TblKegiatan_FotoThumbnailId",
                table: "TblKegiatan",
                column: "FotoThumbnailId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblKegiatan_TblFoto_FotoThumbnailId",
                table: "TblKegiatan",
                column: "FotoThumbnailId",
                principalTable: "TblFoto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblKegiatan_TblFoto_FotoThumbnailId",
                table: "TblKegiatan");

            migrationBuilder.DropIndex(
                name: "IX_TblKegiatan_FotoThumbnailId",
                table: "TblKegiatan");

            migrationBuilder.DropColumn(
                name: "FotoThumbnailId",
                table: "TblKegiatan");

            migrationBuilder.AddColumn<string>(
                name: "Keterangan",
                table: "TblLomba",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 1,
                column: "Keterangan",
                value: "Keterangan");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 2,
                column: "Keterangan",
                value: "Keterangan");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 3,
                column: "Keterangan",
                value: "Keterangan");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 4,
                column: "Keterangan",
                value: "Keterangan");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d72eddcb-a58e-4b9c-bdca-318a8ec59b19", "AQAAAAEAACcQAAAAEOVo6gHBkjvMJCQfpx/HKqdczj26dRHzV7mj4NtYpBybCsWqnieP/F2Kz5rS/ENyNA==", "7f981998-11d4-487a-8339-2c501c7d51ef" });
        }
    }
}
