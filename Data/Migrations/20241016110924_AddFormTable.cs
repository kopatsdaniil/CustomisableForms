using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomisableForms.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFormTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Form_AspNetUsers_ApplicationUserId",
                table: "Form");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Form",
                table: "Form");

            migrationBuilder.RenameTable(
                name: "Form",
                newName: "Forms");

            migrationBuilder.RenameIndex(
                name: "IX_Form_ApplicationUserId",
                table: "Forms",
                newName: "IX_Forms_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forms",
                table: "Forms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_AspNetUsers_ApplicationUserId",
                table: "Forms",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_AspNetUsers_ApplicationUserId",
                table: "Forms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forms",
                table: "Forms");

            migrationBuilder.RenameTable(
                name: "Forms",
                newName: "Form");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_ApplicationUserId",
                table: "Form",
                newName: "IX_Form_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Form",
                table: "Form",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Form_AspNetUsers_ApplicationUserId",
                table: "Form",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
