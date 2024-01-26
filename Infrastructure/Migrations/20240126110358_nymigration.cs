using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nymigration : Migration
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
                    purchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    timeOfPurchase = table.Column<DateTime>(type: "datetime", nullable: true),
                    totalPrice = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__purchase__0261226C79359CBF", x => x.purchaseId);
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
                name: "purchaseDetail",
                columns: table => new
                {
                    purchaseDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    purchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    bookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    pricePerUnit = table.Column<int>(type: "int", nullable: true),
                    dateDetail = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__purchase__FA43B55BADA17CED", x => x.purchaseDetailId);
                    table.ForeignKey(
                        name: "FK__purchaseD__bookI__440B1D61",
                        column: x => x.bookId,
                        principalTable: "book",
                        principalColumn: "bookId");
                    table.ForeignKey(
                        name: "FK__purchaseD__purch__4316F928",
                        column: x => x.purchaseId,
                        principalTable: "purchaseHistory",
                        principalColumn: "purchaseId");
                });

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("1f343d63-5c4e-4511-b508-67d1c6818b51"), "Alan Rickman" },
                    { new Guid("5d20c294-2030-4d77-9b6f-1221bfd23227"), "J.K Rowling" },
                    { new Guid("f530419d-0b27-4489-8208-a8be911fc1a1"), "Stephen King" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "role", "surName", "telephoneNumber", "userName" },
                values: new object[] { new Guid("b7a78e4c-f291-46c1-839e-c952d3e868ae"), null, null, null, null, null, null, "AnvändareTestKöphistorik" });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("ed14e82c-a956-4c10-b216-6781b6355b9b"), new Guid("f530419d-0b27-4489-8208-a8be911fc1a1"), "Drama", 180, new DateTime(2024, 1, 26, 11, 3, 58, 445, DateTimeKind.Utc).AddTicks(9500), 4.8m, 10, "So much drama", "Book 3" },
                    { new Guid("fed16c45-3260-48de-b3ac-84da5273ad1b"), new Guid("1f343d63-5c4e-4511-b508-67d1c6818b51"), "Comedy", 300, new DateTime(2024, 1, 26, 11, 3, 58, 445, DateTimeKind.Utc).AddTicks(9500), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("ff07ea44-75bf-4c0a-8285-d0ee81107810"), new Guid("5d20c294-2030-4d77-9b6f-1221bfd23227"), "Action", 250, new DateTime(2024, 1, 26, 11, 3, 58, 445, DateTimeKind.Utc).AddTicks(9480), 4.5m, 10, "Action packed book", "Book 1" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("653226f6-841e-4056-b532-dd654bbc9d23"), new DateTime(2024, 1, 26, 11, 3, 58, 445, DateTimeKind.Utc).AddTicks(9540), 30, new Guid("b7a78e4c-f291-46c1-839e-c952d3e868ae") },
                    { new Guid("dce57bf2-d244-41ef-88e6-b8bed87657dc"), new DateTime(2024, 1, 26, 11, 3, 58, 445, DateTimeKind.Utc).AddTicks(9530), 50, new Guid("b7a78e4c-f291-46c1-839e-c952d3e868ae") },
                    { new Guid("ee820222-04c5-4812-a9cb-67d756fe9832"), new DateTime(2024, 1, 26, 11, 3, 58, 445, DateTimeKind.Utc).AddTicks(9540), 25, new Guid("b7a78e4c-f291-46c1-839e-c952d3e868ae") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_authorId",
                table: "book",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseDetail_bookId",
                table: "purchaseDetail",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseDetail_purchaseId",
                table: "purchaseDetail",
                column: "purchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseHistory_userId",
                table: "purchaseHistory",
                column: "userId");

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
                name: "purchaseDetail");

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
