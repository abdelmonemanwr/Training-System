using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainning_System.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trainee",
                columns: new[] { "Id", "Address", "DepartmentId", "Grade", "Image", "Name" },
                values: new object[] { 4, "Chanzelizah", 1, "3", "man1.png", "Ahmed" });

            migrationBuilder.InsertData(
                table: "CrsResult",
                columns: new[] { "Id", "CourseId", "Degree", "TraineeId" },
                values: new object[] { 4, 1, 55, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CrsResult",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
