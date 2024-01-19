using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DatabaseContext
{
    public class HarryPotterContext : DbContext
    {
        public HarryPotterContext()
        {
        }

        public HarryPotterContext(DbContextOptions<HarryPotterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

        public virtual DbSet<PurchaseHistory> PurchaseHistories { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = "Server=MINAZ\\SQLEXPRESS;Database=HarryPotter;Trusted_Connection=True;TrustServerCertificate=true";
            //string connectionString = "Server=localhost,1433;Database=HarryPotter;User Id=sa;Password='Arkemar321@';Encrypt=False;TrustServerCertificate=True;";
            string connectionString = "Server=(local)\\SQLEXPRESS;Database=HarryPotter;Trusted_Connection=True;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.AuthorId).HasName("PK__author__8E2731B93441940C");

                entity.ToTable("author");

                entity.Property(e => e.AuthorId)
                    .ValueGeneratedNever()
                    .HasColumnName("authorId");
                entity.Property(e => e.AuthorName)
                    .HasMaxLength(255)
                    .HasColumnName("authorName");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId).HasName("PK__book__8BE5A10DE068B40D");

                entity.ToTable("book");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("bookId");
                entity.Property(e => e.AuthorId).HasColumnName("authorId");
                entity.Property(e => e.Genre)
                    .HasMaxLength(255)
                    .HasColumnName("genre");
                entity.Property(e => e.Pages).HasColumnName("pages");
                entity.Property(e => e.PubYear)
                    .HasColumnType("datetime")
                    .HasColumnName("pubYear");
                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("rating");
                entity.Property(e => e.StockBalance).HasColumnName("stockBalance");
                entity.Property(e => e.Summary)
                    .HasMaxLength(255)
                    .HasColumnName("summary");
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.HasOne(d => d.Author).WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__book__authorId__4222D4EF");
            });

            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.HasKey(e => e.PurchaseDetailId).HasName("PK__purchase__FA43B55BADA17CED");

                entity.ToTable("purchaseDetail");

                entity.Property(e => e.PurchaseDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("purchaseDetailId");
                entity.Property(e => e.BookId).HasColumnName("bookId");
                entity.Property(e => e.DateDetail)
                    .HasColumnType("datetime")
                    .HasColumnName("dateDetail");
                entity.Property(e => e.PricePerUnit).HasColumnName("pricePerUnit");
                entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");
                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Book).WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__purchaseD__bookI__440B1D61");

                entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.PurchaseId)
                    .HasConstraintName("FK__purchaseD__purch__4316F928");
            });

            modelBuilder.Entity<PurchaseHistory>(entity =>
            {
                entity.HasKey(e => e.PurchaseId).HasName("PK__purchase__0261226C79359CBF");

                entity.ToTable("purchaseHistory");

                entity.Property(e => e.PurchaseId)
                    .ValueGeneratedNever()
                    .HasColumnName("purchaseId");
                entity.Property(e => e.TimeOfPurchase)
                    .HasColumnType("datetime")
                    .HasColumnName("timeOfPurchase");
                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User).WithMany(p => p.PurchaseHistories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__purchaseH__userI__412EB0B6");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__user__CB9A1CFF7FE751DC");

                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("userId");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("firstName");
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");
                entity.Property(e => e.SurName)
                    .HasMaxLength(255)
                    .HasColumnName("surName");
                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telephoneNumber");
                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasKey(e => e.WalletId).HasName("PK__wallet__3785C8706E62B1A8");

                entity.ToTable("wallet");

                entity.Property(e => e.WalletId)
                    .ValueGeneratedNever()
                    .HasColumnName("walletId");
                entity.Property(e => e.Balance).HasColumnName("balance");
            });

            DataSeeder.SeedData(modelBuilder);
        }
    }
}



