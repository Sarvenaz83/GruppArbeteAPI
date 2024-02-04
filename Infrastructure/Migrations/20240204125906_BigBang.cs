using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BigBang : Migration
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
                    rating = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ArticleNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    balance = table.Column<int>(type: "int", nullable: false)
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
                    dateDetail = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("41e93619-05f1-413c-9588-ff2dfe95221f"), "J.K. Rowling" },
                    { new Guid("886d0538-55c1-487e-9398-fc103dd11a30"), "J.R.R. Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "surName", "telephoneNumber", "userName" },
                values: new object[,]
                {
                    { new Guid("05e68985-2d18-4494-aa8b-bd4ab12b5189"), "admin@gmail.com", "Admin", "$2a$11$eWFQgoswLFuduCQyAkvB7On6fqSnUt2HPQytVdeBUAkuMHJrkwzRS", "Admin", "+4671111111", "admin" },
                    { new Guid("76f5c4b8-44bc-4960-95c3-3ef7cf0fa7ad"), "mail@gmail.com", "Test", "$2a$11$dua06X9uY3zf6HR53nhvjeUEL.Ahf5DMrYqeT3r4J1VzVFF6fYeea", "Test", "+467000000", "AnvändareTest" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "ArticleNumber", "authorId", "genre", "pages", "Price", "pubYear", "rating", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("62250928-48b6-42e2-97ff-81ea87d6f8ec"), "7cab7825-64ac-464b-94f3-b78b157e9ee8", new Guid("41e93619-05f1-413c-9588-ff2dfe95221f"), "Fantasy", 223, 20, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, "A young wizard starts his journey.", "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("d9fb6c0c-a672-45f3-9944-46f52d12a0c9"), "525db669-137b-4e65-bece-f49198480dff", new Guid("886d0538-55c1-487e-9398-fc103dd11a30"), "Fantasy", 310, 15, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.7m, "A hobbit's adventure.", "The Hobbit" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "userId" },
                values: new object[] { new Guid("b011d3af-fdec-4646-a307-a5d3350d8dec"), new Guid("76f5c4b8-44bc-4960-95c3-3ef7cf0fa7ad") });

            migrationBuilder.InsertData(
                table: "wallet",
                columns: new[] { "walletId", "balance", "userId" },
                values: new object[] { new Guid("d78b503c-2267-4b1e-9749-5ce39dd15ab9"), 100, new Guid("76f5c4b8-44bc-4960-95c3-3ef7cf0fa7ad") });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "purchaseHistoryId", "quantity", "TotalPrice" },
                values: new object[] { new Guid("b55e6f94-a8f1-4a5f-b609-2bb9fea7896e"), new Guid("62250928-48b6-42e2-97ff-81ea87d6f8ec"), new DateTime(2024, 2, 4, 12, 59, 6, 130, DateTimeKind.Utc).AddTicks(9866), new Guid("b011d3af-fdec-4646-a307-a5d3350d8dec"), 1, 0 });

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
