using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Todo.Api.Migrations
{
    public partial class BoardRecordBinding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Records",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Records_BoardId",
                table: "Records",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Boards_BoardId",
                table: "Records",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Boards_BoardId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_BoardId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Records");
        }
    }
}
