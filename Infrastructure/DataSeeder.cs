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
        }
    }
}
