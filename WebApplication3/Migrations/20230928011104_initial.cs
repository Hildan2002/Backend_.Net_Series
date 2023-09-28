using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokter",
                columns: table => new
                {
                    DokterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaDokter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokter", x => x.DokterId);
                });

            migrationBuilder.CreateTable(
                name: "Pasien",
                columns: table => new
                {
                    PasienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoRM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Agama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pekerjaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusAsKes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusKawin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamaPenanggungJawab = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GolonganDarah = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiwayatPenyakit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlergiObat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeadaanKeluar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaraKeluar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DokterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasien", x => x.PasienId);
                    table.ForeignKey(
                        name: "FK_Pasien_Dokter_DokterId",
                        column: x => x.DokterId,
                        principalTable: "Dokter",
                        principalColumn: "DokterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pasien_DokterId",
                table: "Pasien",
                column: "DokterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pasien");

            migrationBuilder.DropTable(
                name: "Dokter");
        }
    }
}
