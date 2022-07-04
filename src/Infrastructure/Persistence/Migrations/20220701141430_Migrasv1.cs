using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Persistence.Migrations
{
    public partial class Migrasv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JenisBahanBakar = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    JumlahTempatDuduk = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    KunciCadangan = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GaransiPabrik = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TanggalRegistrasi = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Warna = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    BukuServis = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MasaBerlakuStnk = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorikus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorikus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mobils",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Merk = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Lokasi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KategorikuId = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    DetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobils_Details_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobils_Kategorikus_KategorikuId",
                        column: x => x.KategorikuId,
                        principalTable: "Kategorikus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mobils_DetailId",
                table: "Mobils",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobils_KategorikuId",
                table: "Mobils",
                column: "KategorikuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Mobils");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Kategorikus");
        }
    }
}
