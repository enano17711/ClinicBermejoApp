using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBermejoApp.Migrations
{
    /// <inheritdoc />
    public partial class UnitTablesRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Units",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitBaseId",
                table: "Units",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Value",
                table: "Units",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "UnitBases",
                columns: table => new
                {
                    UnitBaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitBases", x => x.UnitBaseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitBaseId",
                table: "Units",
                column: "UnitBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_UnitBases_UnitBaseId",
                table: "Units",
                column: "UnitBaseId",
                principalTable: "UnitBases",
                principalColumn: "UnitBaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_UnitBases_UnitBaseId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "UnitBases");

            migrationBuilder.DropIndex(
                name: "IX_Units_UnitBaseId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Operation",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitBaseId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Units");
        }
    }
}
