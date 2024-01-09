using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class HapusPhotoPathMahasiswa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "TblMahasiswa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "09638fe6-8af1-422f-8e43-f0a14368f341");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0880be5c-4f4b-4185-8f36-90cbdd41e8d4");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bc76261-7573-448f-a78d-a412f6f1bded", "AQAAAAEAACcQAAAAEOw5g7TvbTmV65dOJ0B0ezowgdL/7O6qpU3+KO6aSm3LmXzvNPQ1j5wFDkaJwz/2eQ==", "51b47321-517e-4e15-b358-79c1b7936643" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1744e4dc-d9a0-4ed7-a760-dda47b33d391", "AQAAAAEAACcQAAAAENa6AC+AKeyVWnulRnh2uL2fz6VmdgiEIG+j9V9kZd1ny0VoqftqVl4bx1r3WnU0RA==", "16f3ac07-d20a-4623-a2c2-caf7fc23982e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "TblMahasiswa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b931934e-9340-407b-9446-6e3e18159959");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "db389948-fddd-40a4-8da8-f01415d2a632");

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhotoPath", "SecurityStamp" },
                values: new object[] { "be163985-125c-4a0b-bb18-22753777bdcd", "AQAAAAEAACcQAAAAEHgUldtmgz0ju2MKrWmWdo//B1VBJzXzyaIiyC0jgQlA3MnCxgpyseuh1b4GAChjKw==", "/img/SIte_Transparant.png", "49314426-0040-49d5-a61c-62af6ac16382" });

            migrationBuilder.UpdateData(
                table: "TblMahasiswa",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhotoPath", "SecurityStamp" },
                values: new object[] { "22348510-a1f0-469e-af8a-826a40aaa78f", "AQAAAAEAACcQAAAAEPsYe9DPfhY+KtWIuYUP5T4XWXUXZ00WCyJQqN/FUOkcXDWE6PWKjC+R1JfrX1Wj4Q==", "/img/SIte_Transparant.png", "700d637a-c790-4c0c-b18f-fabe7d0ec74f" });
        }
    }
}
