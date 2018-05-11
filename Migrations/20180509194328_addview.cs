using Microsoft.EntityFrameworkCore.Migrations;

namespace PublicationsTracker.Migrations
{
    public partial class addview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                 .Sql(@"CREATE VIEW View_AuthorArticleCounts AS
                        SELECT
                            a.AuthorName,
                            Count(r.ArticleId) as ArticleCount
                        from Authors a
                            JOIN Articles r on r.AuthorId = a.AuthorId
                        GROUP BY a.AuthorName");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                 .Sql("DROP VIEW View_AuthorArticleCounts");
        }
    }
}
