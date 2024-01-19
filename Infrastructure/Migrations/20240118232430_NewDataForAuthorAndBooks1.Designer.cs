﻿// <auto-generated />
using System;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(HarryPotterContext))]
<<<<<<<< HEAD:Infrastructure/Migrations/20240118232430_NewDataForAuthorAndBooks1.Designer.cs
    [Migration("20240118232430_NewDataForAuthorAndBooks1")]
    partial class NewDataForAuthorAndBooks1
========
    [Migration("20240117123513_AddWalletIdToUser")]
    partial class AddWalletIdToUser
>>>>>>>> feature/skapa-users:Infrastructure/Migrations/20240117123513_AddWalletIdToUser.Designer.cs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("authorId");

                    b.Property<string>("AuthorName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("authorName");

                    b.HasKey("AuthorId")
                        .HasName("PK__author__8E2731B93441940C");

                    b.ToTable("author", (string)null);

                    b.HasData(
                        new
                        {
<<<<<<<< HEAD:Infrastructure/Migrations/20240118232430_NewDataForAuthorAndBooks1.Designer.cs
                            AuthorId = new Guid("c034d429-4334-45fc-82f2-084033a89a39"),
                            AuthorName = "J.K Rowling"
                        },
                        new
                        {
                            AuthorId = new Guid("a71ab6b4-2160-4636-bafc-46c52bbffc7a"),
                            AuthorName = "Alan Rickman"
                        },
                        new
                        {
                            AuthorId = new Guid("9c672a17-e142-47a5-ae8c-87f8d00eab14"),
                            AuthorName = "Stephen King"
========
                            AuthorId = new Guid("69921ded-e18a-40df-971f-51ee6bb987c1"),
                            AuthorName = "Author 1"
                        },
                        new
                        {
                            AuthorId = new Guid("34214eb7-4e9c-4a73-aa25-90665c4d092b"),
                            AuthorName = "Author 2"
                        },
                        new
                        {
                            AuthorId = new Guid("34e70b41-8d8d-4a3a-a48e-3d2820339d50"),
                            AuthorName = "Author 3"
>>>>>>>> feature/skapa-users:Infrastructure/Migrations/20240117123513_AddWalletIdToUser.Designer.cs
                        });
                });

            modelBuilder.Entity("Domain.Models.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("bookId");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("authorId");

                    b.Property<string>("Genre")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("genre");

                    b.Property<int?>("Pages")
                        .HasColumnType("int")
                        .HasColumnName("pages");

                    b.Property<DateTime?>("PubYear")
                        .HasColumnType("datetime")
                        .HasColumnName("pubYear");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("rating");

                    b.Property<int?>("StockBalance")
                        .HasColumnType("int")
                        .HasColumnName("stockBalance");

                    b.Property<string>("Summary")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("summary");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.HasKey("BookId")
                        .HasName("PK__book__8BE5A10DE068B40D");

                    b.HasIndex("AuthorId");

                    b.ToTable("book", (string)null);

                    b.HasData(
                        new
                        {
<<<<<<<< HEAD:Infrastructure/Migrations/20240118232430_NewDataForAuthorAndBooks1.Designer.cs
                            BookId = new Guid("c78a1102-37e3-43f4-b0ed-572121807cd9"),
                            AuthorId = new Guid("c034d429-4334-45fc-82f2-084033a89a39"),
                            Genre = "Action",
                            Pages = 250,
                            PubYear = new DateTime(2024, 1, 18, 23, 24, 30, 362, DateTimeKind.Utc).AddTicks(8511),
========
                            BookId = new Guid("3e6a1f9b-93a5-4c2f-9549-366689271caa"),
                            AuthorId = new Guid("69921ded-e18a-40df-971f-51ee6bb987c1"),
                            Genre = "Action",
                            Pages = 250,
                            PubYear = new DateTime(2024, 1, 17, 12, 35, 13, 12, DateTimeKind.Utc).AddTicks(7894),
>>>>>>>> feature/skapa-users:Infrastructure/Migrations/20240117123513_AddWalletIdToUser.Designer.cs
                            Rating = 4.5m,
                            StockBalance = 10,
                            Summary = "Action packed book",
                            Title = "Book 1"
                        },
                        new
                        {
<<<<<<<< HEAD:Infrastructure/Migrations/20240118232430_NewDataForAuthorAndBooks1.Designer.cs
                            BookId = new Guid("28b605c5-d993-4dd1-b2dd-8b0aa855fe59"),
                            AuthorId = new Guid("a71ab6b4-2160-4636-bafc-46c52bbffc7a"),
                            Genre = "Comedy",
                            Pages = 300,
                            PubYear = new DateTime(2024, 1, 18, 23, 24, 30, 362, DateTimeKind.Utc).AddTicks(8524),
========
                            BookId = new Guid("5be91552-3e41-4345-a89f-72e41537fb14"),
                            AuthorId = new Guid("34214eb7-4e9c-4a73-aa25-90665c4d092b"),
                            Genre = "Comedy",
                            Pages = 300,
                            PubYear = new DateTime(2024, 1, 17, 12, 35, 13, 12, DateTimeKind.Utc).AddTicks(7914),
>>>>>>>> feature/skapa-users:Infrastructure/Migrations/20240117123513_AddWalletIdToUser.Designer.cs
                            Rating = 3.7m,
                            StockBalance = 20,
                            Summary = "Very funny book",
                            Title = "Book 2"
                        },
                        new
                        {
<<<<<<<< HEAD:Infrastructure/Migrations/20240118232430_NewDataForAuthorAndBooks1.Designer.cs
                            BookId = new Guid("ca441b71-c04c-4e01-b344-62077099b959"),
                            AuthorId = new Guid("9c672a17-e142-47a5-ae8c-87f8d00eab14"),
                            Genre = "Drama",
                            Pages = 180,
                            PubYear = new DateTime(2024, 1, 18, 23, 24, 30, 362, DateTimeKind.Utc).AddTicks(8543),
========
                            BookId = new Guid("1fc0dbbc-3d38-4080-a6c3-7bbeac33c9f7"),
                            AuthorId = new Guid("34e70b41-8d8d-4a3a-a48e-3d2820339d50"),
                            Genre = "Drama",
                            Pages = 180,
                            PubYear = new DateTime(2024, 1, 17, 12, 35, 13, 12, DateTimeKind.Utc).AddTicks(7920),
>>>>>>>> feature/skapa-users:Infrastructure/Migrations/20240117123513_AddWalletIdToUser.Designer.cs
                            Rating = 4.8m,
                            StockBalance = 10,
                            Summary = "So much drama",
                            Title = "Book 3"
                        });
                });

            modelBuilder.Entity("Domain.Models.PurchaseDetail", b =>
                {
                    b.Property<Guid>("PurchaseDetailId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("purchaseDetailId");

                    b.Property<Guid?>("BookId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("bookId");

                    b.Property<DateTime?>("DateDetail")
                        .HasColumnType("datetime")
                        .HasColumnName("dateDetail");

                    b.Property<int?>("PricePerUnit")
                        .HasColumnType("int")
                        .HasColumnName("pricePerUnit");

                    b.Property<Guid?>("PurchaseId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("purchaseId");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("PurchaseDetailId")
                        .HasName("PK__purchase__FA43B55BADA17CED");

                    b.HasIndex("BookId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("purchaseDetail", (string)null);
                });

            modelBuilder.Entity("Domain.Models.PurchaseHistory", b =>
                {
                    b.Property<Guid>("PurchaseId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("purchaseId");

                    b.Property<DateTime?>("TimeOfPurchase")
                        .HasColumnType("datetime")
                        .HasColumnName("timeOfPurchase");

                    b.Property<int?>("TotalPrice")
                        .HasColumnType("int")
                        .HasColumnName("totalPrice");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.HasKey("PurchaseId")
                        .HasName("PK__purchase__0261226C79359CBF");

                    b.HasIndex("UserId");

                    b.ToTable("purchaseHistory", (string)null);
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("firstName");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("role");

                    b.Property<string>("SurName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("surName");

                    b.Property<string>("TelephoneNumber")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telephoneNumber");

                    b.Property<string>("UserName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("userName");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId")
                        .HasName("PK__user__CB9A1CFF7FE751DC");

                    b.HasIndex("WalletId");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Wallet", b =>
                {
                    b.Property<Guid>("WalletId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("walletId");

                    b.Property<int?>("Balance")
                        .HasColumnType("int")
                        .HasColumnName("balance");

                    b.HasKey("WalletId")
                        .HasName("PK__wallet__3785C8706E62B1A8");

                    b.ToTable("wallet", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Book", b =>
                {
                    b.HasOne("Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK__book__authorId__4222D4EF");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Domain.Models.PurchaseDetail", b =>
                {
                    b.HasOne("Domain.Models.Book", "Book")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK__purchaseD__bookI__440B1D61");

                    b.HasOne("Domain.Models.PurchaseHistory", "Purchase")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("PurchaseId")
                        .HasConstraintName("FK__purchaseD__purch__4316F928");

                    b.Navigation("Book");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Domain.Models.PurchaseHistory", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("PurchaseHistories")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__purchaseH__userI__412EB0B6");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Domain.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Domain.Models.Book", b =>
                {
                    b.Navigation("PurchaseDetails");
                });

            modelBuilder.Entity("Domain.Models.PurchaseHistory", b =>
                {
                    b.Navigation("PurchaseDetails");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("PurchaseHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
