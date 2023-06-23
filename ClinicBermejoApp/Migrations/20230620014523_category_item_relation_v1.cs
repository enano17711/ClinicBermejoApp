using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBermejoApp.Migrations
{
    /// <inheritdoc />
    public partial class category_item_relation_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_CategoryItems_CategoryItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryItemId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CategoryItemId",
                table: "CategoryItems",
                newName: "CategoryId");

            migrationBuilder.CreateTable(
                name: "CategoryItemMNs",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItemMNs", x => new { x.CategoryItemId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CategoryItemMNs_CategoryItems_CategoryItemId",
                        column: x => x.CategoryItemId,
                        principalTable: "CategoryItems",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItemMNs_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItemMNs_ItemId",
                table: "CategoryItemMNs",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryItemMNs");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryItems",
                newName: "CategoryItemId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryItemId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryItemId",
                table: "Items",
                column: "CategoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_CategoryItems_CategoryItemId",
                table: "Items",
                column: "CategoryItemId",
                principalTable: "CategoryItems",
                principalColumn: "CategoryItemId");
        }
    }
}
