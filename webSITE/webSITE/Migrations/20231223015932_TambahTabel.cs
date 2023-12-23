using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webSITE.Migrations
{
    /// <inheritdoc />
    public partial class TambahTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TblFoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanggal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKegiatan = table.Column<int>(type: "int", nullable: true),
                    KegiatanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblFoto_TblKegiatan_KegiatanId",
                        column: x => x.KegiatanId,
                        principalTable: "TblKegiatan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblPesertaKegiatan",
                columns: table => new
                {
                    IdMahasiswa = table.Column<int>(type: "int", nullable: false),
                    IdKegiatan = table.Column<int>(type: "int", nullable: false),
                    KegiatanId = table.Column<int>(type: "int", nullable: true),
                    MahasiswaId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_TblPesertaKegiatan_TblKegiatan_KegiatanId",
                        column: x => x.KegiatanId,
                        principalTable: "TblKegiatan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblPesertaKegiatan_TblMahasiswa_IdMahasiswa",
                        column: x => x.IdMahasiswa,
                        principalTable: "TblMahasiswa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblPesertaKegiatan_TblMahasiswa_MahasiswaId",
                        column: x => x.MahasiswaId,
                        principalTable: "TblMahasiswa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblMahasiswaFoto",
                columns: table => new
                {
                    IdMahasiswa = table.Column<int>(type: "int", nullable: false),
                    IdFoto = table.Column<int>(type: "int", nullable: false),
                    FotoId = table.Column<int>(type: "int", nullable: true),
                    MahasiswaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMahasiswaFoto", x => new { x.IdFoto, x.IdMahasiswa });
                    table.ForeignKey(
                        name: "FK_TblMahasiswaFoto_TblFoto_FotoId",
                        column: x => x.FotoId,
                        principalTable: "TblFoto",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_TblMahasiswaFoto_TblMahasiswa_MahasiswaId",
                        column: x => x.MahasiswaId,
                        principalTable: "TblMahasiswa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblFoto_KegiatanId",
                table: "TblFoto",
                column: "KegiatanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMahasiswaFoto_FotoId",
                table: "TblMahasiswaFoto",
                column: "FotoId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMahasiswaFoto_IdMahasiswa",
                table: "TblMahasiswaFoto",
                column: "IdMahasiswa");

            migrationBuilder.CreateIndex(
                name: "IX_TblMahasiswaFoto_MahasiswaId",
                table: "TblMahasiswaFoto",
                column: "MahasiswaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPesertaKegiatan_IdMahasiswa",
                table: "TblPesertaKegiatan",
                column: "IdMahasiswa");

            migrationBuilder.CreateIndex(
                name: "IX_TblPesertaKegiatan_KegiatanId",
                table: "TblPesertaKegiatan",
                column: "KegiatanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPesertaKegiatan_MahasiswaId",
                table: "TblPesertaKegiatan",
                column: "MahasiswaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblMahasiswaFoto");

            migrationBuilder.DropTable(
                name: "TblPesertaKegiatan");

            migrationBuilder.DropTable(
                name: "TblFoto");

            migrationBuilder.DropTable(
                name: "TblKegiatan");
        }
    }
}
