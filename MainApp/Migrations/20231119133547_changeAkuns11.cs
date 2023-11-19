using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainApp.Migrations
{
    /// <inheritdoc />
    public partial class changeAkuns11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Jemaat",
                table: "DataAkun",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Klasis",
                table: "DataAkun",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Sinode",
                table: "DataAkun",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "YPK",
                table: "DataAkun",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jemaat",
                table: "DataAkun");

            migrationBuilder.DropColumn(
                name: "Klasis",
                table: "DataAkun");

            migrationBuilder.DropColumn(
                name: "Sinode",
                table: "DataAkun");

            migrationBuilder.DropColumn(
                name: "YPK",
                table: "DataAkun");
        }
    }
}
