using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PublicationsTracker.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[] { 1, "Julie Lerman" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[] { 2, "Andrew Marantz" });

            migrationBuilder.InsertData(
                table: "Magazines",
                columns: new[] { "MagazineId", "Name", "Publisher" },
                values: new object[] { 1, "MSDN Magazine", null });

            migrationBuilder.InsertData(
                table: "Magazines",
                columns: new[] { "MagazineId", "Name", "Publisher" },
                values: new object[] { 2, "New Yorker", null });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "AuthorId", "MagazineId", "PublishDate", "Title" },
                values: new object[] { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EF Core 2.1 Query Types" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "AuthorId", "MagazineId", "PublishDate", "Title" },
                values: new object[] { 2, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creating Azure Functions That Can Read from Cosmos DB with Almost No Code" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "AuthorId", "MagazineId", "PublishDate", "Title" },
                values: new object[] { 3, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reddit and the Struggle to Detoxify the Internet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Magazines",
                keyColumn: "MagazineId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Magazines",
                keyColumn: "MagazineId",
                keyValue: 1);
        }
    }
}
