using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tandem.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveConcatEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicGroupStudents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicGroupStudents",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGroupStudents", x => new { x.GroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_AcademicGroupStudents_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicGroupStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroupStudents_GroupId",
                table: "AcademicGroupStudents",
                column: "GroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroupStudents_StudentId",
                table: "AcademicGroupStudents",
                column: "StudentId",
                unique: true);
        }
    }
}
