using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewNameForAuthors1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("1ffe35d3-e1dd-4b9b-9a80-b02c540e5d04"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("ef809c0b-1860-426d-ad69-61415dbe9c7f"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("f0293c58-44fa-4079-b440-7860e92b9571"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("0d33df61-3dde-4cfd-8eed-b85eac5c75ca"), "James Patterson" },
                    { new Guid("8b59c137-3321-4c1c-bbcd-e8f3e27580c2"), "Stephen King" },
                    { new Guid("caa43f6b-2c2a-47a0-91e5-a6dcaf220114"), "J.K Rowling" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("0d33df61-3dde-4cfd-8eed-b85eac5c75ca"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("8b59c137-3321-4c1c-bbcd-e8f3e27580c2"));

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "authorId",
                keyValue: new Guid("caa43f6b-2c2a-47a0-91e5-a6dcaf220114"));

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "authorId", "authorName" },
                values: new object[,]
                {
                    { new Guid("1ffe35d3-e1dd-4b9b-9a80-b02c540e5d04"), "Author 1" },
                    { new Guid("ef809c0b-1860-426d-ad69-61415dbe9c7f"), "Author 2" },
                    { new Guid("f0293c58-44fa-4079-b440-7860e92b9571"), "Author 3" }
                });
        }
    }
}
