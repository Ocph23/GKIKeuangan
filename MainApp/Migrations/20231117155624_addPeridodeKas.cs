using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MainApp.Migrations
{
    /// <inheritdoc />
    public partial class addPeridodeKas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Penerimaan = table.Column<double>(type: "double precision", nullable: false),
                    Pengeluaran = table.Column<double>(type: "double precision", nullable: false),
                    PemegangKas = table.Column<string>(type: "text", nullable: false),
                    TanggalPenutupan = table.Column<DateOnly>(type: "date", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_PeriodeKas_PeriodeId",
                table: "PeriodeKas",
                column: "PeriodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodeKas");
        }
    }
}
