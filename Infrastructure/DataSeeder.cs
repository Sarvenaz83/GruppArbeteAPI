using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataSeeder
    {
        //Bug: SeedData is not being called
        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Authors
            var author1 = new Author { AuthorId = Guid.NewGuid(), AuthorName = "J.K Rowling" };
            var author2 = new Author { AuthorId = Guid.NewGuid(), AuthorName = "Alan Rickman" };
            var author3 = new Author { AuthorId = Guid.NewGuid(), AuthorName = "Stephen King" };
            modelBuilder.Entity<Author>().HasData(
                author1,
                author2,
                author3
            );

            // Seed Books
            var book1Id = Guid.NewGuid();
            var book2Id = Guid.NewGuid();
            var book3Id = Guid.NewGuid();
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = book1Id, Title = "Book 1", AuthorId = author1.AuthorId, Genre = "Action", PubYear = DateTime.UtcNow, Pages = 250, StockBalance = 10, Rating = 4.5m, Summary = "Action packed book" },
                new Book { BookId = book2Id, Title = "Book 2", AuthorId = author2.AuthorId, Genre = "Comedy", PubYear = DateTime.UtcNow, Pages = 300, StockBalance = 20, Rating = 3.7m, Summary = "Very funny book" },
                new Book { BookId = book3Id, Title = "Book 3", AuthorId = author3.AuthorId, Genre = "Drama", PubYear = DateTime.UtcNow, Pages = 180, StockBalance = 10, Rating = 4.8m, Summary = "So much drama" }
            );

            // Seed Users
            var userId = GenerateRandomGuid();
            modelBuilder.Entity<User>().HasData(
                new
                {
                    UserId = userId,
                    UserName = "AnvändareTestKöphistorik",
                    // Andra fält som Email, PhoneNumber, etc. om sådana finns
                },
                new
                {
                    UserId = GenerateRandomGuid(),
                    UserName = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin")
                }
            );

            // Seed PurchaseHistories
            var purchaseHistory1Id = GenerateRandomGuid();
            var purchaseHistory2Id = GenerateRandomGuid();
            var purchaseHistory3Id = GenerateRandomGuid();
            modelBuilder.Entity<PurchaseHistory>().HasData(
                new
                {
                    PurchaseHistoryId = purchaseHistory1Id,
                    UserId = userId,
                    TimeOfPurchase = DateTime.UtcNow,
                    TotalPrice = 50
                },
                new
                {
                    PurchaseHistoryId = purchaseHistory2Id,
                    UserId = userId,
                    TimeOfPurchase = DateTime.UtcNow,
                    TotalPrice = 30
                },
                new
                {
                    PurchaseHistoryId = purchaseHistory3Id,
                    UserId = userId,
                    TimeOfPurchase = DateTime.UtcNow,
                    TotalPrice = 25
                }
            );

            // Seed Receipts
            modelBuilder.Entity<Receipt>().HasData(
                new
                {
                    ReceiptId = GenerateRandomGuid(),
                    PurchaseHistoryId = purchaseHistory1Id,
                    BookId = book1Id,
                    Quantity = 2,
                    PricePerUnit = 100,
                    DateDetail = DateTime.UtcNow
                },
                new
                {
                    ReceiptId = GenerateRandomGuid(),
                    PurchaseHistoryId = purchaseHistory2Id,
                    BookId = book2Id,
                    Quantity = 1,
                    PricePerUnit = 150,
                    DateDetail = DateTime.UtcNow
                },
                new
                {
                    ReceiptId = GenerateRandomGuid(),
                    PurchaseHistoryId = purchaseHistory3Id,
                    BookId = book3Id,
                    Quantity = 3,
                    PricePerUnit = 80,
                    DateDetail = DateTime.UtcNow
                }
            );
        }
        //för att se till att id:na stämmer överens mellan foreign key(userid o PurchaseId vid seed
        private static Guid GenerateRandomGuid()
        {
            return Guid.NewGuid();
        }





    }

}
