﻿// <auto-generated />
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
    [Migration("20240221040657_AddProductAndCategoryWithSeedData")]
    partial class AddProductAndCategoryWithSeedData
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
                            ListPrice = 390.0,
                            Price = 380.0,
                            Price100 = 360.0,
                            Price50 = 370.0,
                            Title = "Inside the Machine: An Illustrated Introduction to Microprocessors and Computer Architecture"
                        });
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
#pragma warning restore 612, 618
        }
    }
}
