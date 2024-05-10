using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.Infrastructure.Migrations
{
    public partial class resolveAnswersRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_TrueAnswer",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TrueAnswer",
                table: "Questions",
                column: "TrueAnswer",
                unique: true,
                filter: "[TrueAnswer] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_TrueAnswer",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TrueAnswer",
                table: "Questions",
                column: "TrueAnswer");
        }
    }
}
