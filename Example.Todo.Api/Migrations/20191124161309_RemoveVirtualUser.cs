using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Todo.Api.Migrations
{
    public partial class RemoveVirtualUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Users_CreatorId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Users_CreatorId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_CreatorId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Boards_CreatorId",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Boards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boards_UserId",
                table: "Boards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Users_UserId",
                table: "Boards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Users_UserId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_UserId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Boards");

            migrationBuilder.CreateIndex(
                name: "IX_Records_CreatorId",
                table: "Records",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_CreatorId",
                table: "Boards",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Users_CreatorId",
                table: "Boards",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Users_CreatorId",
                table: "Records",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
