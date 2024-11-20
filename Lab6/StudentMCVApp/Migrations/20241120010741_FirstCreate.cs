using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentMCVApp.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoursesMCV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Department = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Lecturer = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesMCV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsMCV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsMCV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentCourse_CoursesMCV_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "CoursesMCV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_StudentsMCV_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "StudentsMCV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CoursesMCV",
                columns: new[] { "Id", "Department", "Lecturer", "Name" },
                values: new object[,]
                {
                    { 1, "Mathematics", "Dr. Skibidi", "Mathematics" },
                    { 2, "Physics", "Dr. Pimp", "Physics" }
                });

            migrationBuilder.InsertData(
                table: "StudentsMCV",
                columns: new[] { "Id", "Age", "EmailAddress", "Name" },
                values: new object[,]
                {
                    { 1, 20, "alice@gmail.com", "Blood Johnson" },
                    { 2, 22, "bob@gmail.com", "Crip Smith" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourse",
                columns: new[] { "CoursesId", "StudentsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentsId",
                table: "StudentCourse",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "CoursesMCV");

            migrationBuilder.DropTable(
                name: "StudentsMCV");
        }
    }
}
