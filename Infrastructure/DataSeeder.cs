using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Infrastructure
{
    public class DataSeeder
    {
        //Bug: SeedData is not being called
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Authors
            var author1 = new Author
            {
                AuthorId = Guid.NewGuid(),
                AuthorName = "J.K. Rowling",
                IsDeleted = false
            };

            var author2 = new Author
            {
                AuthorId = Guid.NewGuid(),
                AuthorName = "J.R.R. Tolkien",
                IsDeleted = false
            };
            modelBuilder.Entity<Author>().HasData(author1, author2);
            // Seed Books
            var book1 = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Harry Potter and the Sorcerer's Stone",
                AuthorId = author1.AuthorId,
                Genre = "Fantasy",
                PubYear = new DateTime(1997, 6, 26),
                Pages = 223,
                Rating = 4.5m,
                Summary = "A young wizard starts his journey.",
                IsDeleted = true,
                Price = 20,
                ArticleNumber = Guid.NewGuid().ToString()
        };

            var book2 = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "The Hobbit",
                AuthorId = author2.AuthorId,
                Genre = "Fantasy",
                PubYear = new DateTime(1937, 9, 21),
                Pages = 310,
                Rating = 4.7m,
                Summary = "A hobbit's adventure.",
                IsDeleted = false,
                Price = 15,
                ArticleNumber = Guid.NewGuid().ToString()
            };

            modelBuilder.Entity<Book>().HasData(book1, book2);

            // Seed Users
            var user1 = new User
            {
                UserId = Guid.NewGuid(),
                UserName = "AnvändareTest",
                Password = BCrypt.Net.BCrypt.HashPassword("password"),
                FirstName = "Test",
                SurName = "Test",
                Email = "mail@gmail.com",
                TelephoneNumber = "+467000000"
            };
            var user2 = new User
            {
                UserId = Guid.NewGuid(),
                UserName = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                FirstName = "Admin",
                SurName = "Admin",
                Email = "admin@gmail.com",
                TelephoneNumber = "+4671111111"
            };

            var wallet1 = new Wallet
            {
                WalletId = Guid.NewGuid(),
                UserId = user1.UserId,
                Balance = 100
            };
            modelBuilder.Entity<User>().HasData(user1, user2);
            modelBuilder.Entity<Wallet>().HasData(wallet1);

            // Seed PurchaseHistory
            var purchaseHistory1 = new PurchaseHistory
            {
                PurchaseHistoryId = Guid.NewGuid(),
                UserId = user1.UserId,
            };

            modelBuilder.Entity<PurchaseHistory>().HasData(purchaseHistory1);

            // Seed Receipts
            var receipt1 = new Receipt
            {
                ReceiptId = Guid.NewGuid(),
                PurchaseHistoryId = purchaseHistory1.PurchaseHistoryId,
                BookId = book1.BookId,
                Quantity = 1,
                DateDetail = DateTime.UtcNow,
                TotalPrice = 20
            };

            modelBuilder.Entity<Receipt>().HasData(receipt1);
        }

    }

}
