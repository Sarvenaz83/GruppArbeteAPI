using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Namings : Migration
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
                    { new Guid("048c1636-4cfd-4dc8-bd29-8e3326db8c07"), "Alan Rickman" },
                    { new Guid("4553d538-afa6-419e-b385-058a76177fd1"), "Stephen King" },
                    { new Guid("534d41c8-e176-4a14-af49-656aa13922c0"), "J.K Rowling" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "role", "surName", "telephoneNumber", "userName" },
                values: new object[] { new Guid("30e6d5b1-eee9-4d50-93f7-6e8ee36b1b4a"), null, null, null, null, null, null, "AnvändareTestKöphistorik" });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("5e084454-9e07-4f75-b0f1-13aefdd91180"), new Guid("534d41c8-e176-4a14-af49-656aa13922c0"), "Action", 250, new DateTime(2024, 1, 26, 16, 47, 0, 59, DateTimeKind.Utc).AddTicks(2867), 4.5m, 10, "Action packed book", "Book 1" },
                    { new Guid("b195c337-a4cc-49f5-b075-cffe9faeac44"), new Guid("048c1636-4cfd-4dc8-bd29-8e3326db8c07"), "Comedy", 300, new DateTime(2024, 1, 26, 16, 47, 0, 59, DateTimeKind.Utc).AddTicks(2873), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("e76e9cf6-c59c-444c-bffb-fa0276c7d9c4"), new Guid("4553d538-afa6-419e-b385-058a76177fd1"), "Drama", 180, new DateTime(2024, 1, 26, 16, 47, 0, 59, DateTimeKind.Utc).AddTicks(2876), 4.8m, 10, "So much drama", "Book 3" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("0847551c-49a5-4dcd-8bc4-0f1f09b2b824"), new DateTime(2024, 1, 26, 16, 47, 0, 59, DateTimeKind.Utc).AddTicks(2928), 30, new Guid("30e6d5b1-eee9-4d50-93f7-6e8ee36b1b4a") },
                    { new Guid("23166c5e-8805-4126-9f3c-716e0b6509cd"), new DateTime(2024, 1, 26, 16, 47, 0, 59, DateTimeKind.Utc).AddTicks(2927), 50, new Guid("30e6d5b1-eee9-4d50-93f7-6e8ee36b1b4a") },
                    { new Guid("38ddf893-d431-414f-a633-4bb2f465f3a2"), new DateTime(2024, 1, 26, 16, 47, 0, 59, DateTimeKind.Utc).AddTicks(2929), 25, new Guid("30e6d5b1-eee9-4d50-93f7-6e8ee36b1b4a") }
                });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "pricePerUnit", "purchaseHistoryId", "quantity" },
                values: new object[,]
                {
                    { new Guid("27ae00d4-421d-4e9e-a8cd-4dc0c38f566e"), new Guid("5e084454-9e07-4f75-b0f1-13aefdd91180"), new DateTime(2024, 1, 26, 16, 47, 0, 59, DateTimeKind.Utc).AddTicks(2946), 100, new Guid("23166c5e-8805-4126-9f3c-716e0b6509cd"), 2 },
                    { new Guid("2f67be43-d96d-4a1e-af3d-0d5c09f36ad8"), new Guid("b195c337-a4cc-49f5-b075-cffe9faeac44"), new DateTime(2024, 1, 26, 16, 47, 0, 59, DateTimeKind.Utc).AddTicks(2949), 150, new Guid("0847551c-49a5-4dcd-8bc4-0f1f09b2b824"), 1 },
                    { new Guid("717c735d-b8d1-4db9-82ce-a5d8b0c9288a"), new Guid("e76e9cf6-c59c-444c-bffb-fa0276c7d9c4"), new DateTime(2024, 1, 26, 16, 47, 0, 59, DateTimeKind.Utc).AddTicks(2950), 80, new Guid("38ddf893-d431-414f-a633-4bb2f465f3a2"), 3 }
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
