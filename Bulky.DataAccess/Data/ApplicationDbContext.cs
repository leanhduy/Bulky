using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		// Create DbSet (equivalent to tables in database)
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Categories
			modelBuilder.Entity<Category>().HasData(
				new Category { ID = 1, Name = "Action", DisplayedOrder = 1 },
				new Category { ID = 2, Name = "SciFi", DisplayedOrder = 2 },
				new Category { ID = 3, Name = "History", DisplayedOrder = 3 }
			);
			#endregion

			#region Product (Books)
			modelBuilder.Entity<Product>().HasData(
				new Product { Id = 1, Title = "Anna Karenina", Description = "A novel by Leo Tolstoy", ISBN = "ISBN1", Author = "Leo Tolstoy", ListPrice = 200, Price = 180, Price50 = 170, Price100 = 160 },
				new Product { Id = 2, Title = "Madame Bovary", Description = "A novel by Gustave Flaubert", ISBN = "ISBN2", Author = "Gustave Flaubert", ListPrice = 150, Price = 140, Price50 = 130, Price100 = 120 },
				new Product { Id = 3, Title = "War and Peace", Description = "A novel by Leo Tolstoy", ISBN = "ISBN3", Author = "Leo Tolstoy", ListPrice = 300, Price = 280, Price50 = 270, Price100 = 260 },
				new Product { Id = 4, Title = "The Great Gatsby", Description = "A novel by F. Scott Fitzgerald", ISBN = "ISBN4", Author = "F. Scott Fitzgerald", ListPrice = 120, Price = 110, Price50 = 100, Price100 = 90 },
				new Product { Id = 5, Title = "Lolita", Description = "A novel by Vladimir Nabokov", ISBN = "ISBN5", Author = "Vladimir Nabokov", ListPrice = 210, Price = 200, Price50 = 190, Price100 = 180 },
				new Product { Id = 6, Title = "Middlemarch", Description = "A novel by George Eliot", ISBN = "ISBN6", Author = "George Eliot", ListPrice = 220, Price = 210, Price50 = 200, Price100 = 190 },
				new Product { Id = 7, Title = "1984", Description = "A novel by George Orwell", ISBN = "ISBN7", Author = "George Orwell", ListPrice = 230, Price = 220, Price50 = 210, Price100 = 200 },
				new Product { Id = 8, Title = "The Lord of the Rings", Description = "A novel by J.R.R. Tolkien", ISBN = "ISBN8", Author = "J.R.R. Tolkien", ListPrice = 240, Price = 230, Price50 = 220, Price100 = 210 },
				new Product { Id = 9, Title = "The Kite Runner", Description = "A novel by Khaled Hosseini", ISBN = "ISBN9", Author = "Khaled Hosseini", ListPrice = 250, Price = 240, Price50 = 230, Price100 = 220 },
				new Product { Id = 10, Title = "Harry Potter and the Philosopher's Stone", Description = "A novel by J.K. Rowling", ISBN = "ISBN10", Author = "J.K. Rowling", ListPrice = 260, Price = 250, Price50 = 240, Price100 = 230 },
				new Product { Id = 11, Title = "Clean Code: A Handbook of Agile Software Craftsmanship", Description = "A book by Robert C. Martin", ISBN = "ISBN16", Author = "Robert C. Martin", ListPrice = 350, Price = 340, Price50 = 330, Price100 = 320 },
				new Product { Id = 12, Title = "The Mythical Man-Month: Essays on Software Engineering", Description = "A book by Frederick P. Brooks Jr.", ISBN = "ISBN17", Author = "Frederick P. Brooks Jr.", ListPrice = 360, Price = 350, Price50 = 340, Price100 = 330 },
				new Product { Id = 13, Title = "The Pragmatic Programmer: Your Journey to Mastery", Description = "A book by Andrew Hunt and David Thomas", ISBN = "ISBN18", Author = "Andrew Hunt and David Thomas", ListPrice = 370, Price = 360, Price50 = 350, Price100 = 340 },
				new Product { Id = 14, Title = "Python Crash Course: A Hands-On, Project-Based Introduction to Programming", Description = "A book by Eric Matthes", ISBN = "ISBN19", Author = "Eric Matthes", ListPrice = 380, Price = 370, Price50 = 360, Price100 = 350 },
				new Product { Id = 15, Title = "Inside the Machine: An Illustrated Introduction to Microprocessors and Computer Architecture", Description = "A book by Jon Stokes", ISBN = "ISBN20", Author = "Jon Stokes", ListPrice = 390, Price = 380, Price50 = 370, Price100 = 360 }
			);
			#endregion
		}
	}
}
