using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAuthor : Migration
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
                        name: "FK_Receipt_book_bookId",
                        column: x => x.bookId,
                        principalTable: "book",
                        principalColumn: "bookId");
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
                    { new Guid("28fcabdd-44ef-47f2-ac09-d96e955990c4"), "J.K Rowling" },
                    { new Guid("419809c8-1e5b-4a9a-b795-e1a49c32add1"), "Stephen King" },
                    { new Guid("be406e3e-922a-4bc7-a2af-0f539ee4658a"), "Alan Rickman" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "role", "surName", "telephoneNumber", "userName" },
                values: new object[] { new Guid("95719511-516c-4ae7-b270-cb03d1f1d018"), null, null, null, null, null, null, "AnvändareTestKöphistorik" });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("2739dcb3-33b4-4736-a40c-4cb13a04177a"), new Guid("28fcabdd-44ef-47f2-ac09-d96e955990c4"), "Action", 250, new DateTime(2024, 1, 29, 15, 44, 23, 576, DateTimeKind.Utc).AddTicks(4115), 4.5m, 10, "Action packed book", "Book 1" },
                    { new Guid("64e615ca-e052-47b2-a26d-6d98d63a27f8"), new Guid("419809c8-1e5b-4a9a-b795-e1a49c32add1"), "Drama", 180, new DateTime(2024, 1, 29, 15, 44, 23, 576, DateTimeKind.Utc).AddTicks(4124), 4.8m, 10, "So much drama", "Book 3" },
                    { new Guid("cd7dc22b-5710-4713-b8ae-fc78358f5a6e"), new Guid("be406e3e-922a-4bc7-a2af-0f539ee4658a"), "Comedy", 300, new DateTime(2024, 1, 29, 15, 44, 23, 576, DateTimeKind.Utc).AddTicks(4122), 3.7m, 20, "Very funny book", "Book 2" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("31db8645-1463-4c2b-bf8c-7fe3afe16479"), new DateTime(2024, 1, 29, 15, 44, 23, 576, DateTimeKind.Utc).AddTicks(4182), 30, new Guid("95719511-516c-4ae7-b270-cb03d1f1d018") },
                    { new Guid("6bc02deb-f4c6-4b21-ab5f-38d6660d6c01"), new DateTime(2024, 1, 29, 15, 44, 23, 576, DateTimeKind.Utc).AddTicks(4181), 50, new Guid("95719511-516c-4ae7-b270-cb03d1f1d018") },
                    { new Guid("a0438ac8-ee5e-4065-91cd-43eb5eabfb61"), new DateTime(2024, 1, 29, 15, 44, 23, 576, DateTimeKind.Utc).AddTicks(4183), 25, new Guid("95719511-516c-4ae7-b270-cb03d1f1d018") }
                });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "pricePerUnit", "purchaseHistoryId", "quantity" },
                values: new object[,]
                {
                    { new Guid("149cb5f2-fdf1-4536-a45c-091987317f32"), new Guid("64e615ca-e052-47b2-a26d-6d98d63a27f8"), new DateTime(2024, 1, 29, 15, 44, 23, 576, DateTimeKind.Utc).AddTicks(4207), 80, new Guid("a0438ac8-ee5e-4065-91cd-43eb5eabfb61"), 3 },
                    { new Guid("1fe707be-2bd9-4989-afe9-1791b77c7e25"), new Guid("cd7dc22b-5710-4713-b8ae-fc78358f5a6e"), new DateTime(2024, 1, 29, 15, 44, 23, 576, DateTimeKind.Utc).AddTicks(4206), 150, new Guid("31db8645-1463-4c2b-bf8c-7fe3afe16479"), 1 },
                    { new Guid("46676ea5-1eb9-48e2-96bc-12b04f010ba2"), new Guid("2739dcb3-33b4-4736-a40c-4cb13a04177a"), new DateTime(2024, 1, 29, 15, 44, 23, 576, DateTimeKind.Utc).AddTicks(4204), 100, new Guid("6bc02deb-f4c6-4b21-ab5f-38d6660d6c01"), 2 }
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
                name: "IX_wallet_userId",
                table: "wallet",
                column: "userId",
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
