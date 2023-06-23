using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBermejoApp.Migrations
{
    /// <inheritdoc />
    public partial class modify_unit_relation_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemUnits_Items_ItemId",
                table: "ItemUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemUnits_Units_UnitId",
                table: "ItemUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemUnits",
                table: "ItemUnits");

            migrationBuilder.DropIndex(
                name: "IX_ItemUnits_ItemId",
                table: "ItemUnits");

            migrationBuilder.DropColumn(
                name: "ItemUnitId",
                table: "ItemUnits");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "ItemUnits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "ItemUnits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemUnits",
                table: "ItemUnits",
                columns: new[] { "ItemId", "UnitId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemUnits_Items_ItemId",
                table: "ItemUnits",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemUnits_Units_UnitId",
                table: "ItemUnits",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemUnits_Items_ItemId",
                table: "ItemUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemUnits_Units_UnitId",
                table: "ItemUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemUnits",
                table: "ItemUnits");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "ItemUnits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "ItemUnits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemUnitId",
                table: "ItemUnits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemUnits",
                table: "ItemUnits",
                column: "ItemUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnits_ItemId",
                table: "ItemUnits",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemUnits_Items_ItemId",
                table: "ItemUnits",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemUnits_Units_UnitId",
                table: "ItemUnits",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId");
        }
    }
}
