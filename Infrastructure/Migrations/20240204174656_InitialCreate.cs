using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    { new Guid("6e6a84dd-04a6-4a70-b316-710636cc487f"), "J.K. Rowling" },
                    { new Guid("a72db391-9ccf-44a2-a2a6-fe67754e0bd3"), "J.R.R. Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "surName", "telephoneNumber", "userName" },
                values: new object[,]
                {
                    { new Guid("6997040a-d2fc-4d03-8fe3-887d48ca0814"), "admin@gmail.com", "Admin", "$2a$11$i9TQgQDcg493dltN05ksEeEc90UzqR.1/2330qhvwRCLW9y9ypxO2", "Admin", "+4671111111", "admin" },
                    { new Guid("a10a835e-3510-4b94-b5a5-99c3646cd20b"), "mail@gmail.com", "Test", "$2a$11$zrnTwAxFkpaAFxHgw2a0YeDW0391buXJCtg6NZdZX2kWTle3LNTua", "Test", "+467000000", "AnvändareTest" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "ArticleNumber", "authorId", "genre", "pages", "Price", "pubYear", "rating", "summary", "title" },
                values: new object[] { new Guid("8968fbc4-ff3a-4efa-9f8f-7688a945fd3d"), "e999f343-5d08-465e-93e3-16ec11f7422d", new Guid("a72db391-9ccf-44a2-a2a6-fe67754e0bd3"), "Fantasy", 310, 15, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.7m, "A hobbit's adventure.", "The Hobbit" });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "ArticleNumber", "authorId", "genre", "IsDeleted", "pages", "Price", "pubYear", "rating", "summary", "title" },
                values: new object[] { new Guid("eb623ae5-22a4-4d0e-8f5b-4268516ba439"), "78100468-aaf3-4be2-91a6-03eea6b24c5f", new Guid("6e6a84dd-04a6-4a70-b316-710636cc487f"), "Fantasy", true, 223, 20, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, "A young wizard starts his journey.", "Harry Potter and the Sorcerer's Stone" });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "userId" },
                values: new object[] { new Guid("bb52e8bb-0875-494b-9af2-13a7e2c12979"), new Guid("a10a835e-3510-4b94-b5a5-99c3646cd20b") });

            migrationBuilder.InsertData(
                table: "wallet",
                columns: new[] { "walletId", "balance", "userId" },
                values: new object[] { new Guid("085a365a-038d-448b-b577-df945570cd3d"), 100, new Guid("a10a835e-3510-4b94-b5a5-99c3646cd20b") });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "purchaseHistoryId", "quantity", "TotalPrice" },
                values: new object[] { new Guid("b3e48d10-685d-428f-a9d7-bcdf404b031b"), new Guid("eb623ae5-22a4-4d0e-8f5b-4268516ba439"), new DateTime(2024, 2, 4, 17, 46, 56, 583, DateTimeKind.Utc).AddTicks(106), new Guid("bb52e8bb-0875-494b-9af2-13a7e2c12979"), 1, 20 });

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
