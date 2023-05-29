using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBermejoApp.Migrations
{
    /// <inheritdoc />
    public partial class update_Unit_Item_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemUnit_Items_ItemId",
                table: "ItemUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemUnit_Units_UnitId",
                table: "ItemUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemUnit",
                table: "ItemUnit");

            migrationBuilder.DropIndex(
                name: "IX_ItemUnit_ItemId",
                table: "ItemUnit");

            migrationBuilder.DropIndex(
                name: "IX_ItemUnit_UnitId",
                table: "ItemUnit");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemUnit");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "ItemUnit");

            migrationBuilder.RenameColumn(
                name: "ItemUnitId",
                table: "ItemUnit",
                newName: "UnitsId");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemsId",
                table: "ItemUnit",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemUnit",
                table: "ItemUnit",
                columns: new[] { "ItemsId", "UnitsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnit_UnitsId",
                table: "ItemUnit",
                column: "UnitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemUnit_Items_ItemsId",
                table: "ItemUnit",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemUnit_Units_UnitsId",
                table: "ItemUnit",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemUnit_Items_ItemsId",
                table: "ItemUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemUnit_Units_UnitsId",
                table: "ItemUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemUnit",
                table: "ItemUnit");

            migrationBuilder.DropIndex(
                name: "IX_ItemUnit_UnitsId",
                table: "ItemUnit");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "ItemUnit");

            migrationBuilder.RenameColumn(
                name: "UnitsId",
                table: "ItemUnit",
                newName: "ItemUnitId");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "ItemUnit",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "ItemUnit",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemUnit",
                table: "ItemUnit",
                column: "ItemUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnit_ItemId",
                table: "ItemUnit",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnit_UnitId",
                table: "ItemUnit",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemUnit_Items_ItemId",
                table: "ItemUnit",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemUnit_Units_UnitId",
                table: "ItemUnit",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId");
        }
    }
}
