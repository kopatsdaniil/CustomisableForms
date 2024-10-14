using System;
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
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Topic_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Custom_string1_state = table.Column<bool>(type: "bit", nullable: false),
                    Custom_string1_question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_string1_answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_string2_state = table.Column<bool>(type: "bit", nullable: false),
                    Custom_string2_question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_string2_answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_string3_state = table.Column<bool>(type: "bit", nullable: false),
                    Custom_string3_question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_string3_answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_string4_state = table.Column<bool>(type: "bit", nullable: false),
                    Custom_string4_question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_string4_answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_int1_state = table.Column<bool>(type: "bit", nullable: false),
                    Custom_int1_question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_int1_answer = table.Column<int>(type: "int", nullable: false),
                    Custom_int2_state = table.Column<bool>(type: "bit", nullable: false),
                    Custom_int2_question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_int2_answer = table.Column<int>(type: "int", nullable: false),
                    Custom_int3_state = table.Column<bool>(type: "bit", nullable: false),
                    Custom_int3_question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_int3_answer = table.Column<int>(type: "int", nullable: false),
                    Custom_int4_state = table.Column<bool>(type: "bit", nullable: false),
                    Custom_int4_question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custom_int4_answer = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_ApplicationUserId",
                table: "Forms",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
