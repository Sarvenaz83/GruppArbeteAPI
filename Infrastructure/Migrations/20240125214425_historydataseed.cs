using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class historydataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("6c4eafc4-797c-49cb-a8ba-c3702633b422"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("c0b367a6-6588-4da2-b473-08731d33a0f8"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("c1c580b5-d6ad-4c0f-90ff-2cc5bafb16bf"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("50909fcf-a4cd-4b73-8602-98aade2664f7"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("57bd1733-05df-46f5-9d3b-49251d868728"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("9a88c366-d1d5-4337-82e8-b9ec92026488"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("4a92eace-2617-41fc-a0a9-b172d2b9ce1b"), "Alan Rickman" },
                    { new Guid("606addb3-ebc1-4fb8-a902-5493e5ae41c6"), "J.K Rowling" },
                    { new Guid("e147e1a6-b60e-4c04-97f2-26795172d75b"), "Stephen King" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("18611a64-b37e-45b9-9352-14fc647a190e"), new Guid("606addb3-ebc1-4fb8-a902-5493e5ae41c6"), "Action", 250, new DateTime(2024, 1, 25, 21, 44, 25, 806, DateTimeKind.Utc).AddTicks(2500), 4.5m, 10, "Action packed book", "Book 1" },
                    { new Guid("1922e155-3d48-4ccf-9551-7729be3fa6db"), new Guid("4a92eace-2617-41fc-a0a9-b172d2b9ce1b"), "Comedy", 300, new DateTime(2024, 1, 25, 21, 44, 25, 806, DateTimeKind.Utc).AddTicks(2510), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("4ee4744c-7b08-49eb-9b19-9b9c0997352c"), new Guid("e147e1a6-b60e-4c04-97f2-26795172d75b"), "Drama", 180, new DateTime(2024, 1, 25, 21, 44, 25, 806, DateTimeKind.Utc).AddTicks(2520), 4.8m, 10, "So much drama", "Book 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("18611a64-b37e-45b9-9352-14fc647a190e"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("1922e155-3d48-4ccf-9551-7729be3fa6db"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("4ee4744c-7b08-49eb-9b19-9b9c0997352c"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("4a92eace-2617-41fc-a0a9-b172d2b9ce1b"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("606addb3-ebc1-4fb8-a902-5493e5ae41c6"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("e147e1a6-b60e-4c04-97f2-26795172d75b"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("50909fcf-a4cd-4b73-8602-98aade2664f7"), "Alan Rickman" },
                    { new Guid("57bd1733-05df-46f5-9d3b-49251d868728"), "Stephen King" },
                    { new Guid("9a88c366-d1d5-4337-82e8-b9ec92026488"), "J.K Rowling" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("6c4eafc4-797c-49cb-a8ba-c3702633b422"), new Guid("50909fcf-a4cd-4b73-8602-98aade2664f7"), "Comedy", 300, new DateTime(2024, 1, 23, 18, 29, 51, 581, DateTimeKind.Utc).AddTicks(4609), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("c0b367a6-6588-4da2-b473-08731d33a0f8"), new Guid("57bd1733-05df-46f5-9d3b-49251d868728"), "Drama", 180, new DateTime(2024, 1, 23, 18, 29, 51, 581, DateTimeKind.Utc).AddTicks(4612), 4.8m, 10, "So much drama", "Book 3" },
                    { new Guid("c1c580b5-d6ad-4c0f-90ff-2cc5bafb16bf"), new Guid("9a88c366-d1d5-4337-82e8-b9ec92026488"), "Action", 250, new DateTime(2024, 1, 23, 18, 29, 51, 581, DateTimeKind.Utc).AddTicks(4603), 4.5m, 10, "Action packed book", "Book 1" }
                });
        }
    }
}
