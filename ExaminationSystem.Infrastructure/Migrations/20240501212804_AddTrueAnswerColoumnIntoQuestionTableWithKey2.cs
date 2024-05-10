using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.Infrastructure.Migrations
{
    public partial class AddTrueAnswerColoumnIntoQuestionTableWithKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_True",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_True",
                table: "Questions",
                column: "True");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_True",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_True",
                table: "Questions",
                column: "True",
                unique: true,
                filter: "[True] IS NOT NULL");
        }
    }
}
