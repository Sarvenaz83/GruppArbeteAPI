using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CJsmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    authorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    authorName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__author__8E2731B93441940C", x => x.authorId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    role = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    telephoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    surName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user__CB9A1CFF7FE751DC", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    bookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    authorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    genre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pubYear = table.Column<DateTime>(type: "datetime", nullable: true),
                    pages = table.Column<int>(type: "int", nullable: true),
                    stockBalance = table.Column<int>(type: "int", nullable: true),
                    rating = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__book__8BE5A10DE068B40D", x => x.bookId);
                    table.ForeignKey(
                        name: "FK__book__authorId__4222D4EF",
                        column: x => x.authorId,
                        principalTable: "author",
                        principalColumn: "authorId");
                });

            migrationBuilder.CreateTable(
                name: "purchaseHistory",
                columns: table => new
                {
                    purchaseHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    timeOfPurchase = table.Column<DateTime>(type: "datetime", nullable: true),
                    totalPrice = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__purchase__0261226C79359CBF", x => x.purchaseHistoryId);
                    table.ForeignKey(
                        name: "FK__purchaseH__userI__412EB0B6",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wallet",
                columns: table => new
                {
                    walletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    balance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__wallet__3785C8706E62B1A8", x => x.walletId);
                    table.ForeignKey(
                        name: "FK_wallet_user_userId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    purchaseHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    bookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    pricePerUnit = table.Column<int>(type: "int", nullable: true),
                    dateDetail = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__purchase__FA43B55BADA17CED", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK__purchaseD__purch__4316F928",
                        column: x => x.purchaseHistoryId,
                        principalTable: "purchaseHistory",
                        principalColumn: "purchaseHistoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("61e2434a-b042-4712-865e-025de2031f9d"), "Stephen King" },
                    { new Guid("7293f967-720a-4d9d-89d8-900e8c71238a"), "J.K Rowling" },
                    { new Guid("7ac1c2cf-b35e-4b11-bf54-8b081d53d0d2"), "Alan Rickman" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "role", "surName", "telephoneNumber", "userName" },
                values: new object[,]
                {
                    { new Guid("43cc2f6d-eea3-4224-b85f-ac2bc2d4b6dc"), null, null, null, null, null, null, "AnvändareTestKöphistorik" },
                    { new Guid("f191ecec-26b5-480c-9a0e-3a0f9b4cbda0"), null, null, "$2a$11$zcjgqmz5S9rKT/9YjT9nCOO5tkkTTFaq6asFWbugGJR7OsrUdiswW", null, null, null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("14d16312-570f-4c8b-94be-b8546edae5d5"), new Guid("7293f967-720a-4d9d-89d8-900e8c71238a"), "Action", 250, new DateTime(2024, 1, 29, 19, 20, 36, 359, DateTimeKind.Utc).AddTicks(8730), 4.5m, 10, "Action packed book", "Book 1" },
                    { new Guid("718f005d-447e-4c98-9a87-c52d027f4920"), new Guid("7ac1c2cf-b35e-4b11-bf54-8b081d53d0d2"), "Comedy", 300, new DateTime(2024, 1, 29, 19, 20, 36, 359, DateTimeKind.Utc).AddTicks(8740), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("c64c28b5-bc14-4195-8be9-f9e191e0972b"), new Guid("61e2434a-b042-4712-865e-025de2031f9d"), "Drama", 180, new DateTime(2024, 1, 29, 19, 20, 36, 359, DateTimeKind.Utc).AddTicks(8750), 4.8m, 10, "So much drama", "Book 3" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("2e600004-281d-44ec-b7f6-b34efe0b2771"), new DateTime(2024, 1, 29, 19, 20, 36, 501, DateTimeKind.Utc).AddTicks(4430), 25, new Guid("43cc2f6d-eea3-4224-b85f-ac2bc2d4b6dc") },
                    { new Guid("9234a6d7-7b5b-4006-ab31-17a962f3decf"), new DateTime(2024, 1, 29, 19, 20, 36, 501, DateTimeKind.Utc).AddTicks(4430), 50, new Guid("43cc2f6d-eea3-4224-b85f-ac2bc2d4b6dc") },
                    { new Guid("ff0eeb52-b9f0-41c5-9340-ab359ef27f4d"), new DateTime(2024, 1, 29, 19, 20, 36, 501, DateTimeKind.Utc).AddTicks(4430), 30, new Guid("43cc2f6d-eea3-4224-b85f-ac2bc2d4b6dc") }
                });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "pricePerUnit", "purchaseHistoryId", "quantity" },
                values: new object[,]
                {
                    { new Guid("60c3292b-7796-4803-84cc-dc4d7a9deabc"), new Guid("718f005d-447e-4c98-9a87-c52d027f4920"), new DateTime(2024, 1, 29, 19, 20, 36, 501, DateTimeKind.Utc).AddTicks(4490), 150, new Guid("ff0eeb52-b9f0-41c5-9340-ab359ef27f4d"), 1 },
                    { new Guid("85653093-38c3-4681-8bd0-990ac0375a62"), new Guid("14d16312-570f-4c8b-94be-b8546edae5d5"), new DateTime(2024, 1, 29, 19, 20, 36, 501, DateTimeKind.Utc).AddTicks(4490), 100, new Guid("9234a6d7-7b5b-4006-ab31-17a962f3decf"), 2 },
                    { new Guid("962b895c-98af-4602-9c25-dacda0d670ee"), new Guid("c64c28b5-bc14-4195-8be9-f9e191e0972b"), new DateTime(2024, 1, 29, 19, 20, 36, 501, DateTimeKind.Utc).AddTicks(4490), 80, new Guid("2e600004-281d-44ec-b7f6-b34efe0b2771"), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_authorId",
                table: "book",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseHistory_userId",
                table: "purchaseHistory",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_purchaseHistoryId",
                table: "Receipt",
                column: "purchaseHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_userId",
                table: "wallet",
                column: "userId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "wallet");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "purchaseHistory");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
