using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainApp.Migrations
{
    /// <inheritdoc />
    public partial class alokasiinPeriodeKas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jemaat",
                table: "DataPeriode");

            migrationBuilder.DropColumn(
                name: "Klasis",
                table: "DataPeriode");

            migrationBuilder.DropColumn(
                name: "Sinode",
                table: "DataPeriode");

            migrationBuilder.DropColumn(
                name: "YPK",
                table: "DataPeriode");

            migrationBuilder.AddColumn<double>(
                name: "Jemaat",
                table: "PeriodeKas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Klasis",
                table: "PeriodeKas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Sinode",
                table: "PeriodeKas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "YPK",
                table: "PeriodeKas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jemaat",
                table: "PeriodeKas");

            migrationBuilder.DropColumn(
                name: "Klasis",
                table: "PeriodeKas");

            migrationBuilder.DropColumn(
                name: "Sinode",
                table: "PeriodeKas");

            migrationBuilder.DropColumn(
                name: "YPK",
                table: "PeriodeKas");

            migrationBuilder.AddColumn<double>(
                name: "Jemaat",
                table: "DataPeriode",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Klasis",
                table: "DataPeriode",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Sinode",
                table: "DataPeriode",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "YPK",
                table: "DataPeriode",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
