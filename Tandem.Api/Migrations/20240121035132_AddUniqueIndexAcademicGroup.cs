﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tandem.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexAcademicGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AcademicGroups_GroupId_StudentId",
                table: "AcademicGroups");

            migrationBuilder.DropIndex(
                name: "IX_AcademicGroups_StudentId",
                table: "AcademicGroups");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroups_GroupId",
                table: "AcademicGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroups_StudentId",
                table: "AcademicGroups",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AcademicGroups_GroupId",
                table: "AcademicGroups");

            migrationBuilder.DropIndex(
                name: "IX_AcademicGroups_StudentId",
                table: "AcademicGroups");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroups_GroupId_StudentId",
                table: "AcademicGroups",
                columns: new[] { "GroupId", "StudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroups_StudentId",
                table: "AcademicGroups",
                column: "StudentId");
        }
    }
}
