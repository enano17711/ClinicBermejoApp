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
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Orders",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "DetailOrders",
                newName: "Cost");

            migrationBuilder.AddColumn<Guid>(
                name: "NoteId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TotalQuantity",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "DetailOrders",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAllotment",
                table: "DetailOrders",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AddColumn<long>(
                name: "SingleUnits",
                table: "DetailOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "DetailOrders",
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
                name: "IX_Orders_NoteId",
                table: "Orders",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOrders_UnitId",
                table: "DetailOrders",
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
                name: "FK_DetailOrders_Units_UnitId",
                table: "DetailOrders",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Note_NoteId",
                table: "Orders",
                column: "NoteId",
                principalTable: "Note",
                principalColumn: "NoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailOrders_Units_UnitId",
                table: "DetailOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Note_NoteId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ItemUnit");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Orders_NoteId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_DetailOrders_UnitId",
                table: "DetailOrders");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SingleUnits",
                table: "DetailOrders");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "DetailOrders");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "Orders",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "DetailOrders",
                newName: "Amount");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Orders",
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
                table: "DetailOrders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "IsAllotment",
                table: "DetailOrders",
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
