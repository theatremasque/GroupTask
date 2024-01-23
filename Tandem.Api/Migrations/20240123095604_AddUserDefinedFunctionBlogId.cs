using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tandem.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDefinedFunctionBlogId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql(@"CREATE OR REPLACE FUNCTION
                                        ""test_db_defined-func""
                                            .public
                                            .CommentedPostCountForBlog(id INT)
                                    RETURNS INT AS
                                        $$
                                            BEGIN
                                                RETURN (SELECT count(*)
                                                        FROM ""Post"" AS p
                                                        WHERE (p.""BlogId"" = id) AND
                                                        (SELECT count(*) FROM ""Comment"" as c WHERE p.""PostId"" = c.""PostId"") > 0);
                                            END;
                                        $$
                                        LANGUAGE plpgsql;"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DROP FUNCTION IF EXISTS ""test_db_defined-func"".public.CommentedPostCountForBlog(id INT);");
        }
    }
}
