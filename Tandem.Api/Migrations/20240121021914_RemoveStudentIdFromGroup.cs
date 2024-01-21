using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tandem.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStudentIdFromGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Students_StudentId",
                table: "Groups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Groups",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
