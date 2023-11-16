using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainApp.Migrations
{
    /// <inheritdoc />
    public partial class _changekas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataKas_DataAkun_AkunId",
                table: "DataKas");

            migrationBuilder.AlterColumn<int>(
                name: "AkunId",
                table: "DataKas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tanggal",
                table: "DataKas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DataKas_DataAkun_AkunId",
                table: "DataKas",
                column: "AkunId",
                principalTable: "DataAkun",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataKas_DataAkun_AkunId",
                table: "DataKas");

            migrationBuilder.DropColumn(
                name: "Tanggal",
                table: "DataKas");

            migrationBuilder.AlterColumn<int>(
                name: "AkunId",
                table: "DataKas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DataKas_DataAkun_AkunId",
                table: "DataKas",
                column: "AkunId",
                principalTable: "DataAkun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
