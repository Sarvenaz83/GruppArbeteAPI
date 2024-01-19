using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDataForAuthorAndBooks1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("2554a123-bccc-47b2-99e9-8f9b9cddac19"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("5d7f532e-c2e6-4940-b785-4d63e652fffb"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("edb42178-5bd8-405d-8e23-9a2c0c204064"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("9c672a17-e142-47a5-ae8c-87f8d00eab14"), "Stephen King" },
                    { new Guid("a71ab6b4-2160-4636-bafc-46c52bbffc7a"), "Alan Rickman" },
                    { new Guid("c034d429-4334-45fc-82f2-084033a89a39"), "J.K Rowling" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("28b605c5-d993-4dd1-b2dd-8b0aa855fe59"), new Guid("a71ab6b4-2160-4636-bafc-46c52bbffc7a"), "Comedy", 300, new DateTime(2024, 1, 18, 23, 24, 30, 362, DateTimeKind.Utc).AddTicks(8524), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("c78a1102-37e3-43f4-b0ed-572121807cd9"), new Guid("c034d429-4334-45fc-82f2-084033a89a39"), "Action", 250, new DateTime(2024, 1, 18, 23, 24, 30, 362, DateTimeKind.Utc).AddTicks(8511), 4.5m, 10, "Action packed book", "Book 1" },
                    { new Guid("ca441b71-c04c-4e01-b344-62077099b959"), new Guid("9c672a17-e142-47a5-ae8c-87f8d00eab14"), "Drama", 180, new DateTime(2024, 1, 18, 23, 24, 30, 362, DateTimeKind.Utc).AddTicks(8543), 4.8m, 10, "So much drama", "Book 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("28b605c5-d993-4dd1-b2dd-8b0aa855fe59"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("c78a1102-37e3-43f4-b0ed-572121807cd9"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("ca441b71-c04c-4e01-b344-62077099b959"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("9c672a17-e142-47a5-ae8c-87f8d00eab14"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("a71ab6b4-2160-4636-bafc-46c52bbffc7a"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("c034d429-4334-45fc-82f2-084033a89a39"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("2554a123-bccc-47b2-99e9-8f9b9cddac19"), "Alan Rickman" },
                    { new Guid("5d7f532e-c2e6-4940-b785-4d63e652fffb"), "J.K Rowling" },
                    { new Guid("edb42178-5bd8-405d-8e23-9a2c0c204064"), "Stephen King" }
                });
        }
    }
}
