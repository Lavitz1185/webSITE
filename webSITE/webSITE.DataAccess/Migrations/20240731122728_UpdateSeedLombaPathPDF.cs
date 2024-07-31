using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedLombaPathPDF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "de491b86-3253-43ef-a11a-c882d5b08c2f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ad7b43bc-bb7b-45d9-b983-9f2ec36e399b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c576bcbb-6e1e-4801-99f0-88ec189dcfca");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 1,
                column: "PDFPath",
                value: "/pdf/Csharp_in_Depth_4th_Edition.pdf");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 2,
                column: "PDFPath",
                value: "/pdf/Csharp_in_Depth_4th_Edition.pdf");

            migrationBuilder.UpdateData(
                table: "TblLomba",
                keyColumn: "Id",
                keyValue: 3,
                column: "PDFPath",
                value: "/pdf/Csharp_in_Depth_4th_Edition.pdf");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5346a8b9-b9d9-440d-9c86-51d419361cc4", "AQAAAAEAACcQAAAAEFNEjy0DVVxFZNJzd/7jORA34Pog8sPUvSm86Wn92ua4X6860nsm3pVfYymlMEvFcA==", "9701d23a-5952-4af6-a46c-4d9956d3667e" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e97a2a95-12c5-4936-b529-13e51c0583d6", "AQAAAAEAACcQAAAAEJ/1dOwS873ChP8ACJGa5LiamDcBsJzRFqR5UBWJkYD/zQ/xIiDtf34CSiG4JN7rhw==", "a0101c82-059c-4775-9464-077810db5dfd" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d6aa92e-4cfd-4247-bf72-dd096e3d4ab1", "AQAAAAEAACcQAAAAEODZtuSNlSU6thhx2NMJ+hgSWHwO/mrn0Qpq6pXfOF6WoYIbGFHmSIkFSLfMcAPzHA==", "5aa60f2c-2231-4840-be6a-54a66b0c0084" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
