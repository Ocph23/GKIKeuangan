﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainApp.Migrations
{
    /// <inheritdoc />
    public partial class changeAkun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Jemaat",
                table: "DataAkun",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Klasis",
                table: "DataAkun",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sinode",
                table: "DataAkun",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "YPK",
                table: "DataAkun",
                type: "boolean",
                nullable: false,
                defaultValue: false);
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