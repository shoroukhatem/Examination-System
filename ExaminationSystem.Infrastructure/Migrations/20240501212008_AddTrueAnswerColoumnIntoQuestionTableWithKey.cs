using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.Infrastructure.Migrations
{
    public partial class AddTrueAnswerColoumnIntoQuestionTableWithKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_Questions_True",
                table: "Questions",
                column: "True",
                unique: true,
                filter: "[True] IS NOT NULL");


            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_True",
                table: "Questions",
                column: "True",
                principalTable: "Answers",
                principalColumn: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_True",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_True",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId1",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
