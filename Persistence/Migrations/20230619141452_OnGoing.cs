using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OnGoing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdCity",
                table: "Zone",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdDistrict",
                table: "Zone",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdVillage",
                table: "Zone",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Provinsi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Kode = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinsi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KabKota",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Kode = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KabKota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KabKota_Provinsi_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Provinsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kecamatan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Kode = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kecamatan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kecamatan_KabKota_ParentId",
                        column: x => x.ParentId,
                        principalTable: "KabKota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Desa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Kode = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desa_Kecamatan_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Kecamatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desa_ParentId",
                table: "Desa",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_KabKota_ParentId",
                table: "KabKota",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Kecamatan_ParentId",
                table: "Kecamatan",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desa");

            migrationBuilder.DropTable(
                name: "Kecamatan");

            migrationBuilder.DropTable(
                name: "KabKota");

            migrationBuilder.DropTable(
                name: "Provinsi");

            migrationBuilder.DropColumn(
                name: "IdCity",
                table: "Zone");

            migrationBuilder.DropColumn(
                name: "IdDistrict",
                table: "Zone");

            migrationBuilder.DropColumn(
                name: "IdVillage",
                table: "Zone");
        }
    }
}
