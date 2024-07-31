using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TambahPDFDiLomba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PDFPath",
                table: "TblLomba",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a520ba1b-4b77-493f-978d-302ed44825c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0ebbf7a8-2fcf-40fc-b82a-2d1d9ad9de0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "4fbabf0f-340f-433d-89c0-9d1166c89db7");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 1,
                column: "PDFPath",
                value: "Csharp_in_Depth_4th_Edition.pdf");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 2,
                column: "PDFPath",
                value: "Csharp_in_Depth_4th_Edition.pdf");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 3,
                column: "PDFPath",
                value: "Csharp_in_Depth_4th_Edition.pdf");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 4,
                column: "PDFPath",
                value: "Csharp_in_Depth_4th_Edition.pdf");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe620775-2f27-430f-9b10-1eddee798357", "AQAAAAEAACcQAAAAEMOvlxh+crPu1+ZC0KGynibuaWqTGb04vBjidy3jvilG2nG4a0nYg+IpF0uKQCNZzg==", "b9e15c7c-d82f-475a-a50a-231c69053bdb" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76b5109c-9ed1-4c92-8e7f-7f4b89c7c60e", "AQAAAAEAACcQAAAAEJslEf7j8jDGPWT/nq0MeFbaXsLB+vZGVXOYyRj2cUkjcvYWVNBFCKVCSheDvi7G+w==", "a2967e40-e4cf-4310-9c1a-99d31ec64aa9" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db51c6ec-2213-4977-944e-d146f8136957", "AQAAAAEAACcQAAAAEDIzkgv2NQMX5x3NFYQ95voNn6h+S+5SBfAE6b3xS18oRU9CciFwNK9Tc3sFmE74sw==", "962cf206-1567-4bba-b1cd-646f7765572d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PDFPath",
                table: "TblLomba");

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
        }
    }
}
