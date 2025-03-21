using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfItTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateUniqueDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_Number",
                table: "Students",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonCode",
                table: "Lessons",
                column: "LessonCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Number",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_LessonCode",
                table: "Lessons");
        }
    }
}
