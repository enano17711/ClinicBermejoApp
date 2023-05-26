using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicBermejoApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNoteToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Note_NoteId",
                table: "Movements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Units",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Notes_NoteId",
                table: "Movements",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "NoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Notes_NoteId",
                table: "Movements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Units");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Note_NoteId",
                table: "Movements",
                column: "NoteId",
                principalTable: "Note",
                principalColumn: "NoteId");
        }
    }
}
