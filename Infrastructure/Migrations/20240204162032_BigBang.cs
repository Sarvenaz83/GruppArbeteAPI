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
                    { new Guid("1b518c09-2adb-4d4b-9ede-0a0a281622ec"), "J.R.R. Tolkien" },
                    { new Guid("a7360dc9-c342-414c-86fa-d0aaec810f6a"), "J.K. Rowling" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "surName", "telephoneNumber", "userName" },
                values: new object[,]
                {
                    { new Guid("a9f3ebe6-aa6b-44a7-8ad8-e4b8ca976a8d"), "mail@gmail.com", "Test", "$2a$11$eVVQ24B6BjuEuz9V7ipqwuPwAsv7svcf.QbabXLwdWOWa.ZfygxVC", "Test", "+467000000", "AnvändareTest" },
                    { new Guid("bf522b3a-800e-4c35-a310-36e899ac4c81"), "admin@gmail.com", "Admin", "$2a$11$oc5WzxSrx/uDjCGZ5o04nOYm61nzZD3Pu6e9SSLQFKAsgGjqbylPG", "Admin", "+4671111111", "admin" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "ArticleNumber", "authorId", "genre", "IsDeleted", "pages", "Price", "pubYear", "rating", "summary", "title" },
                values: new object[] { new Guid("183edae4-a5af-4d06-a8a2-e61806db7e00"), "e07b91c8-55fb-4a6f-8178-01ef3a4c870a", new Guid("a7360dc9-c342-414c-86fa-d0aaec810f6a"), "Fantasy", true, 223, 20, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, "A young wizard starts his journey.", "Harry Potter and the Sorcerer's Stone" });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "ArticleNumber", "authorId", "genre", "pages", "Price", "pubYear", "rating", "summary", "title" },
                values: new object[] { new Guid("970ee418-ca25-49c3-bc1b-942d85cf3e25"), "49aa076a-8565-40a4-bb5d-fb25384a0ca8", new Guid("1b518c09-2adb-4d4b-9ede-0a0a281622ec"), "Fantasy", 310, 15, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.7m, "A hobbit's adventure.", "The Hobbit" });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "userId" },
                values: new object[] { new Guid("b63edc64-210a-42ed-bd5d-77f34eefacc2"), new Guid("a9f3ebe6-aa6b-44a7-8ad8-e4b8ca976a8d") });

            migrationBuilder.InsertData(
                table: "wallet",
                columns: new[] { "walletId", "balance", "userId" },
                values: new object[] { new Guid("6b8bb953-89e7-4d0b-959f-81526ff4b3f8"), 100, new Guid("a9f3ebe6-aa6b-44a7-8ad8-e4b8ca976a8d") });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "purchaseHistoryId", "quantity", "TotalPrice" },
                values: new object[] { new Guid("641583df-4c4d-42af-8105-dc575fa3cc16"), new Guid("183edae4-a5af-4d06-a8a2-e61806db7e00"), new DateTime(2024, 2, 4, 16, 20, 32, 717, DateTimeKind.Utc).AddTicks(2219), new Guid("b63edc64-210a-42ed-bd5d-77f34eefacc2"), 1, 20 });

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
