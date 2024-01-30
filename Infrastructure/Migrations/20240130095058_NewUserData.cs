using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUserData : Migration
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
                    { new Guid("32e9c59d-0d69-4159-a0d9-91578b54d474"), "J.K Rowling" },
                    { new Guid("3890aac1-f351-480b-9e4d-5752f24c4d16"), "Stephen King" },
                    { new Guid("cb4ebbcf-7487-435c-b974-739a3f481bc8"), "Alan Rickman" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "surName", "telephoneNumber", "userName" },
                values: new object[,]
                {
                    { new Guid("1c6e0aae-288f-43a6-b9f3-02d0022e8ce7"), "mail@gmail.com", "Test", "$2a$11$SCcBBo6ccw7PKisT1SuO4uNzi77QlZ8fM..3kiD5LUtflfJZQjW7i", "Test", "+467000000", "AnvändareTestKöphistorik" },
                    { new Guid("c5a6fcac-9ce9-4020-a161-9cb592271961"), "admin@gmail.com", "Admin", "$2a$11$zfAaby1spmLv.UHf03KhBu78O2k5cYhTQ21bn391FJ75HXVTmMw1y", "Admin", "+4671111111", "admin" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("257feffe-b2cc-4cc0-9cf7-a53121d90397"), new Guid("3890aac1-f351-480b-9e4d-5752f24c4d16"), "Drama", 180, new DateTime(2024, 1, 30, 9, 50, 57, 689, DateTimeKind.Utc).AddTicks(9283), 4.8m, 10, "So much drama", "Book 3" },
                    { new Guid("3875589a-8460-4636-8c16-cf48b868a28b"), new Guid("cb4ebbcf-7487-435c-b974-739a3f481bc8"), "Comedy", 300, new DateTime(2024, 1, 30, 9, 50, 57, 689, DateTimeKind.Utc).AddTicks(9280), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("94340251-2d40-469b-8fbb-d4a98edb9aeb"), new Guid("32e9c59d-0d69-4159-a0d9-91578b54d474"), "Action", 250, new DateTime(2024, 1, 30, 9, 50, 57, 689, DateTimeKind.Utc).AddTicks(9270), 4.5m, 10, "Action packed book", "Book 1" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("0b2c2d8f-d2b2-407a-a637-274ada85cf03"), new DateTime(2024, 1, 30, 9, 50, 57, 990, DateTimeKind.Utc).AddTicks(769), 25, new Guid("1c6e0aae-288f-43a6-b9f3-02d0022e8ce7") },
                    { new Guid("96a57f32-826a-4e3c-8152-08bd3b88c61d"), new DateTime(2024, 1, 30, 9, 50, 57, 990, DateTimeKind.Utc).AddTicks(765), 50, new Guid("1c6e0aae-288f-43a6-b9f3-02d0022e8ce7") },
                    { new Guid("9abeb42f-e422-44b4-8fb4-f1da6d3cb7a0"), new DateTime(2024, 1, 30, 9, 50, 57, 990, DateTimeKind.Utc).AddTicks(768), 30, new Guid("1c6e0aae-288f-43a6-b9f3-02d0022e8ce7") }
                });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "pricePerUnit", "purchaseHistoryId", "quantity" },
                values: new object[,]
                {
                    { new Guid("4c2956c0-b9e5-46d0-9ec0-27ed786157a0"), new Guid("3875589a-8460-4636-8c16-cf48b868a28b"), new DateTime(2024, 1, 30, 9, 50, 57, 990, DateTimeKind.Utc).AddTicks(935), 150, new Guid("9abeb42f-e422-44b4-8fb4-f1da6d3cb7a0"), 1 },
                    { new Guid("588077d0-a1c1-47a5-bc0a-c028909905f3"), new Guid("94340251-2d40-469b-8fbb-d4a98edb9aeb"), new DateTime(2024, 1, 30, 9, 50, 57, 990, DateTimeKind.Utc).AddTicks(932), 100, new Guid("96a57f32-826a-4e3c-8152-08bd3b88c61d"), 2 },
                    { new Guid("a1bf6238-36ed-425f-8629-deedcca506a7"), new Guid("257feffe-b2cc-4cc0-9cf7-a53121d90397"), new DateTime(2024, 1, 30, 9, 50, 57, 990, DateTimeKind.Utc).AddTicks(936), 80, new Guid("0b2c2d8f-d2b2-407a-a637-274ada85cf03"), 3 }
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
