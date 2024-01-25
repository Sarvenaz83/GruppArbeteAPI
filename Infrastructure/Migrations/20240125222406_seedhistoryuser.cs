using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedhistoryuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("27d187f5-3a35-4034-8138-5c01267ffb93"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("53e45d3e-432c-4550-858a-fcdcfae82c6e"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("648a0c59-5c55-41c9-bad3-d38a68b6769b"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseId",
                keyValue: new Guid("d1c205e0-e925-4049-b36c-888830a35c65"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseId",
                keyValue: new Guid("d88c692a-eee5-4edb-9a27-7609f4e4e615"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseId",
                keyValue: new Guid("f35a54f5-851e-4ee3-940e-0c307a115e62"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("1d8f0514-fa58-4417-87a5-03b502dc9e80"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("3dd37599-2ea1-451b-ae5c-5982e9e5e7e4"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("446214bd-4421-4eab-8088-21c155d763cf"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userId",
                keyValue: new Guid("ff1a6f62-b349-45ff-9130-daba06433e0a"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("25bd5268-7c70-4058-8adf-aaf4e9d9aa90"), "Alan Rickman" },
                    { new Guid("773ad32e-2a68-4257-943b-94b4ccc5dab3"), "J.K Rowling" },
                    { new Guid("bbdc7451-d1c3-42c5-a98b-f7c9e43aa52c"), "Stephen King" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "role", "surName", "telephoneNumber", "userName" },
                values: new object[] { new Guid("54dd5e23-9b89-4bf2-a919-775c2031a970"), null, null, null, null, null, null, "AnvändareTestKöphistorik" });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("42c78120-745d-473f-a8f7-0400f1402d33"), new Guid("25bd5268-7c70-4058-8adf-aaf4e9d9aa90"), "Comedy", 300, new DateTime(2024, 1, 25, 22, 24, 6, 392, DateTimeKind.Utc).AddTicks(4270), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("6b3ba0cb-e922-41be-8145-d4ca5b076c65"), new Guid("773ad32e-2a68-4257-943b-94b4ccc5dab3"), "Action", 250, new DateTime(2024, 1, 25, 22, 24, 6, 392, DateTimeKind.Utc).AddTicks(4250), 4.5m, 10, "Action packed book", "Book 1" },
                    { new Guid("d3895962-12e4-4ecf-95da-197a6554627f"), new Guid("bbdc7451-d1c3-42c5-a98b-f7c9e43aa52c"), "Drama", 180, new DateTime(2024, 1, 25, 22, 24, 6, 392, DateTimeKind.Utc).AddTicks(4270), 4.8m, 10, "So much drama", "Book 3" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("5aedcc2a-759a-4747-b5be-16c151c52f17"), new DateTime(2024, 1, 25, 22, 24, 6, 392, DateTimeKind.Utc).AddTicks(4310), 25, new Guid("54dd5e23-9b89-4bf2-a919-775c2031a970") },
                    { new Guid("8905da42-cf52-40f2-b327-6ebb17d7caa8"), new DateTime(2024, 1, 25, 22, 24, 6, 392, DateTimeKind.Utc).AddTicks(4310), 30, new Guid("54dd5e23-9b89-4bf2-a919-775c2031a970") },
                    { new Guid("9029dfdd-4952-4a02-a369-6f190deb02cf"), new DateTime(2024, 1, 25, 22, 24, 6, 392, DateTimeKind.Utc).AddTicks(4300), 50, new Guid("54dd5e23-9b89-4bf2-a919-775c2031a970") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("42c78120-745d-473f-a8f7-0400f1402d33"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("6b3ba0cb-e922-41be-8145-d4ca5b076c65"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("d3895962-12e4-4ecf-95da-197a6554627f"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseId",
                keyValue: new Guid("5aedcc2a-759a-4747-b5be-16c151c52f17"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseId",
                keyValue: new Guid("8905da42-cf52-40f2-b327-6ebb17d7caa8"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseId",
                keyValue: new Guid("9029dfdd-4952-4a02-a369-6f190deb02cf"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("25bd5268-7c70-4058-8adf-aaf4e9d9aa90"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("773ad32e-2a68-4257-943b-94b4ccc5dab3"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("bbdc7451-d1c3-42c5-a98b-f7c9e43aa52c"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userId",
                keyValue: new Guid("54dd5e23-9b89-4bf2-a919-775c2031a970"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("1d8f0514-fa58-4417-87a5-03b502dc9e80"), "Alan Rickman" },
                    { new Guid("3dd37599-2ea1-451b-ae5c-5982e9e5e7e4"), "Stephen King" },
                    { new Guid("446214bd-4421-4eab-8088-21c155d763cf"), "J.K Rowling" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "role", "surName", "telephoneNumber", "userName" },
                values: new object[] { new Guid("ff1a6f62-b349-45ff-9130-daba06433e0a"), null, null, null, null, null, null, "AnvändareTestKöphistorik" });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("27d187f5-3a35-4034-8138-5c01267ffb93"), new Guid("446214bd-4421-4eab-8088-21c155d763cf"), "Action", 250, new DateTime(2024, 1, 25, 22, 17, 27, 775, DateTimeKind.Utc).AddTicks(790), 4.5m, 10, "Action packed book", "Book 1" },
                    { new Guid("53e45d3e-432c-4550-858a-fcdcfae82c6e"), new Guid("3dd37599-2ea1-451b-ae5c-5982e9e5e7e4"), "Drama", 180, new DateTime(2024, 1, 25, 22, 17, 27, 775, DateTimeKind.Utc).AddTicks(810), 4.8m, 10, "So much drama", "Book 3" },
                    { new Guid("648a0c59-5c55-41c9-bad3-d38a68b6769b"), new Guid("1d8f0514-fa58-4417-87a5-03b502dc9e80"), "Comedy", 300, new DateTime(2024, 1, 25, 22, 17, 27, 775, DateTimeKind.Utc).AddTicks(810), 3.7m, 20, "Very funny book", "Book 2" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("d1c205e0-e925-4049-b36c-888830a35c65"), new DateTime(2024, 1, 25, 22, 17, 27, 775, DateTimeKind.Utc).AddTicks(850), 25, new Guid("ff1a6f62-b349-45ff-9130-daba06433e0a") },
                    { new Guid("d88c692a-eee5-4edb-9a27-7609f4e4e615"), new DateTime(2024, 1, 25, 22, 17, 27, 775, DateTimeKind.Utc).AddTicks(840), 50, new Guid("ff1a6f62-b349-45ff-9130-daba06433e0a") },
                    { new Guid("f35a54f5-851e-4ee3-940e-0c307a115e62"), new DateTime(2024, 1, 25, 22, 17, 27, 775, DateTimeKind.Utc).AddTicks(840), 30, new Guid("ff1a6f62-b349-45ff-9130-daba06433e0a") }
                });
        }
    }
}
