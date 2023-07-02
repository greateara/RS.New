using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agama",
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
                    table.PrimaryKey("PK_Agama", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Bio = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bahasa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Kode = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bahasa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Kode = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Golongan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Kode = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    UraianGolongan = table.Column<string>(type: "TEXT", nullable: true),
                    UraianPangkat = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Golongan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jabatan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Kode = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jabatan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Display = table.Column<string>(type: "TEXT", nullable: true),
                    Definition = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Negara",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negara", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    SaveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Display = table.Column<string>(type: "TEXT", nullable: true),
                    Definition = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pendidikan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pendidikan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pendidikan1",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pendidikan1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perkawinan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perkawinan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suku",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suku", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProvinceId = table.Column<int>(type: "INTEGER", nullable: false),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    DistrictId = table.Column<int>(type: "INTEGER", nullable: false),
                    VillageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Definition = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    SaveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SSOrganizationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SSClientID = table.Column<Guid>(type: "TEXT", nullable: false),
                    SSClientSecret = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrgName = table.Column<string>(type: "TEXT", nullable: true),
                    Parent = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrgTypeID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Org", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Org_OrgType_OrgTypeID",
                        column: x => x.OrgTypeID,
                        principalTable: "OrgType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pendidikan2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pendidikan2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pendidikan2_Pendidikan1_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Pendidikan1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Mode = table.Column<string>(type: "TEXT", nullable: true),
                    OrgId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LocationTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ZoneId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_LocationType_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_Org_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Org",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pendidikan3",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    Uraian = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pendidikan3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pendidikan3_Pendidikan2_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Pendidikan2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pegawai",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<int>(type: "INTEGER", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Nama = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    TmpLahir = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    TglLahir = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Alamat = table.Column<string>(type: "TEXT", nullable: true),
                    Tlp = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    TlgMasuk = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PictFile = table.Column<string>(type: "TEXT", nullable: true),
                    IsFakasi = table.Column<int>(type: "INTEGER", nullable: false),
                    LeaderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AgamaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BahasaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GenderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GolonganId = table.Column<Guid>(type: "TEXT", nullable: false),
                    JabatanId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NegaraId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PendidikanId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pendidikan3Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PerkawinanId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SukuId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ZoneId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegawai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pegawai_Agama_AgamaId",
                        column: x => x.AgamaId,
                        principalTable: "Agama",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegawai_Bahasa_BahasaId",
                        column: x => x.BahasaId,
                        principalTable: "Bahasa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegawai_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegawai_Golongan_GolonganId",
                        column: x => x.GolonganId,
                        principalTable: "Golongan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegawai_Jabatan_JabatanId",
                        column: x => x.JabatanId,
                        principalTable: "Jabatan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegawai_Negara_NegaraId",
                        column: x => x.NegaraId,
                        principalTable: "Negara",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegawai_Pendidikan3_Pendidikan3Id",
                        column: x => x.Pendidikan3Id,
                        principalTable: "Pendidikan3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegawai_Pendidikan_PendidikanId",
                        column: x => x.PendidikanId,
                        principalTable: "Pendidikan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegawai_Perkawinan_PerkawinanId",
                        column: x => x.PerkawinanId,
                        principalTable: "Perkawinan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegawai_Suku_SukuId",
                        column: x => x.SukuId,
                        principalTable: "Suku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pegawai_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationTypeId",
                table: "Location",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_OrgId",
                table: "Location",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ZoneId",
                table: "Location",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Org_OrgTypeID",
                table: "Org",
                column: "OrgTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_AgamaId",
                table: "Pegawai",
                column: "AgamaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_BahasaId",
                table: "Pegawai",
                column: "BahasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_GenderId",
                table: "Pegawai",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_GolonganId",
                table: "Pegawai",
                column: "GolonganId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_JabatanId",
                table: "Pegawai",
                column: "JabatanId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_NegaraId",
                table: "Pegawai",
                column: "NegaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_Pendidikan3Id",
                table: "Pegawai",
                column: "Pendidikan3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_PendidikanId",
                table: "Pegawai",
                column: "PendidikanId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_PerkawinanId",
                table: "Pegawai",
                column: "PerkawinanId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_SukuId",
                table: "Pegawai",
                column: "SukuId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_ZoneId",
                table: "Pegawai",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Pendidikan2_ParentId",
                table: "Pendidikan2",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pendidikan3_ParentId",
                table: "Pendidikan3",
                column: "ParentId");
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
                name: "Location");

            migrationBuilder.DropTable(
                name: "Pegawai");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LocationType");

            migrationBuilder.DropTable(
                name: "Org");

            migrationBuilder.DropTable(
                name: "Agama");

            migrationBuilder.DropTable(
                name: "Bahasa");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Golongan");

            migrationBuilder.DropTable(
                name: "Jabatan");

            migrationBuilder.DropTable(
                name: "Negara");

            migrationBuilder.DropTable(
                name: "Pendidikan3");

            migrationBuilder.DropTable(
                name: "Pendidikan");

            migrationBuilder.DropTable(
                name: "Perkawinan");

            migrationBuilder.DropTable(
                name: "Suku");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "OrgType");

            migrationBuilder.DropTable(
                name: "Pendidikan2");

            migrationBuilder.DropTable(
                name: "Pendidikan1");
        }
    }
}
