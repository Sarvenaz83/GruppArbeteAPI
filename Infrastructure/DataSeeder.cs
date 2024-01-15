using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = Guid.NewGuid(), AuthorName = "Author 1" },
                new Author { AuthorId = Guid.NewGuid(), AuthorName = "Author 2" },
                new Author { AuthorId = Guid.NewGuid(), AuthorName = "Author 3" }
                );
        }
    }
}
