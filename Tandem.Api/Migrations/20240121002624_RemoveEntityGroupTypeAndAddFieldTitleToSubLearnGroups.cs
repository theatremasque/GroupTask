using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tandem.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEntityGroupTypeAndAddFieldTitleToSubLearnGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTypes");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "SubGroups",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "LearnGroups",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "SubGroups");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "LearnGroups");

            migrationBuilder.CreateTable(
                name: "GroupTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTypes", x => x.Id);
                });
        }
    }
}
