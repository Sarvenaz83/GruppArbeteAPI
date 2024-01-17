using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("0d33df61-3dde-4cfd-8eed-b85eac5c75ca"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("8b59c137-3321-4c1c-bbcd-e8f3e27580c2"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("caa43f6b-2c2a-47a0-91e5-a6dcaf220114"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("44999686-6d05-4c11-8fd5-66782c06cc94"), "Author 3" },
                    { new Guid("4f993560-e778-40c3-866e-26f6cbd90cba"), "Author 2" },
                    { new Guid("61396f5c-08ad-46b1-83d1-7650af4b6014"), "Author 1" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("0912daee-dbd6-4da3-a5c8-f5f40c83ac22"), new Guid("4f993560-e778-40c3-866e-26f6cbd90cba"), "Comedy", 300, new DateTime(2024, 1, 16, 13, 22, 9, 86, DateTimeKind.Utc).AddTicks(3923), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("4941d293-6e62-4800-834b-c2982019888a"), new Guid("44999686-6d05-4c11-8fd5-66782c06cc94"), "Drama", 180, new DateTime(2024, 1, 16, 13, 22, 9, 86, DateTimeKind.Utc).AddTicks(3926), 4.8m, 10, "So much drama", "Book 3" },
                    { new Guid("9c441e12-7f93-4215-a82c-672748a2a5d5"), new Guid("61396f5c-08ad-46b1-83d1-7650af4b6014"), "Action", 250, new DateTime(2024, 1, 16, 13, 22, 9, 86, DateTimeKind.Utc).AddTicks(3914), 4.5m, 10, "Action packed book", "Book 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("0912daee-dbd6-4da3-a5c8-f5f40c83ac22"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("4941d293-6e62-4800-834b-c2982019888a"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("9c441e12-7f93-4215-a82c-672748a2a5d5"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("44999686-6d05-4c11-8fd5-66782c06cc94"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("4f993560-e778-40c3-866e-26f6cbd90cba"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("61396f5c-08ad-46b1-83d1-7650af4b6014"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("0d33df61-3dde-4cfd-8eed-b85eac5c75ca"), "James Patterson" },
                    { new Guid("8b59c137-3321-4c1c-bbcd-e8f3e27580c2"), "Stephen King" },
                    { new Guid("caa43f6b-2c2a-47a0-91e5-a6dcaf220114"), "J.K Rowling" }
                });
        }
    }
}
