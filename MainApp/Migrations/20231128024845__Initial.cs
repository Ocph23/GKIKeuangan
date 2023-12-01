using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MainApp.Migrations
{
    /// <inheritdoc />
    public partial class _Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataKategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kode = table.Column<string>(type: "text", nullable: true),
                    Nama = table.Column<string>(type: "text", nullable: true),
                    Deskripsi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataKategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataPeriode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tahun = table.Column<int>(type: "integer", nullable: false),
                    Catatan = table.Column<string>(type: "text", nullable: true),
                    UtangAkhir = table.Column<double>(type: "double precision", nullable: false),
                    SaldoAkhir = table.Column<double>(type: "double precision", nullable: false),
                    Aktif = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPeriode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "DataAkun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KategoriId = table.Column<int>(type: "integer", nullable: false),
                    Kode = table.Column<string>(type: "text", nullable: true),
                    Uraian = table.Column<string>(type: "text", nullable: true),
                    Tipe = table.Column<int>(type: "integer", nullable: false),
                    AlokasiProsentese = table.Column<bool>(type: "boolean", nullable: false),
                    SetoranWajib = table.Column<bool>(type: "boolean", nullable: false),
                    Jemaat = table.Column<double>(type: "double precision", nullable: false),
                    YPK = table.Column<double>(type: "double precision", nullable: false),
                    Klasis = table.Column<double>(type: "double precision", nullable: false),
                    Sinode = table.Column<double>(type: "double precision", nullable: false),
                    Keterangan = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataAkun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataAkun_DataKategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "DataKategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeriodeKas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bulan = table.Column<int>(type: "integer", nullable: false),
                    Mulai = table.Column<DateOnly>(type: "date", nullable: false),
                    Berakhir = table.Column<DateOnly>(type: "date", nullable: false),
                    PeriodeId = table.Column<int>(type: "integer", nullable: false),
                    SaldoLalu = table.Column<double>(type: "double precision", nullable: false),
                    UtangLalu = table.Column<double>(type: "double precision", nullable: false),
                    Penerimaan = table.Column<double>(type: "double precision", nullable: false),
                    Pengeluaran = table.Column<double>(type: "double precision", nullable: false),
                    PembayaranUtang = table.Column<double>(type: "double precision", nullable: false),
                    PemegangKas = table.Column<string>(type: "text", nullable: false),
                    TanggalPenutupan = table.Column<DateOnly>(type: "date", nullable: true),
                    Sinode = table.Column<double>(type: "double precision", nullable: false),
                    YPK = table.Column<double>(type: "double precision", nullable: false),
                    Klasis = table.Column<double>(type: "double precision", nullable: false),
                    Jemaat = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodeKas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodeKas_DataPeriode_PeriodeId",
                        column: x => x.PeriodeId,
                        principalTable: "DataPeriode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnggaranBelanjaItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AkunId = table.Column<int>(type: "integer", nullable: true),
                    Kegiatan = table.Column<int>(type: "integer", nullable: false),
                    Nilai = table.Column<double>(type: "double precision", nullable: false),
                    PeriodeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnggaranBelanjaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnggaranBelanjaItem_DataAkun_AkunId",
                        column: x => x.AkunId,
                        principalTable: "DataAkun",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnggaranBelanjaItem_DataPeriode_PeriodeId",
                        column: x => x.PeriodeId,
                        principalTable: "DataPeriode",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataKas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tanggal = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AkunId = table.Column<int>(type: "integer", nullable: true),
                    Jumlah = table.Column<double>(type: "double precision", nullable: false),
                    Catatan = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataKas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataKas_DataAkun_AkunId",
                        column: x => x.AkunId,
                        principalTable: "DataAkun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnggaranBelanjaItem_AkunId",
                table: "AnggaranBelanjaItem",
                column: "AkunId");

            migrationBuilder.CreateIndex(
                name: "IX_AnggaranBelanjaItem_PeriodeId",
                table: "AnggaranBelanjaItem",
                column: "PeriodeId");

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
                name: "IX_DataAkun_KategoriId",
                table: "DataAkun",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_DataAkun_Kode",
                table: "DataAkun",
                column: "Kode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataKas_AkunId",
                table: "DataKas",
                column: "AkunId");

            migrationBuilder.CreateIndex(
                name: "IX_DataKategori_Kode",
                table: "DataKategori",
                column: "Kode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataPeriode_Tahun",
                table: "DataPeriode",
                column: "Tahun",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeKas_PeriodeId",
                table: "PeriodeKas",
                column: "PeriodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnggaranBelanjaItem");

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
                name: "DataKas");

            migrationBuilder.DropTable(
                name: "PeriodeKas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DataAkun");

            migrationBuilder.DropTable(
                name: "DataPeriode");

            migrationBuilder.DropTable(
                name: "DataKategori");
        }
    }
}
