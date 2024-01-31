using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CJMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Receipt",
                keyColumn: "ReceiptId",
                keyValue: new Guid("1bfd0420-b766-4350-a554-08148d3bc4bb"));

            migrationBuilder.DeleteData(
                table: "Receipt",
                keyColumn: "ReceiptId",
                keyValue: new Guid("825f8366-3011-4de2-8de8-ceaa2d6f60c1"));

            migrationBuilder.DeleteData(
                table: "Receipt",
                keyColumn: "ReceiptId",
                keyValue: new Guid("f04da8ea-996a-4b65-b45e-7c1da972869f"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("0e8cf5ea-fbd8-49d9-8bb9-abd654f53961"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("877d17b1-9b90-496e-a788-d47355349d0d"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("b1a048fb-5eda-416e-9516-90b1012f623b"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userId",
                keyValue: new Guid("6190c409-ae89-4271-bb5e-0d5b9c704da9"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("3c74767c-b033-4b7e-aec0-292546123bf4"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("5b16858e-f785-467c-985d-2b676b050a5a"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("943c6ec8-31ee-45a9-877b-f323c63d7bb1"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseHistoryId",
                keyValue: new Guid("06f7523a-32c2-461f-9d6b-4c3fa03564ca"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseHistoryId",
                keyValue: new Guid("12365271-867c-4734-a649-30f3b235a60e"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseHistoryId",
                keyValue: new Guid("7a2af17c-9401-49b9-b5b2-db1a35f53fc0"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userId",
                keyValue: new Guid("1e383c91-e7d0-46a6-a1da-3d2e424e4035"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("423f7251-7721-46f1-8291-6e5f198e11d2"), "Alan Rickman" },
                    { new Guid("6b121264-6f37-4961-89da-c4175c3c600c"), "Stephen King" },
                    { new Guid("9363d81e-b1b8-4fb4-9d0f-9c203ab38208"), "J.K Rowling" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userId", "email", "firstName", "password", "surName", "telephoneNumber", "userName" },
                values: new object[,]
                {
                    { new Guid("84b53cab-5a58-4263-833d-6c6fe733d937"), "mail@gmail.com", "Test", "$2a$11$mt4sWAw1ZoPO9REd5bW2R.g7EZn0.0BxPfVpdRGgRK9I26Xmc0PX.", "Test", "+467000000", "AnvändareTestKöphistorik" },
                    { new Guid("8622f8e7-2356-4f83-bd2b-bcb0dab3b9e8"), "admin@gmail.com", "Admin", "$2a$11$fhcwKfturqgJ2cSzXX4dXuOd.l3Ygw0F23PY/5UIaBTr0.desTYRe", "Admin", "+4671111111", "admin" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "bookId", "authorId", "genre", "pages", "pubYear", "rating", "stockBalance", "summary", "title" },
                values: new object[,]
                {
                    { new Guid("395ef40b-a588-4839-849e-0f13f69e91e7"), new Guid("6b121264-6f37-4961-89da-c4175c3c600c"), "Drama", 180, new DateTime(2024, 1, 31, 0, 22, 28, 479, DateTimeKind.Utc).AddTicks(4890), 4.8m, 10, "So much drama", "Book 3" },
                    { new Guid("8b50e0f0-b964-48aa-92cb-1dc456e21567"), new Guid("423f7251-7721-46f1-8291-6e5f198e11d2"), "Comedy", 300, new DateTime(2024, 1, 31, 0, 22, 28, 479, DateTimeKind.Utc).AddTicks(4890), 3.7m, 20, "Very funny book", "Book 2" },
                    { new Guid("dbc520a8-4435-438e-9d63-cd4de5894655"), new Guid("9363d81e-b1b8-4fb4-9d0f-9c203ab38208"), "Action", 250, new DateTime(2024, 1, 31, 0, 22, 28, 479, DateTimeKind.Utc).AddTicks(4880), 4.5m, 10, "Action packed book", "Book 1" }
                });

            migrationBuilder.InsertData(
                table: "purchaseHistory",
                columns: new[] { "purchaseHistoryId", "timeOfPurchase", "totalPrice", "userId" },
                values: new object[,]
                {
                    { new Guid("0f8c5b72-deb9-41c2-9f02-45e46851ac5f"), new DateTime(2024, 1, 31, 0, 22, 28, 760, DateTimeKind.Utc).AddTicks(50), 25, new Guid("84b53cab-5a58-4263-833d-6c6fe733d937") },
                    { new Guid("10c74336-6a85-4f10-b9be-dadab3879e28"), new DateTime(2024, 1, 31, 0, 22, 28, 760, DateTimeKind.Utc).AddTicks(40), 50, new Guid("84b53cab-5a58-4263-833d-6c6fe733d937") },
                    { new Guid("d9293fe0-227d-449d-87b6-5ebe32d11496"), new DateTime(2024, 1, 31, 0, 22, 28, 760, DateTimeKind.Utc).AddTicks(50), 30, new Guid("84b53cab-5a58-4263-833d-6c6fe733d937") }
                });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "ReceiptId", "bookId", "dateDetail", "pricePerUnit", "purchaseHistoryId", "quantity" },
                values: new object[,]
                {
                    { new Guid("68f582df-8cbb-43ef-a8ed-bcbe1736378c"), new Guid("395ef40b-a588-4839-849e-0f13f69e91e7"), new DateTime(2024, 1, 31, 0, 22, 28, 760, DateTimeKind.Utc).AddTicks(90), 80, new Guid("0f8c5b72-deb9-41c2-9f02-45e46851ac5f"), 3 },
                    { new Guid("7df7c902-07b4-448b-8e2a-bfe0779df0cb"), new Guid("dbc520a8-4435-438e-9d63-cd4de5894655"), new DateTime(2024, 1, 31, 0, 22, 28, 760, DateTimeKind.Utc).AddTicks(80), 100, new Guid("10c74336-6a85-4f10-b9be-dadab3879e28"), 2 },
                    { new Guid("9c8a0064-8549-43b4-8916-6b1eade8dd35"), new Guid("8b50e0f0-b964-48aa-92cb-1dc456e21567"), new DateTime(2024, 1, 31, 0, 22, 28, 760, DateTimeKind.Utc).AddTicks(80), 150, new Guid("d9293fe0-227d-449d-87b6-5ebe32d11496"), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Receipt",
                keyColumn: "ReceiptId",
                keyValue: new Guid("68f582df-8cbb-43ef-a8ed-bcbe1736378c"));

            migrationBuilder.DeleteData(
                table: "Receipt",
                keyColumn: "ReceiptId",
                keyValue: new Guid("7df7c902-07b4-448b-8e2a-bfe0779df0cb"));

            migrationBuilder.DeleteData(
                table: "Receipt",
                keyColumn: "ReceiptId",
                keyValue: new Guid("9c8a0064-8549-43b4-8916-6b1eade8dd35"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("395ef40b-a588-4839-849e-0f13f69e91e7"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("8b50e0f0-b964-48aa-92cb-1dc456e21567"));

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "bookId",
                keyValue: new Guid("dbc520a8-4435-438e-9d63-cd4de5894655"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userId",
                keyValue: new Guid("8622f8e7-2356-4f83-bd2b-bcb0dab3b9e8"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("423f7251-7721-46f1-8291-6e5f198e11d2"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("6b121264-6f37-4961-89da-c4175c3c600c"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("9363d81e-b1b8-4fb4-9d0f-9c203ab38208"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseHistoryId",
                keyValue: new Guid("0f8c5b72-deb9-41c2-9f02-45e46851ac5f"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseHistoryId",
                keyValue: new Guid("10c74336-6a85-4f10-b9be-dadab3879e28"));

            migrationBuilder.DeleteData(
                table: "purchaseHistory",
                keyColumn: "purchaseHistoryId",
                keyValue: new Guid("d9293fe0-227d-449d-87b6-5ebe32d11496"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userId",
                keyValue: new Guid("84b53cab-5a58-4263-833d-6c6fe733d937"));

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
        }
    }
}
