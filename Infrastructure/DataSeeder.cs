using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataSeeder
    {
        //Bug: SeedData is not being called
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var author1 = new Author { AuthorId = Guid.NewGuid(), AuthorName = "J.K Rowling" };
            var author2 = new Author { AuthorId = Guid.NewGuid(), AuthorName = "Alan Rickman" };
            var author3 = new Author { AuthorId = Guid.NewGuid(), AuthorName = "Stephen King" };
            modelBuilder.Entity<Author>().HasData(
                author1,
                author2,
                author3
                );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = Guid.NewGuid(), Title = "Book 1", AuthorId = author1.AuthorId, Genre = "Action", PubYear = DateTime.UtcNow, Pages = 250, StockBalance = 10, Rating = 4.5m, Summary = "Action packed book" },
                new Book { BookId = Guid.NewGuid(), Title = "Book 2", AuthorId = author2.AuthorId, Genre = "Comedy", PubYear = DateTime.UtcNow, Pages = 300, StockBalance = 20, Rating = 3.7m, Summary = "Very funny book" },
                new Book { BookId = Guid.NewGuid(), Title = "Book 3", AuthorId = author3.AuthorId, Genre = "Drama", PubYear = DateTime.UtcNow, Pages = 180, StockBalance = 10, Rating = 4.8m, Summary = "So much drama" });


            // För att seeda in en user, lägg till mail, namn nummer etc
            var userId = GenerateRandomGuid();
            modelBuilder.Entity<User>().HasData(
                new
                {
                    UserId = userId,
                    UserName = "AnvändareTestKöphistorik",
                }
            );

            // Seeda historik
            modelBuilder.Entity<PurchaseHistory>().HasData(
                new
                {
                    PurchaseId = GenerateRandomGuid(),
                    UserId = userId,
                    TimeOfPurchase = DateTime.UtcNow,
                    TotalPrice = 50
                },
                new
                {
                    PurchaseId = GenerateRandomGuid(),
                    UserId = userId,
                    TimeOfPurchase = DateTime.UtcNow,
                    TotalPrice = 30
                },
                new
                {
                    PurchaseId = GenerateRandomGuid(),
                    UserId = userId,
                    TimeOfPurchase = DateTime.UtcNow,
                    TotalPrice = 25
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
