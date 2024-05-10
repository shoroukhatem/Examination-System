using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.Infrastructure.Migrations
{
    public partial class refactorQuestionClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_True",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "True",
                table: "Questions",
                newName: "TrueAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_True",
                table: "Questions",
                newName: "IX_Questions_TrueAnswer");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_TrueAnswer",
                table: "Questions",
                column: "TrueAnswer",
                principalTable: "Answers",
                principalColumn: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_TrueAnswer",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "TrueAnswer",
                table: "Questions",
                newName: "True");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TrueAnswer",
                table: "Questions",
                newName: "IX_Questions_True");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_True",
                table: "Questions",
                column: "True",
                principalTable: "Answers",
                principalColumn: "AnswerId");
        }
    }
}
