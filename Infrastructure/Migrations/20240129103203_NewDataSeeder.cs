using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    authorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    authorName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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
                    summary = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "wallet",
                columns: table => new
                {
                    walletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    balance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__wallet__3785C8706E62B1A8", x => x.walletId);
                    table.ForeignKey(
                        name: "FK_wallet_user_UserId",
                        column: x => x.UserId,
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
                        name: "FK__purchaseD__bookI__440B1D61",
                        column: x => x.bookId,
                        principalTable: "book",
                        principalColumn: "bookId");
                    table.ForeignKey(
                        name: "FK__purchaseD__purch__4316F928",
                        column: x => x.purchaseHistoryId,
                        principalTable: "purchaseHistory",
                        principalColumn: "purchaseHistoryId");
                });

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("65ed2138-1f8c-4276-9225-675534783390"), "Alan Rickman" },
                    { new Guid("6c423d32-d22b-4f5f-88d3-db2a361e6a90"), "Stephen King" },
                    { new Guid("72e04cc7-4583-4227-903e-34035e85b563"), "J.K Rowling" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "role", "surName", "telephoneNumber", "userName" },
                values: new object[,]
                {
                    { new Guid("10686e1f-c1d7-42a8-b001-ab1b2acdf861"), null, null, "$2a$11$LW3uTLqSuTzxdKaQPKq4eOqfr/gnlBzMEKY0AOOMw0wI9L2772r/e", null, null, null, "admin" },
                    { new Guid("330574ee-d3bd-4e48-8936-955494b58449"), null, null, null, null, null, null, "AnvändareTestKöphistorik" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("3e8878ff-a4bf-4132-8701-065a6de4f54c"), new Guid("6c423d32-d22b-4f5f-88d3-db2a361e6a90"), "Drama", 180, new DateTime(2024, 1, 29, 10, 32, 3, 334, DateTimeKind.Utc).AddTicks(4713), 4.8m, 10, "So much drama", "Book 3" },
                    { new Guid("445cefb8-5e95-4be1-b4b7-b4d8564884ac"), new Guid("65ed2138-1f8c-4276-9225-675534783390"), "Comedy", 300, new DateTime(2024, 1, 29, 10, 32, 3, 334, DateTimeKind.Utc).AddTicks(4710), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("c8e9c2cb-64d5-444c-ad81-3fbbe4506102"), new Guid("72e04cc7-4583-4227-903e-34035e85b563"), "Action", 250, new DateTime(2024, 1, 29, 10, 32, 3, 334, DateTimeKind.Utc).AddTicks(4699), 4.5m, 10, "Action packed book", "Book 1" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("4a2e0a73-86d8-4b72-9b9d-b7572b211943"), new DateTime(2024, 1, 29, 10, 32, 3, 650, DateTimeKind.Utc).AddTicks(8873), 50, new Guid("330574ee-d3bd-4e48-8936-955494b58449") },
                    { new Guid("93fc911d-fae3-4627-976f-b3319565042d"), new DateTime(2024, 1, 29, 10, 32, 3, 650, DateTimeKind.Utc).AddTicks(8876), 30, new Guid("330574ee-d3bd-4e48-8936-955494b58449") },
                    { new Guid("c954a4e4-6c8d-4870-92e4-ac176f0bd679"), new DateTime(2024, 1, 29, 10, 32, 3, 650, DateTimeKind.Utc).AddTicks(8878), 25, new Guid("330574ee-d3bd-4e48-8936-955494b58449") }
                });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "pricePerUnit", "purchaseHistoryId", "quantity" },
                values: new object[,]
                {
                    { new Guid("20081bb9-7279-42de-80f7-97f6b18f6556"), new Guid("c8e9c2cb-64d5-444c-ad81-3fbbe4506102"), new DateTime(2024, 1, 29, 10, 32, 3, 650, DateTimeKind.Utc).AddTicks(8947), 100, new Guid("4a2e0a73-86d8-4b72-9b9d-b7572b211943"), 2 },
                    { new Guid("6c3759b0-e8f6-45f1-990a-b4b0ec5e675b"), new Guid("3e8878ff-a4bf-4132-8701-065a6de4f54c"), new DateTime(2024, 1, 29, 10, 32, 3, 650, DateTimeKind.Utc).AddTicks(8952), 80, new Guid("c954a4e4-6c8d-4870-92e4-ac176f0bd679"), 3 },
                    { new Guid("8a526480-7853-4429-a646-38e17466a9f4"), new Guid("445cefb8-5e95-4be1-b4b7-b4d8564884ac"), new DateTime(2024, 1, 29, 10, 32, 3, 650, DateTimeKind.Utc).AddTicks(8950), 150, new Guid("93fc911d-fae3-4627-976f-b3319565042d"), 1 }
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
                name: "IX_Receipt_bookId",
                table: "Receipt",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_purchaseHistoryId",
                table: "Receipt",
                column: "purchaseHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_UserId",
                table: "wallet",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "wallet");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "purchaseHistory");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
