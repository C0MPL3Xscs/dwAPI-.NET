using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DW3.Data.Migrations
{
    /// <inheritdoc />
    public partial class tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Participants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UsersId",
                table: "Participants",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UsersId",
                table: "Events",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UsersId",
                table: "Events",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Users_UsersId",
                table: "Participants",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UsersId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Users_UsersId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_UsersId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Events_UsersId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Events");
        }
    }
}
