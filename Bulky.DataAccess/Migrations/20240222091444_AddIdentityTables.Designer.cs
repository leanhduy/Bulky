﻿// <auto-generated />
using System;
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240222091444_AddIdentityTables")]
    partial class AddIdentityTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DisplayedOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DisplayedOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            ID = 2,
                            DisplayedOrder = 2,
                            Name = "SciFi"
                        },
                        new
                        {
                            ID = 3,
                            DisplayedOrder = 3,
                            Name = "History"
                        },
                        new
                        {
                            ID = 4,
                            DisplayedOrder = 4,
                            Name = "Classical Literature"
                        },
                        new
                        {
                            ID = 5,
                            DisplayedOrder = 5,
                            Name = "Programming"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Leo Tolstoy",
                            CategoryId = 1,
                            Description = "A novel by Leo Tolstoy",
                            ISBN = "ISBN1",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 200.0,
                            Price = 180.0,
                            Price100 = 160.0,
                            Price50 = 170.0,
                            Title = "Anna Karenina"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Gustave Flaubert",
                            CategoryId = 2,
                            Description = "A novel by Gustave Flaubert",
                            ISBN = "ISBN2",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 150.0,
                            Price = 140.0,
                            Price100 = 120.0,
                            Price50 = 130.0,
                            Title = "Madame Bovary"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Leo Tolstoy",
                            CategoryId = 1,
                            Description = "A novel by Leo Tolstoy",
                            ISBN = "ISBN3",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 300.0,
                            Price = 280.0,
                            Price100 = 260.0,
                            Price50 = 270.0,
                            Title = "War and Peace"
                        },
                        new
                        {
                            Id = 4,
                            Author = "F. Scott Fitzgerald",
                            CategoryId = 2,
                            Description = "A novel by F. Scott Fitzgerald",
                            ISBN = "ISBN4",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 120.0,
                            Price = 110.0,
                            Price100 = 90.0,
                            Price50 = 100.0,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Vladimir Nabokov",
                            CategoryId = 2,
                            Description = "A novel by Vladimir Nabokov",
                            ISBN = "ISBN5",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 210.0,
                            Price = 200.0,
                            Price100 = 180.0,
                            Price50 = 190.0,
                            Title = "Lolita"
                        },
                        new
                        {
                            Id = 6,
                            Author = "George Eliot",
                            CategoryId = 3,
                            Description = "A novel by George Eliot",
                            ISBN = "ISBN6",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 220.0,
                            Price = 210.0,
                            Price100 = 190.0,
                            Price50 = 200.0,
                            Title = "Middlemarch"
                        },
                        new
                        {
                            Id = 7,
                            Author = "George Orwell",
                            CategoryId = 2,
                            Description = "A novel by George Orwell",
                            ISBN = "ISBN7",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 230.0,
                            Price = 220.0,
                            Price100 = 200.0,
                            Price50 = 210.0,
                            Title = "1984"
                        },
                        new
                        {
                            Id = 8,
                            Author = "J.R.R. Tolkien",
                            CategoryId = 1,
                            Description = "A novel by J.R.R. Tolkien",
                            ISBN = "ISBN8",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 240.0,
                            Price = 230.0,
                            Price100 = 210.0,
                            Price50 = 220.0,
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Khaled Hosseini",
                            CategoryId = 4,
                            Description = "A novel by Khaled Hosseini",
                            ISBN = "ISBN9",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 250.0,
                            Price = 240.0,
                            Price100 = 220.0,
                            Price50 = 230.0,
                            Title = "The Kite Runner"
                        },
                        new
                        {
                            Id = 10,
                            Author = "J.K. Rowling",
                            CategoryId = 2,
                            Description = "A novel by J.K. Rowling",
                            ISBN = "ISBN10",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 260.0,
                            Price = 250.0,
                            Price100 = 230.0,
                            Price50 = 240.0,
                            Title = "Harry Potter and the Philosopher's Stone"
                        },
                        new
                        {
                            Id = 11,
                            Author = "Robert C. Martin",
                            CategoryId = 5,
                            Description = "A book by Robert C. Martin",
                            ISBN = "ISBN16",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 350.0,
                            Price = 340.0,
                            Price100 = 320.0,
                            Price50 = 330.0,
                            Title = "Clean Code: A Handbook of Agile Software Craftsmanship"
                        },
                        new
                        {
                            Id = 12,
                            Author = "Frederick P. Brooks Jr.",
                            CategoryId = 5,
                            Description = "A book by Frederick P. Brooks Jr.",
                            ISBN = "ISBN17",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 360.0,
                            Price = 350.0,
                            Price100 = 330.0,
                            Price50 = 340.0,
                            Title = "The Mythical Man-Month: Essays on Software Engineering"
                        },
                        new
                        {
                            Id = 13,
                            Author = "Andrew Hunt and David Thomas",
                            CategoryId = 5,
                            Description = "A book by Andrew Hunt and David Thomas",
                            ISBN = "ISBN18",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 370.0,
                            Price = 360.0,
                            Price100 = 340.0,
                            Price50 = 350.0,
                            Title = "The Pragmatic Programmer: Your Journey to Mastery"
                        },
                        new
                        {
                            Id = 14,
                            Author = "Eric Matthes",
                            CategoryId = 5,
                            Description = "A book by Eric Matthes",
                            ISBN = "ISBN19",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 380.0,
                            Price = 370.0,
                            Price100 = 350.0,
                            Price50 = 360.0,
                            Title = "Python Crash Course: A Hands-On, Project-Based Introduction to Programming"
                        },
                        new
                        {
                            Id = 15,
                            Author = "Jon Stokes",
                            CategoryId = 5,
                            Description = "A book by Jon Stokes",
                            ISBN = "ISBN20",
                            ImageUrl = "https://d827xgdhgqbnd.cloudfront.net/wp-content/uploads/2016/04/09121712/book-cover-placeholder.png",
                            ListPrice = 390.0,
                            Price = 380.0,
                            Price100 = 360.0,
                            Price50 = 370.0,
                            Title = "Inside the Machine: An Illustrated Introduction to Microprocessors and Computer Architecture"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Bulky.Models.Product", b =>
                {
                    b.HasOne("Bulky.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
