using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblKegiatan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaKegiatan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalMulai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TanggalBerakhir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempatKegiatan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keterangan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblKegiatan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblMahasiswa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaLengkap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaPanggilan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JenisKelamin = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMahasiswa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblFoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKegiatan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblFoto_TblKegiatan_IdKegiatan",
                        column: x => x.IdKegiatan,
                        principalTable: "TblKegiatan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_TblMahasiswa_UserId",
                        column: x => x.UserId,
                        principalTable: "TblMahasiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_TblMahasiswa_UserId",
                        column: x => x.UserId,
                        principalTable: "TblMahasiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_TblMahasiswa_UserId",
                        column: x => x.UserId,
                        principalTable: "TblMahasiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_TblMahasiswa_UserId",
                        column: x => x.UserId,
                        principalTable: "TblMahasiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblPesertaKegiatan",
                columns: table => new
                {
                    IdMahasiswa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdKegiatan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPesertaKegiatan", x => new { x.IdKegiatan, x.IdMahasiswa });
                    table.ForeignKey(
                        name: "FK_TblPesertaKegiatan_TblKegiatan_IdKegiatan",
                        column: x => x.IdKegiatan,
                        principalTable: "TblKegiatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblPesertaKegiatan_TblMahasiswa_IdMahasiswa",
                        column: x => x.IdMahasiswa,
                        principalTable: "TblMahasiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblMahasiswaFoto",
                columns: table => new
                {
                    IdMahasiswa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdFoto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMahasiswaFoto", x => new { x.IdFoto, x.IdMahasiswa });
                    table.ForeignKey(
                        name: "FK_TblMahasiswaFoto_TblFoto_IdFoto",
                        column: x => x.IdFoto,
                        principalTable: "TblFoto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblMahasiswaFoto_TblMahasiswa_IdMahasiswa",
                        column: x => x.IdMahasiswa,
                        principalTable: "TblMahasiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "f4fa70ec-c39e-464b-a645-726fb3ee2a23", "Mahasiswa", "MAHASISWA" },
                    { "2", "18bfd6a2-0803-4162-89fd-38265e398489", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "TblKegiatan",
                columns: new[] { "Id", "Keterangan", "NamaKegiatan", "TanggalBerakhir", "TanggalMulai", "TempatKegiatan" },
                values: new object[] { 1, "Kegiatan Pertama", "Kegiatan 1", new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Undana" });

            migrationBuilder.InsertData(
                table: "TblMahasiswa",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "JenisKelamin", "LockoutEnabled", "LockoutEnd", "NamaLengkap", "NamaPanggilan", "Nim", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "TanggalLahir", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "cf2d410b-d1d9-4313-9d91-4c6c60fdffeb", "aditaklal@gmail.com", true, 0, false, null, "Adi Juanito Taklal", "Adi", "2206080051", "ADITAKLAL@GMAIL.COM", "ADITAKLAL@GMAIL.COM", "AQAAAAEAACcQAAAAEIOqSfoY7u8WUFyVG70hnPfb+I5gzpSz+1vvQf/jYHkzzPHW7zxWwwxkj4iKCspCVw==", null, false, "/img/contoh.jpeg", "336d8b47-7c60-4232-9302-2d3c3e9aeb14", new DateTime(2004, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "aditaklal@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "1" }
                });

            migrationBuilder.InsertData(
                table: "TblFoto",
                columns: new[] { "Id", "IdKegiatan", "PhotoPath", "Tanggal" },
                values: new object[,]
                {
                    { 1, 1, "/img/contoh.jpeg", new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "/img/contoh.jpeg", new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, "/img/contoh.jpeg", new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, "/img/contoh.jpeg", new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, "/img/contoh.jpeg", new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TblPesertaKegiatan",
                columns: new[] { "IdKegiatan", "IdMahasiswa" },
                values: new object[] { 1, "1" });

            migrationBuilder.InsertData(
                table: "TblMahasiswaFoto",
                columns: new[] { "IdFoto", "IdMahasiswa" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "1" },
                    { 3, "1" },
                    { 4, "1" },
                    { 5, "1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblFoto_IdKegiatan",
                table: "TblFoto",
                column: "IdKegiatan");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "TblMahasiswa",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "TblMahasiswa",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TblMahasiswaFoto_IdMahasiswa",
                table: "TblMahasiswaFoto",
                column: "IdMahasiswa");

            migrationBuilder.CreateIndex(
                name: "IX_TblPesertaKegiatan_IdMahasiswa",
                table: "TblPesertaKegiatan",
                column: "IdMahasiswa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TblMahasiswaFoto");

            migrationBuilder.DropTable(
                name: "TblPesertaKegiatan");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TblFoto");

            migrationBuilder.DropTable(
                name: "TblMahasiswa");

            migrationBuilder.DropTable(
                name: "TblKegiatan");
        }
    }
}
