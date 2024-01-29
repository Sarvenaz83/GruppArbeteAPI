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
                    { new Guid("64789fec-9300-4280-8e92-914896c7b100"), "Stephen King" },
                    { new Guid("9d2d656b-d9eb-42d8-9766-9f73419497a5"), "J.K Rowling" },
                    { new Guid("d8282806-a11f-42d5-b448-c6f89895022d"), "Alan Rickman" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "role", "surName", "telephoneNumber", "userName" },
                values: new object[,]
                {
                    { new Guid("4fc7901e-972d-47aa-995d-7db3a231a939"), null, null, "$2a$11$0GALVlCcgctE8p1u0RqZQetzmOJncF/TrL7TyMAnZ8k7UHbd1WmG.", null, null, null, "admin" },
                    { new Guid("e33dc758-e89e-4e66-9d95-b5035151421a"), null, null, null, null, null, null, "AnvändareTestKöphistorik" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("89fdd5ff-038c-4a5e-93e0-6592c647a9ec"), new Guid("64789fec-9300-4280-8e92-914896c7b100"), "Drama", 180, new DateTime(2024, 1, 29, 18, 38, 56, 97, DateTimeKind.Utc).AddTicks(9295), 4.8m, 10, "So much drama", "Book 3" },
                    { new Guid("d2f787b4-8f05-4bfb-940e-d6f79e9e5de6"), new Guid("9d2d656b-d9eb-42d8-9766-9f73419497a5"), "Action", 250, new DateTime(2024, 1, 29, 18, 38, 56, 97, DateTimeKind.Utc).AddTicks(9284), 4.5m, 10, "Action packed book", "Book 1" },
                    { new Guid("efe571e9-5753-48c2-8154-f58eb9a1dd24"), new Guid("d8282806-a11f-42d5-b448-c6f89895022d"), "Comedy", 300, new DateTime(2024, 1, 29, 18, 38, 56, 97, DateTimeKind.Utc).AddTicks(9292), 3.7m, 20, "Very funny book", "Book 2" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("1f3d6ee1-e8a9-474b-93af-817ffc090114"), new DateTime(2024, 1, 29, 18, 38, 56, 227, DateTimeKind.Utc).AddTicks(3294), 30, new Guid("e33dc758-e89e-4e66-9d95-b5035151421a") },
                    { new Guid("b7659a18-2c0e-46f4-af5c-0d03ed898814"), new DateTime(2024, 1, 29, 18, 38, 56, 227, DateTimeKind.Utc).AddTicks(3295), 25, new Guid("e33dc758-e89e-4e66-9d95-b5035151421a") },
                    { new Guid("c0ab523f-3dc4-4f69-a7e9-0b418f37da53"), new DateTime(2024, 1, 29, 18, 38, 56, 227, DateTimeKind.Utc).AddTicks(3291), 50, new Guid("e33dc758-e89e-4e66-9d95-b5035151421a") }
                });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "pricePerUnit", "purchaseHistoryId", "quantity" },
                values: new object[,]
                {
                    { new Guid("0d98838f-0ec5-4a03-9ff1-67c10aa90fc4"), new Guid("d2f787b4-8f05-4bfb-940e-d6f79e9e5de6"), new DateTime(2024, 1, 29, 18, 38, 56, 227, DateTimeKind.Utc).AddTicks(3383), 100, new Guid("c0ab523f-3dc4-4f69-a7e9-0b418f37da53"), 2 },
                    { new Guid("a197e0a5-737e-4702-9d6d-0bf59ea4c0d2"), new Guid("89fdd5ff-038c-4a5e-93e0-6592c647a9ec"), new DateTime(2024, 1, 29, 18, 38, 56, 227, DateTimeKind.Utc).AddTicks(3389), 80, new Guid("b7659a18-2c0e-46f4-af5c-0d03ed898814"), 3 },
                    { new Guid("d1f903ae-0187-4ad9-9dc7-67e5882c552e"), new Guid("efe571e9-5753-48c2-8154-f58eb9a1dd24"), new DateTime(2024, 1, 29, 18, 38, 56, 227, DateTimeKind.Utc).AddTicks(3387), 150, new Guid("1f3d6ee1-e8a9-474b-93af-817ffc090114"), 1 }
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
