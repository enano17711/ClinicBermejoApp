using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBermejoApp.Migrations
{
    /// <inheritdoc />
    public partial class ModifyInventoryEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Units_UnitId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UnitId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Movements",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "DetailMovements",
                newName: "Cost");

            migrationBuilder.AddColumn<Guid>(
                name: "NoteId",
                table: "Movements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TotalQuantity",
                table: "Movements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "DetailMovements",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAllotment",
                table: "DetailMovements",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AddColumn<long>(
                name: "SingleUnits",
                table: "DetailMovements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "DetailMovements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemUnit",
                columns: table => new
                {
                    ItemUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemUnit", x => x.ItemUnitId);
                    table.ForeignKey(
                        name: "FK_ItemUnit_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_ItemUnit_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movements_NoteId",
                table: "Movements",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailMovements_UnitId",
                table: "DetailMovements",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnit_ItemId",
                table: "ItemUnit",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemUnit_UnitId",
                table: "ItemUnit",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailMovements_Units_UnitId",
                table: "DetailMovements",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Note_NoteId",
                table: "Movements",
                column: "NoteId",
                principalTable: "Note",
                principalColumn: "NoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailMovements_Units_UnitId",
                table: "DetailMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Note_NoteId",
                table: "Movements");

            migrationBuilder.DropTable(
                name: "ItemUnit");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Movements_NoteId",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_DetailMovements_UnitId",
                table: "DetailMovements");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "SingleUnits",
                table: "DetailMovements");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "DetailMovements");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "Movements",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "DetailMovements",
                newName: "Amount");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Movements",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "DetailMovements",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "IsAllotment",
                table: "DetailMovements",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UnitId",
                table: "Items",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Units_UnitId",
                table: "Items",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId");
        }
    }
}
