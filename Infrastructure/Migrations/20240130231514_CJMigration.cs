using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CJMigration : Migration
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
                    userName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    surName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    telephoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
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
                    { new Guid("3c74767c-b033-4b7e-aec0-292546123bf4"), "Stephen King" },
                    { new Guid("5b16858e-f785-467c-985d-2b676b050a5a"), "Alan Rickman" },
                    { new Guid("943c6ec8-31ee-45a9-877b-f323c63d7bb1"), "J.K Rowling" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "surName", "telephoneNumber", "userName" },
                values: new object[,]
                {
                    { new Guid("1e383c91-e7d0-46a6-a1da-3d2e424e4035"), "mail@gmail.com", "Test", "$2a$11$yU2QyA8m0GVeXZYQdK6StOU6zaTOobzJRe06lHXZ5GylnfQcq7wIu", "Test", "+467000000", "AnvändareTestKöphistorik" },
                    { new Guid("6190c409-ae89-4271-bb5e-0d5b9c704da9"), "admin@gmail.com", "Admin", "$2a$11$hRqDZrAirse7Gqamg1MXYu.gTCgVLWPX1CeR7tg6U73EGDzFz9Wna", "Admin", "+4671111111", "admin" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("0e8cf5ea-fbd8-49d9-8bb9-abd654f53961"), new Guid("3c74767c-b033-4b7e-aec0-292546123bf4"), "Drama", 180, new DateTime(2024, 1, 30, 23, 15, 13, 874, DateTimeKind.Utc).AddTicks(1950), 4.8m, 10, "So much drama", "Book 3" },
                    { new Guid("877d17b1-9b90-496e-a788-d47355349d0d"), new Guid("943c6ec8-31ee-45a9-877b-f323c63d7bb1"), "Action", 250, new DateTime(2024, 1, 30, 23, 15, 13, 874, DateTimeKind.Utc).AddTicks(1940), 4.5m, 10, "Action packed book", "Book 1" },
                    { new Guid("b1a048fb-5eda-416e-9516-90b1012f623b"), new Guid("5b16858e-f785-467c-985d-2b676b050a5a"), "Comedy", 300, new DateTime(2024, 1, 30, 23, 15, 13, 874, DateTimeKind.Utc).AddTicks(1950), 3.7m, 20, "Very funny book", "Book 2" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("06f7523a-32c2-461f-9d6b-4c3fa03564ca"), new DateTime(2024, 1, 30, 23, 15, 14, 155, DateTimeKind.Utc).AddTicks(5750), 50, new Guid("1e383c91-e7d0-46a6-a1da-3d2e424e4035") },
                    { new Guid("12365271-867c-4734-a649-30f3b235a60e"), new DateTime(2024, 1, 30, 23, 15, 14, 155, DateTimeKind.Utc).AddTicks(5750), 25, new Guid("1e383c91-e7d0-46a6-a1da-3d2e424e4035") },
                    { new Guid("7a2af17c-9401-49b9-b5b2-db1a35f53fc0"), new DateTime(2024, 1, 30, 23, 15, 14, 155, DateTimeKind.Utc).AddTicks(5750), 30, new Guid("1e383c91-e7d0-46a6-a1da-3d2e424e4035") }
                });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "pricePerUnit", "purchaseHistoryId", "quantity" },
                values: new object[,]
                {
                    { new Guid("1bfd0420-b766-4350-a554-08148d3bc4bb"), new Guid("877d17b1-9b90-496e-a788-d47355349d0d"), new DateTime(2024, 1, 30, 23, 15, 14, 155, DateTimeKind.Utc).AddTicks(5790), 100, new Guid("06f7523a-32c2-461f-9d6b-4c3fa03564ca"), 2 },
                    { new Guid("825f8366-3011-4de2-8de8-ceaa2d6f60c1"), new Guid("b1a048fb-5eda-416e-9516-90b1012f623b"), new DateTime(2024, 1, 30, 23, 15, 14, 155, DateTimeKind.Utc).AddTicks(5800), 150, new Guid("7a2af17c-9401-49b9-b5b2-db1a35f53fc0"), 1 },
                    { new Guid("f04da8ea-996a-4b65-b45e-7c1da972869f"), new Guid("0e8cf5ea-fbd8-49d9-8bb9-abd654f53961"), new DateTime(2024, 1, 30, 23, 15, 14, 155, DateTimeKind.Utc).AddTicks(5800), 80, new Guid("12365271-867c-4734-a649-30f3b235a60e"), 3 }
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
