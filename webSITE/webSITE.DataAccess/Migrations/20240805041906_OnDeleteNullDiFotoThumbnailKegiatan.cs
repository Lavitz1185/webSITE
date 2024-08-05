using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteNullDiFotoThumbnailKegiatan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblKegiatan_TblFoto_FotoThumbnailId",
                table: "TblKegiatan");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2f0afa3b-1097-423f-88f1-b71b829fccf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "93baf42b-aedf-48c2-b1fc-5f15d8825116");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "65d7490a-60ef-48de-a92a-0530c1f8abaa");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bffa95b-48a0-48ea-b2ea-7f5dd0b270c2", "AQAAAAEAACcQAAAAENBtdm2IJJBYG0Equ5V54EszryG6R2cwnoc6ZDUQLv6B1S0LjJRd7mvtJsogzoHeFA==", "3fec6558-98fd-4d61-8acd-b895900a7679" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14195b1b-8770-4e94-baa5-b18eb0e7d821", "AQAAAAEAACcQAAAAEGS6Wi3bUVSUkeaijMzwm2l5EZmGXQ2WKibXlPaoB98qOsFNUbQnpv4FYMB6WAcDDw==", "10c49d00-f761-4a2e-ac0c-e51c6dfc0982" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a34bba4-28cb-48cc-8c7b-356c516828ee", "AQAAAAEAACcQAAAAEFmsEUn9w61wv9IHyDSEZZLstWWVr5reL8BP+uVBT5LncVyhnB/+EM5qr5rDPwl3lQ==", "61e4a37d-76e5-4316-8ecc-7b2939189a95" });

            migrationBuilder.AddForeignKey(
                name: "FK_TblKegiatan_TblFoto_FotoThumbnailId",
                table: "TblKegiatan",
                column: "FotoThumbnailId",
                principalTable: "TblFoto",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblKegiatan_TblFoto_FotoThumbnailId",
                table: "TblKegiatan");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TblKegiatan_TblFoto_FotoThumbnailId",
                table: "TblKegiatan",
                column: "FotoThumbnailId",
                principalTable: "TblFoto",
                principalColumn: "Id");
        }
    }
}
