using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trainning_System.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CourseId", "Image", "Name", "salary" },
                values: new object[] { "Hunter X Hunter", 3, "man2.jpeg", "Gon Freecs", 50000 });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Hunter X Hunter");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CourseId", "DepartmentId", "Image", "Name", "salary" },
                values: new object[] { "Hunter X Hunter", 1, 2, "girl.jpeg", "Pitou", 20000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CourseId", "Image", "Name", "salary" },
                values: new object[] { "HunterXHunter", 1, "girl.jpeg", "Pitou", 20000 });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "HunterXHunter");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CourseId", "DepartmentId", "Image", "Name", "salary" },
                values: new object[] { "HunterXHunter", 3, 1, "man2.jpeg", "Gon Freecs", 50000 });
        }
    }
}
